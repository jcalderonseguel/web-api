using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Presenters.Interfaces;
using Application.Mediators.IdDocumentOperations.Queries;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiVersion("1")]
    [Route("v{v:apiVersion}/documentTypes")]
    [ApiController]
    public class DocumentTypeController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IDocumentTypePresenter documentTypePresenter;

        public DocumentTypeController(IMediator mediator, IDocumentTypePresenter documentTypePresenter)
        {
            this.mediator = mediator;
            this.documentTypePresenter = documentTypePresenter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IdentificationDocumentVm),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string countryId)
        {
            return documentTypePresenter.GetIdDocumentTypeByCountry(await this.mediator.Send(new GetIdDocumentTypeByCountryQuery(countryId)));
        }
    }
}