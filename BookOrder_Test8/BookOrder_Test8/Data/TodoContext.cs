using BookOrder_Test8.Models;
using Microsoft.EntityFrameworkCore;

namespace BookOrder_Test8.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<BookOrder> BookOrders { get; set; } = null!;
    }
}
