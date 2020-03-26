using Microsoft.AspNetCore.Mvc;
using API.Presenters.Interfaces;
using Application.Mediators.IdDocumentOperations.Queries;
using Application.Notifications;

namespace API.Presenters
{
    public class DocumentTypePresenter : BasePresenter, IDocumentTypePresenter
    {
        public IActionResult GetIdDocumentTypeByCountry(EntityResult<IdentificationDocumentVm> result)
        {
            return result.Invalid ? base.GetActionResult(result) :
               new OkObjectResult(result.Entity);
        }
    }
}