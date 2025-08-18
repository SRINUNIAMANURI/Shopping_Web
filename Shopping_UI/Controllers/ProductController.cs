using Microsoft.AspNetCore.Mvc;
using Shopping_UI.Models.DTO_s;
using Shopping_UI.Models.DTO_s.InputDto;
using System.Text;
using System.Text.Json;

namespace Shopping_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductDto> response = new List<ProductDto>();

            try
            {
                
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7297/api/Product");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>());
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductInputDto model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/Json"),
                RequestUri = new Uri("https://localhost:7297/api/Product"),
            };

            var httpResponceMessage = await client.SendAsync(httpRequestMessage);

            httpResponceMessage.EnsureSuccessStatusCode();

            var responce = httpResponceMessage.Content.ReadFromJsonAsync<ProductDto>();

            if (responce is not null)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var client = httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<ProductDto>($"https://localhost:7297/api/Product/{Id.ToString()}");

            if (response is not null)
            {
                return View(response);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto request)
        {
            var client = httpClientFactory.CreateClient();

            var httpmessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7297/api/Product"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "Application/Json")
            };

            var httpMessageResponse = await client.SendAsync(httpmessage);

            httpMessageResponse.EnsureSuccessStatusCode();

            if (httpMessageResponse.IsSuccessStatusCode == true)
            {
                return RedirectToAction("Index", "Product");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7297/api/Product/{Id.ToString()}");

                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                // Console
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
