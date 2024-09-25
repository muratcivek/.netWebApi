using onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {

        }

        public Category(int parentId, string name, int priorty)
        {
            parentId = parentId;
            Name = name;
            Priorty = priorty;
        }


        public  int parentId { get; set; }
        public  String Name { get; set; }
        public  int Priorty { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }


    }
}
