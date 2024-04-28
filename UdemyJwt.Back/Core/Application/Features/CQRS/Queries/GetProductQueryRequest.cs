using MediatR;
using UdemyJwt.Back.Core.Application.Dto;

namespace UdemyJwt.Back.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest:IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetProductQueryRequest(int id)
        {
            Id= id;
        }

    }
}
