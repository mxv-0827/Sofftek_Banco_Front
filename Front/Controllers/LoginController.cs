using Data.Base;
using Data.DTOs;
using Data.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

                _tokenService.SetToken(objectToken.Value.ToString());

                return View("Views/Home/Index.cshtml");
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
