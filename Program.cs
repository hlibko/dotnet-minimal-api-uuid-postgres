using dotnet_minimal_api_uuid_postgres.Data;
using dotnet_minimal_api_uuid_postgres.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapPost("/users", async (User user, AppDbContext db) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

app.MapGet("/users", async (AppDbContext db) =>
{
    var users = await db.Users.ToListAsync();
    return Results.Ok(users);
});

app.MapGet("/users/{id:guid}", async (Guid id, AppDbContext db) =>
{
    var user = await db.Users.FindAsync(id);
    return user is null ? Results.NotFound() : Results.Ok(user);
});

app.Run();
