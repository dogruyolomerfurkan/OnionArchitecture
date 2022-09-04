using Application.Repositories;
using CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules
{
    private readonly IReadRepository<Brand> _readRepository;

    public BrandBusinessRules(IReadRepository<Brand> readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task BrandNameCannotBeDuplicatedWhenInserted(string brandName)
    {
        var brandNameExist = await _readRepository.Entity.AnyAsync(p => p.Name.ToLower() == brandName.ToLower());
        if (brandNameExist) throw new BusinessException($"{brandName} already exist");
    }
}
