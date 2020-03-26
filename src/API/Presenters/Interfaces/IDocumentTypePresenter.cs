using Microsoft.AspNetCore.Mvc;
using Application.Mediators.IdDocumentOperations.Queries;
using Application.Notifications;

namespace API.Presenters.Interfaces
{
    public interface IDocumentTypePresenter
    {
        IActionResult GetIdDocumentTypeByCountry(EntityResult<IdentificationDocumentVm> result);
    }
}