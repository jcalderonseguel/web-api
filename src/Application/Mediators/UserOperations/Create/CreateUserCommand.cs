using Application.Common.Interfaces;
using Application.Notifications;
using Domain.Entities;
using FluentValidation.Results;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Mediators.UserOperations.Create
{
    public class CreateUserCommand : Notifiable, IRequest<EntityResult<UserCreatedDto>>
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, EntityResult<UserCreatedDto>>
        {
            private readonly IClientDbContext _context;

            public Handler(IClientDbContext context)
            {
                _context = context;
            }

            public async Task<EntityResult<UserCreatedDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                UserValidator validator = new UserValidator(_context);
                ValidationResult result = await validator.ValidateAsync(request);

                if (!result.IsValid)
                {
                    foreach (var item in result.Errors)
                    {
                        request.AddNotification(item.PropertyName, item.ErrorMessage);
                    }

                    return new EntityResult<UserCreatedDto>(request.Notifications, result.Errors.All(err => err.ErrorCode == ErrorCode.NotFound.ToString()) ? ErrorCode.NotFound : ErrorCode.BadRequest);
                }

                var entity = new Users
                {
                    UserId = Guid.NewGuid(),
                    FullName = request.FullName,
                    Password = request.Password,
                    Email = request.Email,
                    Created = DateTime.Now
                };

                _context.Users.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new EntityResult<UserCreatedDto>(request.Notifications, new UserCreatedDto
                {
                    UserId = entity.UserId
                });
            }
        }
    }
}