using MediatR;

namespace UdemyJwt.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateProductCommandRequest : IRequest
    {

        public string? Name { get; set; }
        public int Stcak { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
