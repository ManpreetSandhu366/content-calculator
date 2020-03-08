using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using content_calculator.ViewModels;
using content_calculator.Repositories;

namespace content_calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CategoryViewModel> GetAll()
        {
            List<CategoryViewModel> categories = categoryRepository.GetAll();

            return categories;
        }
    }
}