using content_calculator.ViewModels;
using System.Collections.Generic;

namespace content_calculator.Repositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        List<CategoryViewModel> GetAll();
    }
}
