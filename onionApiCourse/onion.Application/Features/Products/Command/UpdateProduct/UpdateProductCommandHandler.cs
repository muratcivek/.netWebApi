﻿using MediatR;
using Microsoft.AspNetCore.Http;
using onion.Application.Bases;
using onion.Application.Interface.AutoMapper;
using onion.Application.Interface.UnitOfWorks;
using onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler :BaseHandler, IRequestHandler<UpdateProductCommandRequest,Unit>
    {

        
        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
         
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            
                var product = await unitOfWork.GetReadRepository<onion.Domain.Entities.Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

                var map = mapper.Map<onion.Domain.Entities.Product, UpdateProductCommandRequest>(request);

                var productCategories = await unitOfWork.GetReadRepository<ProductCategory>()
                    .GetAllAsync(x => x.ProductId == product.Id);

                await unitOfWork.GetWriteRepository<ProductCategory>()
                    .HardDeleteRangeAsync(productCategories);

                foreach (var categoryId in request.CategoryIds)
                    await unitOfWork.GetWriteRepository<ProductCategory>()
                        .AddAsync(new() { CategoryId = categoryId, ProductId = product.Id });

                await unitOfWork.GetWriteRepository<onion.Domain.Entities.Product>().UpdateAsync(map);
                await unitOfWork.SaveAsync();

            return Unit.Value;

        }
    }
}
