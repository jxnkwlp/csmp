using CSMP.Portal.Services;
using CSMP.Portal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Controllers
{
    public class EventController : AppControllerBase
    {
        private readonly IServerService _serverService;
        private readonly ICommandService _commandService;

        public EventController(IServerService serverService, ICommandService commandService)
        {
            _serverService = serverService;
            _commandService = commandService;
        }

        /// <summary>
        ///  心跳
        /// </summary> 
        [HttpPost("[action]")]
        public IActionResult Heartbeat([FromBody] HeartbeatRequesetModel model)
        {
            // TODO

            return Ok();
        }

        /// <summary>
        ///  获取命令
        /// </summary>
        /// <param name="identifier">标识符</param> 
        [HttpGet("[action]")]
        public async Task<IActionResult> Command([FromQuery] string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
            {
                return Accepted();
            }

            var commandList = await _commandService.PullAsync(identifier);

            if (commandList == null || commandList.Count == 0)
                return Ok();

            return Ok(commandList);
        }

        /// <summary>
        ///  执行命令反馈
        /// </summary> 
        [HttpPost("[action]")]
        public async Task<IActionResult> Command([FromQuery] string identifier, [FromBody] CommandCallbackRequestModel model)
        {
            if (string.IsNullOrWhiteSpace(identifier))
            {
                return Accepted();
            }

            await _commandService.UpdateStatusAsync(identifier, model.CommandId, model.Status);

            return Ok();
        }
    }
}
