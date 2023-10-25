using Data.Base;
using Data.DTOs;
using Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Front.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private TokenService _tokenService;


        public RegisterController(IHttpClientFactory httpClientFactory, TokenService tokenService)
        {
            _httpClientFactory = httpClientFactory;
            _tokenService = tokenService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                var baseAPI = new BaseAPI(_httpClientFactory);
                var token = await baseAPI.PostToAPI("User/AddFullUser", registerDTO);

                var objectToken = token as OkObjectResult;

                _tokenService.SetToken(objectToken.Value.ToString());

                return View("Views/Home/Index.cshtml");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
