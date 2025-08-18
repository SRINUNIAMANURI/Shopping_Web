using Microsoft.AspNetCore.Mvc;
using Shopping_UI.Models;
using Shopping_UI.Models.DTO_s.InputDto;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Shopping_UI.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IHttpClientFactory httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CustomerDto> response = new List<CustomerDto>();

            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7297/api/Customer");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<CustomerDto>>());
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult>Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Add(CustomerInputDto customerDto)
        {
            var client = httpClientFactory.CreateClient();

            try { 
            var httpRequestMessege = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonSerializer.Serialize(customerDto), Encoding.UTF8, "application/Json"),
                RequestUri = new Uri("https://localhost:7297/api/Customer")
            };

                var httpResponceMessege =  await client.SendAsync(httpRequestMessege);
                httpResponceMessege.EnsureSuccessStatusCode();

                var responce = httpResponceMessege.Content.ReadFromJsonAsync<CustomerDto>();

                if (responce is not null)
                {
                    return RedirectToAction("Index", "Customer");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return View();         
        }

        [HttpGet]

        public async Task<IActionResult>Edit(int id)
        {
            var client = httpClientFactory.CreateClient();

            var responce = await client.GetFromJsonAsync<CustomerDto>($"https://localhost:7297/api/Customer/{id}");

            if(responce is not null)
            {
                return View(responce);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Edit(CustomerDto customerDto)
        {
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpRequestMessege = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    Content = new StringContent(JsonSerializer.Serialize(customerDto), Encoding.UTF8, "Application/Json"),
                    RequestUri = new Uri($"https://localhost:7297/api/Customer")
                };

                var httpResponceMessage = await client.SendAsync(httpRequestMessege);

                httpResponceMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Customer");

            }
            catch (Exception ex)
            {
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7297/api/Customer/{id.ToString()}");

                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Customer");
            }
            catch (Exception ex)
            {
                // Console
            }

            return RedirectToAction("Index", "Customer");
        }
    }
}
