﻿using MediatR;
using mickion.tuckshops.warehouse.domain.Entities;

namespace mickion.tuckshops.warehouse.application.Features.Product.Commands.Create;

public record CreateProductCommand(
    string Name,
    string Color,
    string Barcode,
    DateTime ExpiryDateTime,
    DateTime UseByDateTime,
    BrandDto Brand,
    Measurement Measurements,
    Quantity Quantity
) : IRequest<CreateProductCommandResponse>;

#warning Create Measurement & Quantity DTO's
