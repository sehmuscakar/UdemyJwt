using AutoMapper;
using MediatR;
using UdemyJwt.Back.Core.Application.Dto;
using UdemyJwt.Back.Core.Application.Features.CQRS.Queries;
using UdemyJwt.Back.Core.Application.Interfaces;
using UdemyJwt.Back.Core.Domain;

namespace UdemyJwt.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {

        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;
        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<ProductListDto>>(data);
        }
    }
}
