using Moq;
using Xunit;
using System.Collections.Generic;
using content_calculator.ViewModels;
using content_calculator.Controllers;
using content_calculator.Repositories;

namespace content_calculator_tests.Controllers
{
    public class CategoryControllerTest
    {
        private readonly Mock<ICategoryRepository> categoryRepository;
        private readonly CategoryController categoryController;

        public CategoryControllerTest()
        {
            // Arrange
            categoryRepository = new Mock<ICategoryRepository>();
            categoryRepository.Setup(s => s.GetAll()).Returns(new List<CategoryViewModel> { 
                new CategoryViewModel { Id = 1, Name = "Clothing" },
                new CategoryViewModel { Id = 2, Name = "Electronics" },
                new CategoryViewModel { Id = 3, Name = "Kitchen" }
            });

            categoryController = new CategoryController(categoryRepository.Object);
        }

        [Fact]
        public void GetAll_WhenCalled_DoesNotReturnNull()
        {
            // Act
            var result = categoryController.GetAll();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsListOfCategories()
        {
            // Act
            var result = categoryController.GetAll();

            // Assert
            Assert.Collection(result, item => item.Name.Contains("Clothing"),
                                      item => item.Name.Contains("Electronics"),
                                      item => item.Name.Contains("Kitchen"));
        }
    }
}
