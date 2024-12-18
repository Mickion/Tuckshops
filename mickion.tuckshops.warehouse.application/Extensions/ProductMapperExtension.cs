﻿using mickion.tuckshops.warehouse.domain.Entities;

namespace mickion.tuckshops.warehouse.application.Extensions
{
    internal static class ProductMapperExtension
    {
        internal static ProductDto ToProductDto(this Product product)
        {
            if (product is null) return null;

            return new(
                product.Id,
                product.Name,
                product.Color,
                product.Description,
                product.Brand.ToBrandDto(),
                product.Measurements,
                //product.Quantity,
                product.CreatedDate,
                product.CreatedByUserId,
                product.ModifiedDate,
                product.ModifiedByUserId
            );
        }

        internal static IEnumerable<ProductDto?> ToProductDto(this IEnumerable<Product> products)
        {
            List<ProductDto?> productsDto = [];
            foreach (var product in products)
            {
                productsDto.Add(ToProductDto(product));
            }

            return productsDto;
        }
    }
}
