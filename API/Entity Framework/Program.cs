using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Entity_Framework.Data;
using Entity_Framework.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoTaskDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TodoTaskDbContextSQLite")));

builder.Services.AddScoped<TodoTaskDataService>();

// Her kan man styrer hvordan den laver JSON.
builder.Services.Configure<JsonOptions>(options =>
{
    // Super vigtig option! Den gør, at programmet ikke smider fejl
    // når man returnerer JSON med objekter, der refererer til hinanden.
    // (altså dobbelrettede associeringer)
    options.SerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    // Med scope kan man hente en service.
    var dataService = scope.ServiceProvider.GetRequiredService<TodoTaskDataService>();
    dataService.SeedData(); // Fylder data på hvis databasen er tom.
}

// Sæt Swagger og alt det andet halløj op
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

// Middlware der kører før hver request. Alle svar skal have ContentType: JSON.
app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});

// ---------------------------------------------------------------
// Endpoints i API'en --------------------------------------------

app.MapGet("/api/tasks", (TodoTaskDataService service) =>
{
    return service.GetTasks();
});

app.MapGet("/api/tasks/{id}", (TodoTaskDataService service, int id) =>
{
    return service.GetTaskById(id);
});

app.MapPost("/api/tasks/", (TodoTaskDataService service, TaskData data) =>
{
    return service.CreateTask(data.Text, data.Done, data.Id);
});

app.MapGet("/api/users", (TodoTaskDataService service) =>
{
    return service.GetUsers();
});

app.MapPost("/api/users/", (TodoTaskDataService service, UserData data) =>
{
    return service.CreateUser(data.Name);
});

// ---------------------------------------------------------------

app.Run();

// Records til input data (svarende til input JSON)
record TaskData(string Text, bool Done, int Id);
record UserData(string Name);