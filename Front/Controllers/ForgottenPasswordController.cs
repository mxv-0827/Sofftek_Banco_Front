﻿using Data.Base;
using Data.DTOs;
using Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Front.Controllers
{
    public class ForgottenPasswordController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private TokenService _tokenService;


        public ForgottenPasswordController(IHttpClientFactory httpClientFactory, TokenService tokenService)
        {
            _httpClientFactory = httpClientFactory;
            _tokenService = tokenService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpdatePassword(ConfirmPasswordDTO confirmPasswordDTO)
        {
            try
            {
                if (confirmPasswordDTO.NewPassword != confirmPasswordDTO.ConfirmNewPassword) throw new Exception("Make sure both introduced passwords are equal.");

                UpdatePasswordDTO updatePasswordDTO = new UpdatePasswordDTO
                {
                    Email = confirmPasswordDTO.Email,
                    NewPassword = confirmPasswordDTO.NewPassword
                };

                var baseAPI = new BaseAPI(_httpClientFactory);
                var token = await baseAPI.PutToAPI("Credentials/UpdatePassword", updatePasswordDTO);

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
