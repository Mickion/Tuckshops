﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Queries.List
{
    public class ListBrandsQuery: IRequest<List<BrandResponse>>
    {
    }
}