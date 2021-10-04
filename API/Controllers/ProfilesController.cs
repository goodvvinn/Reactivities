namespace API.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Application.Profiles;
    using Microsoft.AspNetCore.Mvc;
    using Reactivities.API.Controllers;

    public class ProfilesController : BaseApiController
    {
        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Username = username }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Edit.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }
    }
}
