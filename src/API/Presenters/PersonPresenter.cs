using Microsoft.AspNetCore.Mvc;
using API.Presenters.Interfaces;
using Application.Mediators.PersonOperations.GetAddressesByPerson;
using Application.Mediators.PersonOperations.Get;
using Application.Mediators.PersonOperations.GetById;
using Application.Notifications;
using Application.Mediators.PersonOperations.Insert;

namespace API.Presenters
{
    public class PersonPresenter : BasePresenter, IPersonPresenter
    {
        public IActionResult InsertResult(EntityResult<PersonCreatedDto> result)
        {
            return result.Invalid ? base.GetActionResult(result) :
                    new OkObjectResult(result.Entity)
                    {
                        StatusCode = 200
                    };
        }

        public IActionResult GetResult(EntityResult<GetByIdResult> result)
        {
            return result.Invalid ? base.GetActionResult(result) :
               new OkObjectResult(result.Entity);
        }

        public IActionResult GetAddressesResult(EntityResult<GetAddressesResult> result)
        {
            return result.Invalid ? base.GetActionResult(result) :
               new OkObjectResult(result.Entity);
        }

        public IActionResult GetAllResult(EntityResult<GetIdResult> result)
        {
            return result.Invalid ? base.GetActionResult(result) : new OkObjectResult(result.Entity.Persons);
        }

        public IActionResult GetResult<T>(EntityResult<T> result) where T : class
        {
            return result.Invalid ? base.GetActionResult(result) :
                new OkObjectResult(result.Entity);
        }
    }
}