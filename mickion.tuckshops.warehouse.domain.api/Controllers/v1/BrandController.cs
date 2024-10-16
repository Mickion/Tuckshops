using Asp.Versioning;
using MediatR;
using mickion.tuckshops.shared.application.Messages;
using mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;
using mickion.tuckshops.warehouse.application.Features.Brands.Queries;
using mickion.tuckshops.warehouse.application.Features.Brands.Queries.Get;
using mickion.tuckshops.warehouse.application.Features.Brands.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace mickion.tuckshops.warehouse.api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")] // TODO: Remove from payload??
    //[Route("api/v{version:apiVersion}/[Controller]")]
    public class BrandController (ISender mediatr) : ControllerBase
    {
        
        [HttpGet]
        [Route("brands")]
        public async Task<IResult> GetAsync()
        {
            var brand = await mediatr.Send(new ListBrandsQuery());
            if (brand == null) return Results.NotFound();
            return Results.Ok(brand);
        }

        [HttpPost]
        [Route("brand")]
        public async Task<IResult> PostAsync(string brandName, string brandAddress)
        {
            // TODO: FluentValidation
            var brand = await mediatr.Send(new CreateBrandCommand(brandName, brandAddress));
            return (brand is not null) ? Results.Ok(brand) : Results.BadRequest(ErrorMessage.FAILED_TO_CREATE_BRAND); 
        }
    }
}
