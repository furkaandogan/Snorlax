using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Snorlax.Utilities;

namespace Snorlax.Web.Api.Controllers
{
    [AllowAnonymous()]
    public class HomeController
        : BaseController
    {
        public HomeController(ILogger logger)
         : base(logger)
        {

        }
        [HttpGet]
        public async Task<ApiResponse> Index()
        {
            return new ApiResponse(){
                IsOk=true,
                Message="snorlax api:1.0.0-beta"
            };
        }
    }
}