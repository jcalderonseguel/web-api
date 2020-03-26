using FluentValidation.Results;
using MediatR;
using Application.Common.Interfaces;
using Application.Notifications;
using Application.Validations;
using Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.PersonOperations.GetAddressesByPerson
{
    public class GetAddressesHandler : IRequestHandler<GetAddressesRequest, EntityResult<GetAddressesResult>>
    {
        private readonly IPersonQuery _personQuery;
        private readonly IClientDbContext _context;
        

        public GetAddressesHandler(IPersonQuery personQuery, IClientDbContext context)
        {
            _personQuery = personQuery;
            _context = context;
        }
        public async Task<EntityResult<GetAddressesResult>> Handle(GetAddressesRequest request, CancellationToken cancellationToken)
        {
            GetAddressesValidator validator = new GetAddressesValidator(_context);
            ValidationResult result = await validator.ValidateAsync(request);
            
            if (!result.IsValid)
            {
                
                foreach (var item in result.Errors)
                {
                    request.AddNotification(item.PropertyName, item.ErrorMessage);
                }

                return new EntityResult<GetAddressesResult>(request.Notifications, result.Errors.All(err => err.ErrorCode == ErrorCode.NotFound.ToString()) ? ErrorCode.NotFound : ErrorCode.BadRequest);
            }
            var addresses = await _personQuery.GetAddressesByPerson(request.PersonId);

            if (!addresses.Any())
            {
                return new EntityResult<GetAddressesResult>($"The Address was not found for personId={request.PersonId}.", ErrorCode.NotFound);
            }

            return new EntityResult<GetAddressesResult>(new GetAddressesResult { Addresses = addresses });
        }
        
    }
}
