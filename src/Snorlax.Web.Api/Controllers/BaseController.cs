using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Snorlax.Web.Api.Controllers
{
    [Authorize()]
    public abstract class BaseController
        : Controller
    {
        protected readonly Utilities.ILogger ILogger;
        public BaseController(Utilities.ILogger logger)
        {
            this.ILogger=logger;
        }
        
        new public ApiResponse Unauthorized()
        {
            Response.StatusCode=(int)HttpStatusCode.Unauthorized;
            return new ApiResponse(){
                IsOk=false,
                Message="unauthorized"
            };
        }
    }
}