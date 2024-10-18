
using MediatR;
using Asp.Versioning;
using mickion.tuckshops.shared.application.Messages;
using mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;
using mickion.tuckshops.warehouse.application.Features.Brands.Queries.List;
using Microsoft.AspNetCore.Mvc;
using mickion.tuckshops.warehouse.domain.Entities;

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
            var brands = await mediatr.Send(new ListBrandsQuery());
            return (brands is not null) ? Results.Ok(brands) : Results.NotFound(ValidationMessage.BRANDS_NOTFOUND);            
        }

        [HttpPost]
        [Route("brand")]
        public async Task<IResult> PostAsync(string brandName, string brandAddress)
        {            
            var brand = await mediatr.Send(new CreateBrandCommand(brandName, brandAddress));
            return (brand is not null) ? Results.Ok(brand) : Results.BadRequest(ErrorMessage.FAILED_TO_CREATE_BRAND); 
        }
    }
}
