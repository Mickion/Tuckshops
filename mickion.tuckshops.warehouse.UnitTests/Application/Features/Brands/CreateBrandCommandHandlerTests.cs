using mickion.tuckshops.shared.application.Exceptions;
using mickion.tuckshops.shared.domain.Exceptions;
using mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using Moq;

namespace mickion.tuckshops.warehouse.UnitTests.Application.Features.Brands
{
    public class CreateBrandCommandHandlerTests
    {
        private CreateBrandCommandHandler? _handler = null;
        private readonly CancellationToken _cancellationToken = new();        
        private readonly Mock<ILogger<CreateBrandCommandHandler>> _logger = new();          
        private readonly Mock<IUnitOfWork> _unitOfWork = new();
        private readonly Mock<WarehouseDbContext> _warehouseDbContext = new();

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ThrowArgumentNullException_WhenUnitOfWorkIsNullAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object);

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await _handler.Handle(null, _cancellationToken));

            Console.WriteLine(nameof(exception));
            // Assert
            Assert.Equal(nameof(exception), "exception");
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ThrowArgumentNullException_WhenLoggerIsNullAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object);

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await _handler.Handle(null, _cancellationToken));

            Console.WriteLine(nameof(exception));
            // Assert
            Assert.Equal(nameof(exception), "exception");
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ThrowExceptionArgumentNullException_WhenRequestIsNullAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object);

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await _handler.Handle(null, _cancellationToken));

            // Assert
            Assert.Equal(nameof(exception), "exception");
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ThrowFieldRequiredException_WhenBrandNameIsNullOrEmpyAsync()         
        {
            // Arrange 
            CreateBrandCommand command = new(" ", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object);

            // Act
            var exception = await Assert.ThrowsAsync<FieldRequiredException>(async () => await _handler.Handle(command, _cancellationToken));

            // Assert
            Assert.Equal(nameof(exception), "exception");
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ThrowFieldRequiredException_WhenBrandAddressIsNullOrEmptyAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", null);
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object);

            // Act
            var exception = await Assert.ThrowsAsync<FieldRequiredException>(async () => await _handler.Handle(command, _cancellationToken));

            // Assert
            Assert.Equal(nameof(exception), "exception");
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ReturnResponseWithId_WhenSuccessfullToAddBrandAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object);
            _unitOfWork.Setup(unitOfWork => unitOfWork.BrandRepository.Add(It.IsAny<Brand>()))
                .Returns(new Brand { Name= "Sasko", Address= "Sasko Building", CreatedDate=DateTime.Now, CreatedByUserId=new Guid()});

            _unitOfWork.Setup(uof => uof.CommitChangesAsync(_cancellationToken));

            // Act
            CreateBrandResponse response = await _handler.Handle(command, _cancellationToken);

            // Assert

            //// Check that each method was only called once.
            //_unitOfWork.Verify(x => x.BrandRepository.Add(It.IsAny<Brand>()), Times.Once());
            //_unitOfWork.Verify(x => x.CommitChangesAsync(_cancellationToken), Times.Once());

            Assert.NotNull(response);
            Assert.Multiple(() =>
            {
                Assert.Equal(command.Name, response.Name);
                Assert.Equal(command.Address, response.Address);
                Assert.NotNull(response.Id);
                Assert.NotNull(response.CreatedDate);
                Assert.NotNull(response.CreatedByUserId);
            });
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ReturnNullAuditValues_WhenFailedToAddBrandAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object);
            // We are testing the "Add" functionality of the BrandRepository. EFCore may return an error & fail to save
            _unitOfWork.Setup(unitOfWork => unitOfWork.BrandRepository.Add(It.IsAny<Brand>())).Returns(new Brand());                

            // Act
            CreateBrandResponse response = await _handler.Handle(command, _cancellationToken);

            // Assert
            Assert.NotNull(response);
            Assert.Multiple(() =>
            {                
                Assert.Null(response.CreatedDate);
                Assert.Null(response.CreatedByUserId);
            });
        }
        
        [Fact]
        public async Task CreateBrandCommandHandler_Should_ReturnEntityFrameworkException_WhenFailedToAddBrandAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object);
            // We are testing the "Add" functionality of the BrandRepository. EFCore may return an error & fail to save
            _unitOfWork.Setup(unitOfWork => unitOfWork.BrandRepository.Add(It.IsAny<Brand>()))
                .Throws(new EntityFrameworkException("EF Core failed to save"));

            // Act
            var exception = await Assert.ThrowsAsync<EntityFrameworkException>(async () => await _handler.Handle(command, _cancellationToken));            

            // Assert
            Assert.Equal(nameof(exception), "exception");

        }

    }
}
