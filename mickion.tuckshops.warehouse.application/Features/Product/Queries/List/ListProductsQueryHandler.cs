using MediatR;
using mickion.tuckshops.shared.application.Helpers.Responses.Handlers;
using mickion.tuckshops.warehouse.application.Extensions;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.application.Features.Product.Queries.List
{
    public class ListProductsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<ListProductsQuery, ListProductsQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        #region public methods
        public async Task<ListProductsQueryResponse> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            return await this.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Private implementation details
        private async Task<ListProductsQueryResponse> HandleAsync(ListProductsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
#warning Implement redis cache
            IEnumerable<domain.Entities.Product>? response = [.. _unitOfWork.ProductRepository.GetAll(true)];

            return ResponseHelper<ListProductsQueryResponse, IEnumerable<ProductDto>>.Success(response.ToProductDto());
        }
        #endregion
    }
}
