using Application.Features.Brands.Commands.CreateBrand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBrandRequest createBrandRequest)
        {
            var response = await _mediator.Send(createBrandRequest);
            return Ok(response);
        }
    }
}
