using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWebModel
{
    public class ResignDTO
    {
        [Required(ErrorMessage ="UserName not right!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email not right!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not right!")]
        public string Password { get; set; }
    }
}
