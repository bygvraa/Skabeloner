using Web_API.Models;
using Web_API.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DataService>();

var app = builder.Build();

app.MapGet("/", () => 
{
    return " ";
});

app.MapGet("/api/customer", (DataService service) =>
{
    return service.GetCustomers();
});

app.MapGet("/api/customer/{id}", (DataService service, int id) =>
{
    return service.GetCustomerById(id);
});

app.MapPost("/api/customer", (DataService service, CustomerData customer) =>
{
    return service.CreateCustomer(customer.Name, customer.Email, customer.Type);
});

app.MapDelete("/api/customer/{id}", (DataService service, int id) =>
{
    return service.DeleteCustomer(id);
});

app.MapGet("/api/email/{type}", (DataService service, CustomerType type) =>
{
    return service.GetEmailsByType(type);
});

app.Run();

public record CustomerData(string Name, string Email, CustomerType Type);