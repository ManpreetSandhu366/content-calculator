using content_calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace content_calculator.DAL
{
    public class ContentContext: DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ContentContext(DbContextOptions<ContentContext> options): base(options)
        {
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public DbSet<Item> Items { get; set; }
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public DbSet<Category> Categories { get; set; }
    }
}
