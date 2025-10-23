using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Xunit;
using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.Services.Commands;
using AppointmentTracking.Application.Features.Services.Handlers;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.SharedKernel.Results;

namespace AppointmentTracking.Tests.FeaturesTests.ServicesTest.HandlersTests
{
    public class CreateServiceCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateServiceCommandHandler _handler;

        public CreateServiceCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateServiceCommandHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccessResult_WhenServiceCreated()
        {
            // Arrange
            var command = new CreateServiceCommand
            {
                Name = "Psychological Counseling",
                Description = "Individual therapy session",
                Price = 500
            };

            var createdService = new Service
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                Price = command.Price
            };

            var serviceDto = new ServiceDto
            {
                Id = createdService.Id,
                Name = createdService.Name,
                Description = createdService.Description,
                Price = createdService.Price
            };

            _unitOfWorkMock
                .Setup(u => u.Services.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock
                .Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            _mapperMock
                .Setup(m => m.Map<ServiceDto>(It.IsAny<Service>()))
                .Returns(serviceDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Name.Should().Be(command.Name);
            result.Message.Should().Be("Hizmet başarıyla oluşturuldu.");

            _unitOfWorkMock.Verify(u => u.Services.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            _mapperMock.Verify(m => m.Map<ServiceDto>(It.IsAny<Service>()), Times.Once);
        }
    }
}
