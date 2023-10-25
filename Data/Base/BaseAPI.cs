using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Data.Base
{
    public class BaseAPI : ControllerBase
    {
        private readonly IHttpClientFactory _hhtpClient;

        public BaseAPI(IHttpClientFactory hhtpClient) 
        {
            _hhtpClient = hhtpClient;
        }


        public async Task<IActionResult> PostToAPI(string controllerName, object model, string token = "")
        {
            try
            {
                var client = _hhtpClient.CreateClient("useAPI");

                if (!string.IsNullOrEmpty(token)) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                var response = await client.PostAsJsonAsync(controllerName, model);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }

                return Unauthorized();
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public async Task<IActionResult> PutToAPI(string controllerName, object model, string token = "")
        {
            try
            {
                var client = _hhtpClient.CreateClient("useAPI");

                if (!string.IsNullOrEmpty(token)) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                var response = await client.PutAsJsonAsync(controllerName, model);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }

                return Unauthorized();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
