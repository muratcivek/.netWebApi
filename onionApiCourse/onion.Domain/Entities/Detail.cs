using onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Domain.Entities
{
    public class Detail : EntityBase
    {
        public Detail()
        {
        }

        public Detail(string title, string description, int categoryId)
        {
            this.title = title;
            Description = description;
            CategoryId = categoryId;
        }

        public  string title { get; set; }

        public  string Description { get; set; }
        public  int CategoryId { get; set; }
        public  Category Category { get; set; }
    }
}
