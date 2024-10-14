using MediatR;
using mickion.tuckshops.shared.application.Exceptions;
using mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;
using Moq;
using System.Threading;

namespace mickion.tuckshops.warehouse.UnitTests.Application.Features.Brands
{
    public class CreateBrandCommandHandlerTests
    {
        //private Mock<IMediator> _mediator;
        private CancellationToken _cancellationToken;
        private CreateBrandCommandHandler _handler;

        public CreateBrandCommandHandlerTests()
        {
            _handler = new CreateBrandCommandHandler();
            _cancellationToken = new System.Threading.CancellationToken();
        }

        #region Validation tests
        [Fact]
        public async Task CreateBrandCommandHandler_RequestNull_ShouldThrowExceptionArgumentNullExceptionAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            
            // Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await _handler.Handle(null, _cancellationToken));

            Console.WriteLine(nameof(exception));
            // Assert
            Assert.Equal(nameof(exception), "exception");
        }

        [Fact]
        public async Task CreateBrandCommandHandler_BrandNameNullOrEmpty_ShouldThrowFieldRequiredExceptionExceptionAsync()
        {
            // Arrange 
            CreateBrandCommand command = new(" ", "Sasko Building");            

            // Act
            var exception = await Assert.ThrowsAsync<FieldRequiredException>(async () => await _handler.Handle(command, _cancellationToken));

            // Assert
            Assert.Equal(nameof(exception), "exception");
        }

        [Fact]
        public async Task CreateBrandCommandHandler_AddressNullOrEmpty_ShouldThrowFieldRequiredExceptionExceptionAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", null);

            // Act
            var exception = await Assert.ThrowsAsync<FieldRequiredException>(async () => await _handler.Handle(command, _cancellationToken));

            // Assert
            Assert.Equal(nameof(exception), "exception");
        }
        #endregion

        #region Business Logic tests

        [Fact]
        public async Task CreateBrandCommandHandler_IfSuccessfull_ShouldReturnNoneNullResponseAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            CreateBrandCommandHandler handler = new CreateBrandCommandHandler();

            // Act
            CreateBrandResponse response = await _handler.Handle(command, _cancellationToken);

            // Assert
            Assert.NotNull(response);
        }
        #endregion

        #region Private methods
        

        #endregion
    }
}
