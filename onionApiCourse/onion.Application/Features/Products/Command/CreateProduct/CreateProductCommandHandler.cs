using MediatR;
using Microsoft.AspNetCore.Http;
using onion.Application.Bases;
using onion.Application.Features.Products.Rules;
using onion.Application.Interface.AutoMapper;
using onion.Application.Interface.UnitOfWorks;
using onion.Domain.Entities;

namespace onion.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
           IList<onion.Domain.Entities.Product> products = await unitOfWork.GetReadRepository<onion.Domain.Entities.Product>().GetAllAsync();

           await productRules.ProductTitleMustNotBeSame(products, request.Title);



           onion.Domain.Entities.Product product = new(request.Title,request.Description,request.BrandId,request.Price,request.Discount);

           await unitOfWork.GetWriteRepository<onion.Domain.Entities.Product>().AddAsync(product);


            
                 
          if (await unitOfWork.SaveAsync()>0)
            {
              foreach (var categoryId in request.CategoryIds)
              {
                        await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory()
                        {
                            ProductId = product.Id,
                            CategoryId = categoryId
                        });

              }

              await unitOfWork.SaveAsync();
            }


            return Unit.Value;
        }
    }
}
