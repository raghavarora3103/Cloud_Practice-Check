using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {

        private static List<MenuItem> list = new List<MenuItem>() {
                new MenuItem(){
                    Id=1,
                    Name ="apples",
                    Active = true,
                    freeDelivery = true,
                    Price =12.1,
                    Datetime = new DateTime(),
                },
                new MenuItem(){
                    Id=2,
                    Name ="oranges",
                    Active = true,
                    freeDelivery = true,
                    Price =13.1,
                    Datetime = new DateTime(),
                },
                new MenuItem(){
                    Id=3,
                    Name ="grapes",
                    Active = true,
                    freeDelivery = true,
                    Price =13.1,
                    Datetime = new DateTime(),
                }
            };


        //https://localhost:44337/api/MenuItem/GetMenuItems
        [HttpGet]
        [Route("~/api/MenuItem")]
        public IActionResult GetMenuItems()
        {
            var res = MenuItemController.list;
            return Ok(res);    
        }


        [HttpGet]
        [Route("~/api/MenuItem/{id:int}")]
        public IActionResult GetMenuItems(int id) {
            MenuItem menuItem = new MenuItem();
            foreach(var x in MenuItemController.list) {
                if (x.Id == id) 
                {
                    menuItem = x;
                    break;
                }
            }
            return Ok(menuItem);
        }
    }
}
