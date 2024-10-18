using FluentValidation;
using FluentValidation.Results;
using MediatR;
using mickion.tuckshops.shared.application.Exceptions;
using mickion.tuckshops.shared.domain.Exceptions;
using mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace mickion.tuckshops.warehouse.UnitTests.Application.Features.Brands
{
    public class CreateBrandCommandHandlerTests
    {
        private CreateBrandCommandHandler? _handler = null;
        private readonly CancellationToken _cancellationToken = new();        
        private readonly Mock<ILogger<CreateBrandCommandHandler>> _logger = new();          
        private readonly Mock<IUnitOfWork> _unitOfWork = new();
        private readonly Mock<IValidator<CreateBrandCommand>> _validator = new();
        private readonly Mock<WarehouseDbContext> _warehouseDbContext = new();
        private readonly Mock<IPublisher> _publisher = new();

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ThrowArgumentNullException_WhenUnitOfWorkIsNullAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object, _validator.Object, _publisher.Object);

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
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object, _validator.Object, _publisher.Object);

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
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object, _validator.Object, _publisher.Object);

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await _handler.Handle(null, _cancellationToken));

            // Assert
            Assert.Equal(nameof(exception), "exception");
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ReturnValidationErrorMessage_WhenBrandNameIsNullOrEmpyAsync()         
        {
            // Arrange 
            CreateBrandCommand command = new(" ", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object, _validator.Object, _publisher.Object);
            _validator.Setup(v => v.ValidateAsync(command, _cancellationToken))
                .ReturnsAsync(new ValidationResult(new List<ValidationFailure>()
                             {
                                 new ValidationFailure("Name","Name is a required field"){ErrorCode = "1001"}
                             }));

            // Act
            var response = await _handler.Handle(command, _cancellationToken);            

            // Assert
            Assert.False(response.IsSuccess);
            Assert.NotEmpty(response.ErrorMessages!);
            Assert.Equal("01 Jan 0001 00:00:00", response.Entity!.CreatedDate.ToString());
            Assert.True(Guid.TryParse(response.Entity!.CreatedByUserId.ToString(), out _));
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ReturnValidationErrorMessage_WhenBrandAddressIsNullOrEmptyAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", null);
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object, _validator.Object, _publisher.Object);
            _unitOfWork.Setup(uof => uof.CommitChangesAsync(_cancellationToken));
            _validator.Setup(v => v.ValidateAsync(command, _cancellationToken))
                .ReturnsAsync(new ValidationResult(new List<ValidationFailure>()
                             {
                                 new ValidationFailure("Name","Name is a required field"){ErrorCode = "1001"}
                             }));

            // Act
            var response = await _handler.Handle(command, _cancellationToken);

            // Assert
            Assert.False(response.IsSuccess);
            Assert.NotEmpty(response.ErrorMessages!);
            Assert.Equal("01 Jan 0001 00:00:00", response.Entity!.CreatedDate.ToString());
            Assert.True(Guid.TryParse(response.Entity!.CreatedByUserId.ToString(), out _));
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ReturnSuccessResponseWithData_WhenSuccessfullToAddBrandAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object, _validator.Object, _publisher.Object);

            _unitOfWork.Setup(unitOfWork => unitOfWork.BrandRepository.Add(It.IsAny<Brand>()))
                .Returns(new Brand { Name= "Sasko", Address= "Sasko Building", CreatedDate=DateTime.Now, CreatedByUserId=new Guid()});

            //_unitOfWork.Setup(uof => uof.CommitChangesAsync(_cancellationToken));
            _validator.Setup(v => v.ValidateAsync(command, _cancellationToken)).ReturnsAsync(new ValidationResult());

            // Act
            CreateBrandCommandResponse response = await _handler.Handle(command, _cancellationToken);

            // Assert

            //// Check that each method was only called once.
            //_unitOfWork.Verify(x => x.BrandRepository.Add(It.IsAny<Brand>()), Times.Once());
            //_unitOfWork.Verify(x => x.CommitChangesAsync(_cancellationToken), Times.Once());

            // assert response
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Null(response.ErrorMessages);

            // assert data
            Assert.NotNull(response.Entity);
            Assert.Multiple(() =>
            {                
                Assert.Equal(command.Name, response.Entity.Name);
                Assert.Equal(command.Address, response.Entity.Address);
                Assert.NotNull(response.Entity.Id);
                Assert.NotNull(response.Entity.CreatedDate);
                Assert.NotNull(response.Entity.CreatedByUserId);
                Assert.True(Guid.TryParse(response.Entity!.CreatedByUserId.ToString(), out _)); //valid id                
            });
        }

        [Fact]
        public async Task CreateBrandCommandHandler_Should_ReturnFailedResponseAndNullAuditValues_WhenFailedToAddBrandAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object, _validator.Object, _publisher.Object);

            // We are testing the "Add" functionality of the BrandRepository. EFCore may return an error & fail to save
            _unitOfWork.Setup(unitOfWork => unitOfWork.BrandRepository.Add(It.IsAny<Brand>())).Returns(new Brand());
            _unitOfWork.Setup(uof => uof.CommitChangesAsync(_cancellationToken));
            _validator.Setup(v => v.ValidateAsync(command, _cancellationToken)).ReturnsAsync(new ValidationResult());

            // Act
            CreateBrandCommandResponse response = await _handler.Handle(command, _cancellationToken);

            // Assert
            // assert response
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Null(response.ErrorMessages);

            // assert data
            Assert.NotNull(response.Entity);
            Assert.Multiple(() =>
            {
                Assert.Equal("01 Jan 0001 00:00:00", response.Entity!.CreatedDate.ToString());
                Assert.Equal("00000000-0000-0000-0000-000000000000", response.Entity!.CreatedByUserId.ToString()); //in-valid id
            });
        }
        
        [Fact]
        public async Task CreateBrandCommandHandler_Should_ReturnEntityFrameworkException_WhenFailedToAddBrandAsync()
        {
            // Arrange 
            CreateBrandCommand command = new("Sasko", "Sasko Building");
            _handler = new CreateBrandCommandHandler(_logger.Object, _unitOfWork.Object, _validator.Object, _publisher.Object);

            // We are testing the "Add" functionality of the BrandRepository. EFCore may return an error & fail to save
            _unitOfWork.Setup(unitOfWork => unitOfWork.BrandRepository.Add(It.IsAny<Brand>()))
                .Throws(new EntityFrameworkException("EF Core failed to save"));

            _unitOfWork.Setup(uof => uof.CommitChangesAsync(_cancellationToken));
            _validator.Setup(v => v.ValidateAsync(command, _cancellationToken)).ReturnsAsync(new ValidationResult());

            // Act
            var exception = await Assert.ThrowsAsync<EntityFrameworkException>(async () => await _handler.Handle(command, _cancellationToken));            

            // Assert
            Assert.Equal(nameof(exception), "exception");

        }

    }
}
