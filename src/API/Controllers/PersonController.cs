using API.Models;
using API.Presenters.Interfaces;
using Application.Mediators.PersonOperations.Get;
using Application.Mediators.PersonOperations.GetAddressesByPerson;
using Application.Mediators.PersonOperations.GetById;
using Application.Mediators.PersonOperations.Insert;
using Application.Mediators.UserOperations.Create;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistance.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiVersion("1")]
    [Route("v{v:apiVersion}/persons")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IPersonPresenter personPresenter;

        private readonly IUserService _userService;

        public PersonController(IMediator mediator, IPersonPresenter personPresenter, IUserService userService)
        {
            this.mediator = mediator;
            this.personPresenter = personPresenter;
            _userService = userService;
        }

        /// <summary>
        /// Get the collection of persons by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeOfView"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(FullPersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute]Guid id,
                                                 [FromQuery] string typeOfView)
        {
            return personPresenter.GetResult(await this.mediator.Send(
                new GetByIdRequest(id, typeOfView)
                ));
        }

        [HttpGet]
        [Route("{id}/addresses")]
        [ProducesResponseType(typeof(GetAddressesResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAddresses([FromRoute] Guid id)
        {
            var result = new GetAddressesRequest(id);
            return personPresenter.GetAddressesResult(await mediator.Send(result));
        }

        /// <summary>
        /// Get the collection of persons
        /// </summary>
        /// <param name="email">email of the person</param>
        /// <param name="phoneNumber"></param>
        /// <param name="identificationDocumentTypeId"></param>
        /// <param name="documentNumber"></param>
        /// <param name="genderId"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(GetIdResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery]
                                            int? identificationDocumentTypeId,
                                            string documentNumber,
                                            int? genderId,
                                            string email,
                                            string phoneNumber,
                                            string alias)
        {
            return personPresenter.GetAllResult(await this.mediator.Send(
                new GetIdRequest(
                            identificationDocumentTypeId,
                            documentNumber,
                            genderId,
                            email,
                            phoneNumber,
                            alias)
                ));
        }

        [HttpGet]
        [Route("internal/{personId?}/{roletypeId?}")]
        [ProducesResponseType(typeof(PersonRelationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonInternalById([FromRoute] Guid? personId, int? roletypeId)
        {
            return personPresenter.GetResult(await this.mediator.Send(
                new Application.Mediators.PersonOperations.GetPersonInternalById.GetPersonInternalByIdRequest(personId, roletypeId)
                ));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonCreatedDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody]InsertPersonRequest person) => personPresenter.InsertResult(await this.mediator.Send(person));

        [AllowAnonymous]
        [ProducesResponseType(typeof(UserCreatedDto), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand userModel) => personPresenter.GetResult(await this.mediator.Send(userModel));

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserModel model)
        {
            var user = _userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(user);
        }

        [HttpGet("getUsers")]
        [ProducesResponseType(typeof(PersonRelationDto), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}