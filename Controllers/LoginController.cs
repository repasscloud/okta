using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorOkta.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet("Login")]
        public IActionResult Login([FromQuery] string returnUrl)
        {
            var redirectUri = returnUrl is null ? Url.Content("~/") : "/" + returnUrl;

            if (User.Identity.IsAuthenticated)
            {
                return LocalRedirect(redirectUri);
            }

            return Challenge();
        }

        // this is the method the Logout button should get when clicked
        [HttpGet("Logout")]
        public async Task<ActionResult> Logout([FromQuery] string returnUrl)
        {
            var redirectUri = returnUrl is null ? Url.Content("~/") : "/" + returnUrl;

            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect(redirectUri);
            }

            await HttpContext.SignOutAsync();

            return LocalRedirect(redirectUri);
        }
    }
}

