using MediatR;
using UdemyJwt.Back.Core.Application.Features.CQRS.Commands;
using UdemyJwt.Back.Core.Application.Interfaces;
using UdemyJwt.Back.Core.Domain;

namespace UdemyJwt.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new Product
            {
                CategoryId = request.CategoryId,
                Name= request.Name,
                Price= request.Price,
                Stcak= request.Stcak,
            });
            return Unit.Value;
        }
    }
}
