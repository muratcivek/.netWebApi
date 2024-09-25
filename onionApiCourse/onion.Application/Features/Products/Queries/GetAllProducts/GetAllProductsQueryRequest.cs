using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
    {

    }
}
