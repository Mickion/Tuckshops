
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

namespace mickion.tuckshops.warehouse.application.Helpers
{
    internal static class MapHelper
    {
        #region Brand mapping methods
        internal static Brand DtoToBrand(CreateBrandCommand request) => new() { Name = request.Name, Address = request.Address };

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
    }

}
