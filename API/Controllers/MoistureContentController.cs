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
    [ApiController]
    [Route("api/[controller]")]
    public class MoistureContentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoistureContentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<Result<List<MoistureContentDto>>> GetMoistureContents()
        {
            
            return await _mediator.Send(new ListMoistureContentsQuery());
        }

        [HttpGet("{id}")]
        public async Task<Result<MoistureContentDto>> GetMoistureContent(Guid id)
        {
            return await _mediator.Send(new GetMoistureContentQuery(id));
        }


    }
}
