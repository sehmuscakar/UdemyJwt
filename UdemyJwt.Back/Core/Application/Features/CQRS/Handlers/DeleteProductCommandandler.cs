using MediatR;
using UdemyJwt.Back.Core.Application.Features.CQRS.Commands;
using UdemyJwt.Back.Core.Application.Interfaces;
using UdemyJwt.Back.Core.Domain;

namespace UdemyJwt.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IRepository<Product> repository;
        public DeleteProductCommandandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteEntity = await this.repository.GetByIdAsync(request.Id);
            if (deleteEntity !=null)
            {
                await this.repository.RemoveAsync(deleteEntity);
            }
            return Unit.Value;
        }
    }
}
