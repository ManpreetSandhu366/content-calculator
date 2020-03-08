using AutoMapper;
using System.Linq;
using content_calculator.DAL;
using content_calculator.Models;
using System.Collections.Generic;
using content_calculator.ViewModels;

namespace content_calculator.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper mapper;
        private readonly ContentContext context;

        /// <summary>Initializes a new instance of the <see cref="CategoryRepository"/> class.</summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public CategoryRepository(ContentContext context,
                                  IMapper mapper)
        {
            this.mapper = mapper;       
            this.context = context;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>List of Categories <see cref="CategoryViewModel"/> class.</returns>
        public List<CategoryViewModel> GetAll()
        {
            List<Category> categoryDtos = context.Categories.OrderBy(c => c.Name).ToList();
            List<CategoryViewModel> categories = mapper.Map<List<CategoryViewModel>>(categoryDtos);
            return categories;
        }
    }
}
