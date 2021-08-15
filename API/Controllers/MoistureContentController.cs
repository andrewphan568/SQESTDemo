using API.DTOs;
using Application;
using Application.MoistureContents;
using Domain.Moisture;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Controllers
{
    public class MoistureContentController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetMoistureContents()
        {

            return HandleResult(await Mediator.Send(new ListMoistureContentsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMoistureContent(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetMoistureContentQuery(id)));
        }
    }
}
