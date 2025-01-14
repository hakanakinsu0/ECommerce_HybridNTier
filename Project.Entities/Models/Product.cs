using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int? CategoryId { get; set; }

        //Relational Properties

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
