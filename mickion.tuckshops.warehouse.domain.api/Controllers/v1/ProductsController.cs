
using MediatR;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using mickion.tuckshops.shared.application.Messages;
using mickion.tuckshops.warehouse.application.Features.Product.Queries.List;
using mickion.tuckshops.warehouse.application.Features.Product.Commands.Create;

namespace mickion.tuckshops.warehouse.api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")] // TODO: Remove from payload??
    //[Route("api/v{version:apiVersion}/[Controller]")]
    public class ProductsController(ISender mediatr) : ControllerBase
    {
        [HttpGet]
        [Route("products")]
        public async Task<IResult> GetAsync()
        {
            var brands = await mediatr.Send(new ListProductsQuery());
            return (brands is not null) ? Results.Ok(brands) : Results.NotFound(ValidationMessage.PRODUCTS_NOTFOUND);
        }

        [HttpPost]
        [Route("products")]
        public async Task<IResult> PostAsync(CreateProductCommand createProductCommand)
        {
            var brand = await mediatr.Send(createProductCommand);
            return (brand is not null) ? Results.Ok(brand) : Results.BadRequest(ErrorMessage.FAILED_TO_CREATE_PRODUCT);
        }
    }
}
