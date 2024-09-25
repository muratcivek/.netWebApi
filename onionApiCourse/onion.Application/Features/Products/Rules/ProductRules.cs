using onion.Application.Bases;
using onion.Application.Features.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Products.Rules
{
    public  class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<onion.Domain.Entities.Product> products, string requestTitle)
        {
            if (products.Any(x=>x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();

            return Task.CompletedTask;

        }
    }
}
