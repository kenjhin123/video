using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialWebModel.Entity;
using SocialWebModel.OtherO;
using SocialWebServices.Services.MenuService;

namespace SocialWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;
        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        [HttpGet]
        [Authorize(Roles = StaticRole.USER)]
        public ActionResult GetAll()
        {
            var menu = menuService.GetAll();
            return Ok(menu);
        }
        [HttpGet("GetbyId")]
        public ActionResult GetId(long id) {
            var menu = menuService.GetById(id);
            return Ok(menu);
        }
        [HttpPost]
        [Authorize(Roles = StaticRole.ADMIN)]
        public IActionResult CreateMenu(Menu menu)
        {
            menuService.Create(menu);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMenu(Menu menu)
        {
            menuService.UpdateMenu(menu);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteMenu(long id)
        {
            menuService.DeleteMenu(id);
            return Ok();
        }
    }
}
