using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    public class AppUserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid ActivationCode { get; set; }
    }
}
