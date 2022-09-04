using Application.Features.Brands.Rules;
using Application.Repositories;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandRequest, CreateBrandResponse>
{
    private readonly IWriteRepository<Brand> _writeRepository;
    private readonly BrandBusinessRules _brandBusinessRules;

    public CreateBrandCommandHandler(IWriteRepository<Brand> writeRepository, BrandBusinessRules brandBusinessRules)
    {
        _writeRepository = writeRepository;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<CreateBrandResponse> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
    {
        await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

        var newBrand = request.Adapt<Brand>();

        await _writeRepository.AddAsync(newBrand);

        var result = await _writeRepository.SaveAsync();

        return result > 0 ? newBrand.Adapt<CreateBrandResponse>() : new();
    }
}
