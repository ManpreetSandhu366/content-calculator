using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using content_calculator.Models;
using System.Collections.Generic;
using content_calculator.ViewModels;
using content_calculator.InputModels;
using content_calculator.Repositories;

namespace content_calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IITemRepository itemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        /// <param name="itemRepository">The item repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ItemController(IITemRepository itemRepository,
                              IMapper mapper)
        {
            this.mapper = mapper;
            this.itemRepository = itemRepository;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ItemViewModel> GetAll()
        {
            List<ItemViewModel> items = itemRepository.GetAll();
            return items;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            bool result = itemRepository.Delete(id);
            return result;
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [HttpPost]
        public bool AddItem(ItemInputModel item)
        {
            Item itemDto = mapper.Map<Item>(item);
            bool result = itemRepository.AddItem(itemDto);
            return result;
        }
    }
}
