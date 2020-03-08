using Moq;
using Xunit;
using AutoMapper;
using content_calculator.Models;
using System.Collections.Generic;
using content_calculator.ViewModels;
using content_calculator.Controllers;
using content_calculator.InputModels;
using content_calculator.Repositories;

namespace content_calculator_tests.Controllers
{
    public class ItemControllerTest
    {
        private readonly Mock<IMapper> mapper;
        private readonly ItemController itemController;
        private readonly Mock<IITemRepository> itemRepository;

        public ItemControllerTest()
        {
            mapper = new Mock<IMapper>();
            itemRepository = new Mock<IITemRepository>();

            itemRepository.Setup(s => s.GetAll()).Returns(new List<ItemViewModel> {
                new ItemViewModel { Id = 1, DisplayName= "Jacket", Value= 200, CategoryId = 3 },
                new ItemViewModel { Id = 2, DisplayName= "Knife", Value= 100, CategoryId = 2 }
            });

            itemController = new ItemController(itemRepository.Object, mapper.Object);
        }

        [Fact]
        public void GetAll_WhenCalled_DoesNotReturnNull()
        {
            // Act
            var result = itemController.GetAll();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsListOfItems()
        {
            // Act
            var result = itemController.GetAll();

            // Assert
            Assert.Collection(result, item => item.DisplayName.Contains("Jacket"),
                                      item => item.DisplayName.Contains("Knife"));
        }

        [Fact]
        public void Delete_WithValidId_ReturnsTrue()
        {
            // Arrange
            itemRepository.Setup(s => s.Delete(It.IsAny<int>())).Returns(true);

            // Act
            var result = itemController.Delete(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_WithInvalidId_ReturnsFalse()
        {
            // Arrange
            itemRepository.Setup(s => s.Delete(It.IsAny<int>())).Returns(false);

            // Act
            var result = itemController.Delete(13);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AddItem_WhenCalled_ReturnsTrue()
        {
            // Arrange
            itemRepository.Setup(s => s.AddItem(It.IsAny<Item>())).Returns(true);
            ItemInputModel item = new ItemInputModel { DisplayName = "Jacket", Value = 300, CategoryId = 2 };

            // Act
            var result = itemController.AddItem(item);

            // Assert
            Assert.True(result);
        }
    }
}
