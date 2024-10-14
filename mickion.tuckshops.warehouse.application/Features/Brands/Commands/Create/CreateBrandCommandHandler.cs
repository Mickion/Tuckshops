using MediatR;
using mickion.tuckshops.shared.application.Exceptions;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
{
    public Task<CreateBrandResponse> Handle(CreateBrandCommand? request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (string.IsNullOrWhiteSpace(request.Name)) throw new FieldRequiredException(nameof(request.Name));
        if (string.IsNullOrWhiteSpace(request.Address)) throw new FieldRequiredException(nameof(request.Address));


        return null;
    }
}
