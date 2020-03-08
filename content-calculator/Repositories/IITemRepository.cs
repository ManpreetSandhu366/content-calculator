using content_calculator.Models;
using System.Collections.Generic;
using content_calculator.ViewModels;

namespace content_calculator.Repositories
{
    public interface IITemRepository
    {
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        bool AddItem(Item item);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        List<ItemViewModel> GetAll();
    }
}
