using Data.Base;
using Data.DTOs;
using Data.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace Front.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private TokenService _tokenService;

        public LoginController(IHttpClientFactory httpClientFactory, TokenService tokenService)
        {
            _httpClientFactory = httpClientFactory;
            _tokenService = tokenService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginDTO login)
        {
            try
            {
                var baseAPI = new BaseAPI(_httpClientFactory);
                var token = await baseAPI.PostToAPI("Login", login);

                var objectToken = token as OkObjectResult;

                _tokenService.SetToken(objectToken.Value.ToString()); //Storages the token in a class.

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //Since objectToken only has the token, its not mandatory to create multiple claimtypes.
                var mainClaim = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, mainClaim, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddDays(30) //Too long in order to avoid problems.
                });

                return View("Views/Home/Index.cshtml");
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "login");
        }
    }
}
