using Microsoft.AspNetCore.Mvc;
using Shopping_UI.Models;
using System.Net.Http;

namespace Shopping_UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AddressController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        //[HttpGet]
        //public async Task<IActionResult> Index(int customerid)
        //{
        //    var client = httpClientFactory.CreateClient();

        //    var response = await client.GetFromJsonAsync<AddressDto>($"https://localhost:7297/api/Address/{customerid.ToString()}");

        //    if (response is not null)
        //    {
        //        return View(response);
        //    }
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Index(int customerid)
        {
            List<AddressDto> response = new List<AddressDto>();

            try
            {

                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync($"https://localhost:7297/api/Address/{customerid}");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<AddressDto>>());
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return View(response);
        }
    }
}
