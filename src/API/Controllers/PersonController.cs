using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Presenters.Interfaces;
using Application.Mediators.PersonOperations.GetAddressesByPerson;
using Application.Mediators.PersonOperations.GetById;
using Application.Mediators.PersonOperations.Get;
using Application.Mediators.PersonOperations.Insert;
using System;
using System.Threading.Tasks;
using Application.Queries;

namespace API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiVersion("1")]
    [Route("v{v:apiVersion}/persons")]
    [ApiController]

    public class PersonController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IPersonPresenter personPresenter;

        public PersonController(IMediator mediator, IPersonPresenter personPresenter)
        {
            this.mediator = mediator;
            this.personPresenter = personPresenter;
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

        /* Esta mock para post de credit card in account service */
        [HttpGet("exist/{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ExsitPersonById(long personId)
        {
            return new OkObjectResult(new { exist = true });
        }
    }
}