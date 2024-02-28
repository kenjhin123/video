using SocialWebModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWebServices.Services.TestService
{
    public interface ITestService
    {
        public List<Test> GetAll();
    }
}
