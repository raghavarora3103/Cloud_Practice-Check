using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private static List<CartItem> cartList;

        public IHttpClientFactory _httpClientFactory;
        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public class MenuItemId
        {
            public int Id{ get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> PutToCart([FromBody] MenuItemId menuItemId) {


            if (menuItemId == null) {
                return NotFound();
            }

            var client  = _httpClientFactory.CreateClient();

            string url = "https://localhost:44337/api/MenuItem/"+ menuItemId.Id;
            var  request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await client.SendAsync(request);

            var jsonString =await  response.Content.ReadAsStringAsync();

            var menuItm = JsonConvert.DeserializeObject<MenuItem>(jsonString);

            CartItem cartItem = new CartItem() { 
                Id = 1,
                MenuItemId = menuItm.Id ,
                MenuItemName = menuItm.Name ,
                UserId = 1,
            }; 

            //Console.WriteLine(x);

            return Ok(cartItem);
        }


    }
}
