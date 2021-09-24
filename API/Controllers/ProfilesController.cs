namespace API.Controllers
{
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
    }
}
