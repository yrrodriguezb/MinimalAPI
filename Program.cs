using Microsoft.EntityFrameworkCore;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);

// Services

builder.Services.AddDbContext<TodoDb>(options => {
    options.UseInMemoryDatabase("TodoList");
});

var app = builder.Build();

// Methods

app.MapGet("/todoitems", async (TodoDb db) => {
    return  await db.Todos.ToListAsync();
});

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) => {
    return  await db.Todos.FindAsync(id);
});

app.MapPost("/todoitems/", async (TodoItem todo, TodoDb db) => {
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return  Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, TodoItem inputTodo, TodoDb db) => {
    var todo = await db.Todos.FindAsync(id);
    if (todo == null) return Results.NotFound();
    todo.Name = inputTodo.Name;
    todo.IsCompleted = inputTodo.IsCompleted;
    await db.SaveChangesAsync();
    return  Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) => {
    if (await db.Todos.FindAsync(id) is TodoItem todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return  Results.NoContent();
    }
    
    return Results.NotFound();
});

app.Run();