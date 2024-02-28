using SocialWebModel;
using SocialWebModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWebServices.Services.MenuService
{
    public class MenuService:IMenuService
    {
        private readonly AppDbContext _appDbContext;
        public MenuService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //GetALl
        public List<Menu> GetAll()
        {
            var list = _appDbContext.menu.ToList();
            return list;
        }
        //Read
        public Menu GetById(long id) {
            var res = _appDbContext.menu.FirstOrDefault(x => x.Id == id);
            if(res != null)
            {
            return res;
            }
            else {
                throw new Exception();
            }
        }
        //Create
        public void Create(Menu menu)
        {
            _appDbContext.menu.Add(menu);
            _appDbContext.SaveChanges();
        }
        //Update
        public void UpdateMenu(Menu menu)
        {
            var updateMenu = _appDbContext.menu.FirstOrDefault(x=>x.Id == menu.Id);
            if(updateMenu != null)
            {
                updateMenu.Name = menu.Name;
                updateMenu.Description = menu.Description;
                updateMenu.Icon = menu.Icon;
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
        //Delete
        public void DeleteMenu(long id) {
            _appDbContext.menu.Remove(GetById(id));
            _appDbContext.SaveChanges();

        }
    }
}
