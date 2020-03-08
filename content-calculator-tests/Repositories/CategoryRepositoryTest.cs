using AutoMapper;
using content_calculator.DAL;
using content_calculator.Models;
using content_calculator.Repositories;
using content_calculator.ViewModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace content_calculator_tests.Repositories
{
    public class CategoryRepositoryTest
    {
        private readonly Mock<IMapper> mapper;
        private readonly ICategoryRepository categoryRepository;

        public CategoryRepositoryTest()
        {
            var categories = new List<Category> {
                new Category { Name = "Kitchen", CategoryId = 3 },
                new Category { Name = "Clothing", CategoryId = 2 },
                new Category { Name = "Electronics", CategoryId = 1 }
            };
            var categoriesViewModel = new List<CategoryViewModel> {
                new CategoryViewModel { Name = "Kitchen", Id = 3 },
                new CategoryViewModel { Name = "Clothing", Id = 2 },
                new CategoryViewModel { Name = "Electronics", Id = 1 }
            };

            mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<List<CategoryViewModel>>(It.IsAny<List<Category>>())).Returns(categoriesViewModel);
            categoryRepository = GetInMemoryCategoryRepository(categories);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsListOfCategories()
        {
            // Act
            var result = categoryRepository.GetAll();

            // Assert
            Assert.Collection(result, item => item.Name.Contains("Electronics"),
                                      item => item.Name.Contains("Clothing"),
                                      Item => Item.Name.Contains("Kitchen"));
        }

        private CategoryRepository GetInMemoryCategoryRepository(List<Category> categories)
        {
            DbContextOptions<ContentContext> options;
            var builder = new DbContextOptionsBuilder<ContentContext>();
            builder.UseInMemoryDatabase("testDb");
            options = builder.Options;
            ContentContext contentContext = new ContentContext(options);
            contentContext.Database.EnsureDeleted();
            contentContext.Database.EnsureCreated();
            contentContext.Categories.AddRange(categories);
            contentContext.SaveChanges();
            return new CategoryRepository(contentContext, mapper.Object);
        }
    }
}
