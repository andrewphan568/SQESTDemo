using Application;
using Application.MoistureContents;
using Domain.Moisture;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoistureContent(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteMoistureContentCommand(id)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMoistureContent(MoistureContent moistureContent)
        {            
            return HandleResult(await Mediator.Send(new UpdateMoistureContentCommand { MoistureContent = moistureContent }));
        }


        [HttpPost]
        public async Task<IActionResult> CreateMoistureContent(MoistureContent moistureContent)
        {
            return HandleResult(await Mediator.Send(new CreateMoistureContentCommand { MoistureContent = moistureContent }));
        }
    }
}
