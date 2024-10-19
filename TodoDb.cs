using Microsoft.EntityFrameworkCore;

namespace MinimalAPI;

public class TodoDb(DbContextOptions<TodoDb> options) : DbContext(options)
{
    public DbSet<TodoItem> Todos { get; set; }
}
