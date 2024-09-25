using MediatR;
using Microsoft.AspNetCore.Http;
using onion.Application.Bases;
using onion.Application.Interface.AutoMapper;
using onion.Application.Interface.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler :BaseHandler, IRequestHandler<DeleteProductCommandRequest,Unit>
    {
        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }


        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            
                var product = await unitOfWork.GetReadRepository<onion.Domain.Entities.Product>().GetAsync(x => x.Id == request.Id && x.IsDeleted ==false);

               
                product.IsDeleted = true;
                await unitOfWork.GetWriteRepository<onion.Domain.Entities.Product>().UpdateAsync(product);
                await unitOfWork.SaveAsync();

            return Unit.Value;

        }
    }
}
