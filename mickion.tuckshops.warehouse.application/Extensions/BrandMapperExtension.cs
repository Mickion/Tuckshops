using mickion.tuckshops.warehouse.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mickion.tuckshops.warehouse.application.Extensions
{
    internal static class BrandMapperExtension
    {
        internal static BrandDto ToBrandDto(this Brand brand)
        {
            if (brand == null) return null;

            return new(
                brand.Id,
                brand.Name,
                brand.Address,
                brand.CreatedDate,
                brand.CreatedByUserId,
                brand.ModifiedDate,
                brand.ModifiedByUserId);
        }

        internal static IEnumerable<BrandDto?> ToBrandDto(this IEnumerable<Brand> brands)
        {
            List<BrandDto?> brandsDto = [];
            foreach (var brand in brands)
            {
                brandsDto.Add(ToBrandDto(brand));
            }

            return brandsDto;
        }
    }
}
