using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    public  class OrderDto : BaseDto
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
        public string? Email { get; set; }
        public string? NameDescription { get; set; }
        public decimal Price { get; set; }
    }
}
