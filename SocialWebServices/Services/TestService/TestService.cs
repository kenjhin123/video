
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialWebModel;
using SocialWebModel.Entity;

namespace SocialWebServices.Services.TestService
{
    public class TestService:ITestService
    {
        private readonly AppDbContext _context;
        public TestService(AppDbContext context)
        {
            _context = context;
        }
        public List<Test> GetAll()
        {
            return _context.tests.ToList();
        }
    }
}
