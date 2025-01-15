using Project.Dal.ContextClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Concretes
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(MyContext context) : base(context)
        {

        }
    }
}
