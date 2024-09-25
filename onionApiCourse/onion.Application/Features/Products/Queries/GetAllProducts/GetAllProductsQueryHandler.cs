using MediatR;
using Microsoft.EntityFrameworkCore;
using onion.Application.DTOs;
using onion.Application.Features.Product.Queries.GetAllProducts;
using onion.Application.Interface.AutoMapper;
using onion.Application.Interface.UnitOfWorks;
using onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace onion.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<onion.Domain.Entities.Product>().GetAllAsync(include : x=> x.Include(b=>b.Brand));
            
            var brand = mapper.Map<BrandDTO, Brand>(new Brand());
            var map = mapper.Map<GetAllProductsQueryResponse, onion.Domain.Entities.Product>(products);
            foreach(var item in map)
            {
                item.Price -= (item.Price * item.Discount /100 );
            }

            return map;
            
        }
    }
}
