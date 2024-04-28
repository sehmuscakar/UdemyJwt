using MediatR;
using UdemyJwt.Back.Core.Application.Features.CQRS.Commands;
using UdemyJwt.Back.Core.Application.Interfaces;
using UdemyJwt.Back.Core.Domain;

namespace UdemyJwt.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updateProduct = await this.repository.GetByIdAsync(request.Id);
            if (updateProduct != null)
            {
                updateProduct.CategoryId= request.CategoryId;
                updateProduct.Stcak=request.Stcak;
                updateProduct.Price= request.Price;
                updateProduct.Name= request.Name;
                await this.repository.UpdateAsync(updateProduct);
            }
            return Unit.Value;  

        }
    }
}
