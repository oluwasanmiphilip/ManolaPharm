using ManolaPharm.Application.Services;
using ManolaPharm.Domain.Entities.HR;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<PurchaseOrderService>();
builder.Services.AddScoped<SalesOrderService>();
builder.Services.AddScoped<AccountsReceivableService>();
builder.Services.AddScoped<AccountsPayableService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<PayrollService>();
builder.Services.AddScoped<ExpenseService>();







// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ManolaPharmConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
