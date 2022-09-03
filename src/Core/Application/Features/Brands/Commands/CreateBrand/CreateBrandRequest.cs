using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandRequest : IRequest<CreateBrandResponse>
{
    public string? Name { get; set; }
}
