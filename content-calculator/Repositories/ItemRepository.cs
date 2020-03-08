using AutoMapper;
using System.Linq;
using content_calculator.DAL;
using content_calculator.Models;
using System.Collections.Generic;
using content_calculator.ViewModels;

namespace content_calculator.Repositories
{
    public class ItemRepository : IITemRepository
    {
        private readonly IMapper mapper;
        private readonly ContentContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public ItemRepository(ContentContext context,
                              IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool AddItem(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            Item itemToDelete = context.Items.Where(i => i.ItemId == id).FirstOrDefault();

            if (itemToDelete != null)
            {
                context.Items.Remove(itemToDelete);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns></returns>
        public List<ItemViewModel> GetAll()
        {
            List<Item> itemsDto = context.Items.OrderBy(i => i.Name).ToList();
            List<ItemViewModel> items = mapper.Map<List<ItemViewModel>>(itemsDto);
            return items;
        }
    }
}
