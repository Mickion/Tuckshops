using MediatR;
using mickion.tuckshops.shared.application.Helpers.Responses.Handlers;
using mickion.tuckshops.warehouse.application.Helpers;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.Extensions.Logging;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Queries.List
{
    public class ListBrandsQueryHandler (
        ILogger<ListBrandsQueryHandler> logger, IUnitOfWork unitOfWork): IRequestHandler<ListBrandsQuery, ListBrandsQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly ILogger<ListBrandsQueryHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<ListBrandsQueryResponse> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            IEnumerable<Brand>? response = null;
            try
            {
                response = [.. _unitOfWork.BrandRepository.GetAll()];
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Fluent Validator failed: " + ex.Message, ex);
                return ResponseHelper<ListBrandsQueryResponse, IEnumerable<BrandDto>>.Error(MapHelper.BrandToDto(response!)!, ex.Message);
            }

            return ResponseHelper<ListBrandsQueryResponse, IEnumerable<BrandDto>>.Success(MapHelper.BrandToDto(response)!);
        }
    }
}
