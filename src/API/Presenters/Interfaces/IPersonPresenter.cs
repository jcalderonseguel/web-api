using Microsoft.AspNetCore.Mvc;
using Application.Mediators.PersonOperations.Get;
using Application.Mediators.PersonOperations.GetById;
using Application.Mediators.PersonOperations.GetAddressesByPerson;
using Application.Notifications;
using System;
using Application.Mediators.PersonOperations.Insert;

namespace API.Presenters.Interfaces
{
    public interface IPersonPresenter
    {
        IActionResult InsertResult(EntityResult<PersonCreatedDto> result);

        IActionResult GetResult(EntityResult<GetByIdResult> result);

        IActionResult GetAddressesResult(EntityResult<GetAddressesResult> result);

        IActionResult GetAllResult(EntityResult<GetIdResult> result);

        IActionResult GetResult<T>(EntityResult<T> result) where T : class;
    }
}