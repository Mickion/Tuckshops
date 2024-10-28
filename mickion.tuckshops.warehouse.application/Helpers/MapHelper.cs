
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

namespace mickion.tuckshops.warehouse.application.Helpers
{
    internal static class MapHelper
    {
        #region Brand mapping methods
        internal static Brand DtoToBrand(BrandDto request) => new() { Name = request.Name, Address = request.Address };

        internal static BrandDto? BrandToDto(Brand? brand) =>
           brand == null? null : new(brand.Id, brand.Name, brand.Address, brand.CreatedDate, brand.CreatedByUserId, brand.ModifiedDate, brand.ModifiedByUserId);

        internal static IEnumerable<BrandDto?> BrandToDto(IEnumerable<Brand> brands)
        {
            List<BrandDto?> brandsDto = [];
            foreach (var brand in brands) { 
                brandsDto.Add(BrandToDto(brand));
            }

            return brandsDto;
        }

        #endregion

        #region Product mapping methods
        internal static ProductDto? ProductToDto(Product? product) {
            if (product == null) return null;

            return new ProductDto(
                product.Id, 
                product.Name, 
                product.Color,
                product.Barcode, 
                product.ExpiryDateTime,
                product.UseByDateTime, 
                BrandToDto(product.Brand), 
                product.Measurements, 
                product.Quantity, 
                product.CreatedDate, 
                product.CreatedByUserId, 
                product.ModifiedDate, 
                product.ModifiedByUserId
            );   
        }
        #endregion
    }

}
