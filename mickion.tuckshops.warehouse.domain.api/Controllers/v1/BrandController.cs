using MediatR;
using mickion.tuckshops.warehouse.application.Features.Brands.Queries;
using mickion.tuckshops.warehouse.application.Features.Brands.Queries.Get;
using mickion.tuckshops.warehouse.application.Features.Brands.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace mickion.tuckshops.warehouse.api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BrandController (ISender mediatr) : ControllerBase
    {

        [HttpGet(Name = "Brands")]
        public async Task<IResult> GetAsync()
        {
            var brand = await mediatr.Send(new ListBrandsQuery());
            if (brand == null) return Results.NotFound();
            return Results.Ok(brand);
        }
    }
}
