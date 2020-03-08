using AutoMapper;
using content_calculator.DAL;
using content_calculator.Models;
using content_calculator.Repositories;
using content_calculator.ViewModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace content_calculator_tests.Repositories
{
    public class ItemRepositoryTest
    {
        private readonly Mock<IMapper> mapper;
        private readonly IITemRepository itemRepository;

        public ItemRepositoryTest()
        {
            var itemViewModels = new List<ItemViewModel> { 
                new ItemViewModel { Id = 1, CategoryId = 1, DisplayName = "TV", Value = 2000 },
                new ItemViewModel { Id = 2, CategoryId = 2, DisplayName = "Jacket", Value = 1000 },
                new ItemViewModel { Id = 3, CategoryId = 3, DisplayName = "Knife", Value = 10}
            };

            var items = new List<Item> { 
                new Item { ItemId = 1, CategoryId = 1, Name = "TV", Price = 2000 },
                new Item { ItemId = 2, CategoryId = 2, Name = "Jacket", Price = 1000 },
                new Item { ItemId = 3, CategoryId = 3, Name = "Knife", Price = 10 }
            };

            mapper = new Mock<IMapper>();
            mapper.Setup(s => s.Map<List<ItemViewModel>>(It.IsAny<List<Item>>())).Returns(itemViewModels);

            itemRepository = GetInMemoryCategoryRepository(items: items);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsListOfItems()
        {
            // Act
            var result = itemRepository.GetAll();

            // Assert
            Assert.Collection(result, item => item.DisplayName.Contains("Tv"),
                                      item => item.DisplayName.Contains("Jacket"),
                                      Item => Item.DisplayName.Contains("Knife"));
        }

        [Fact]
        public void Delete_IfCalledWithValidId_ReturnTrue()
        {
            // Act
            var result = itemRepository.Delete(id: 1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_IfCalledWithInvalidId_ReturnFalse()
        {
            // Act 
            var result = itemRepository.Delete(id: 13);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AddItem_WhenCalled_ReturnsTrue()
        {
            // Arrange
            var item = new Item {
                ItemId = 11,
                Name = "Laptop",
                Price = 3000,
                CategoryId = 2
            };

            // Act
            var result = itemRepository.AddItem(item: item);

            // Assert
            Assert.True(result);
        }

        private ItemRepository GetInMemoryCategoryRepository(List<Item> items)
        {
            DbContextOptions<ContentContext> options;
            var builder = new DbContextOptionsBuilder<ContentContext>();
            builder.UseInMemoryDatabase("testDb");
            options = builder.Options;
            ContentContext contentContext = new ContentContext(options);
            contentContext.Database.EnsureDeleted();
            contentContext.Database.EnsureCreated();
            contentContext.Items.AddRange(items);
            contentContext.SaveChanges();
            return new ItemRepository(contentContext, mapper.Object);
        }
    }
}
