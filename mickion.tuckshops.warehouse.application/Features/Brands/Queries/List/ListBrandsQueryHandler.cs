using MediatR;
using mickion.tuckshops.shared.application.Helpers.Responses.Handlers;
using mickion.tuckshops.warehouse.application.Extensions;
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

        #region public methods
        public async Task<ListBrandsQueryResponse> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
        {            
            return await this.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Private implementation details
        private async Task<ListBrandsQueryResponse> HandleAsync(ListBrandsQuery request, CancellationToken cancellationToken)
        {

#warning Implement redis cache
            ArgumentNullException.ThrowIfNull(request);
            IEnumerable<Brand>? response = [.. _unitOfWork.BrandRepository.GetAll(true)];

            return ResponseHelper<ListBrandsQueryResponse, IEnumerable<BrandDto>>.Success(response.ToBrandDto()!);
        }
        #endregion
    }
}
