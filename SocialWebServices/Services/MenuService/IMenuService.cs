using SocialWebModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWebServices.Services.MenuService
{
    public interface IMenuService
    {
        public List<Menu> GetAll();
        public Menu GetById(long id);
        public void Create(Menu menu);
        public void DeleteMenu(long id);
        public void UpdateMenu(Menu menu);



    }
}
