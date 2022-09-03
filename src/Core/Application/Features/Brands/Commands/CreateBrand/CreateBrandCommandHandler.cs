using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandRequest, CreateBrandResponse>
{
    private readonly IWriteRepository<Brand> _writeRepository;

    public CreateBrandCommandHandler(IWriteRepository<Brand> writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<CreateBrandResponse> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
    {
        var newBrand = request.Adapt<Brand>();

        await _writeRepository.AddAsync(newBrand);

        var result = await _writeRepository.SaveAsync();

        return result > 0 ? newBrand.Adapt<CreateBrandResponse>() : new();
    }
}
