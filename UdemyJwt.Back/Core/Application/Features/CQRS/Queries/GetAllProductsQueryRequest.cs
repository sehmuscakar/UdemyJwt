using MediatR;
using UdemyJwt.Back.Core.Application.Dto;

namespace UdemyJwt.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest:IRequest<List<ProductListDto>>
    {

    }
}
