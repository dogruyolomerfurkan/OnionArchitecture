using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetListBrand;

public class GetListBrandQueryHandler : IRequestHandler<GetListBrandRequest, GetListBrandResponse>
{
    private readonly IReadRepository<Brand> _readRepository;

    public GetListBrandQueryHandler(IReadRepository<Brand> readRepository)
    {
        _readRepository = readRepository;
    }

    public Task<GetListBrandResponse> Handle(GetListBrandRequest request, CancellationToken cancellationToken)
    {

    }
}
