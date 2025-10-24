using ManolaPharm.Application.Services;
using ManolaPharm.Application.Services.Finance;
using ManolaPharm.Domain.Entities.HR;
using ManolaPharm.Persistence.Configurations.Finance;
using ManolaPharm.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// JWT configuration read
var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtKey = jwtSection.GetValue<string>("Key");
var jwtIssuer = jwtSection.GetValue<string>("Issuer");
var jwtAudience = jwtSection.GetValue<string>("Audience");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtIssuer,

        ValidateAudience = true,
        ValidAudience = jwtAudience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),

        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(2)
    };
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<AuthService>();
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
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<JournalEntryService>();
builder.Services.AddScoped<JournalEntryDetailService>();
builder.Services.AddScoped<GeneralLedgerService>();
builder.Services.AddScoped<TrialBalanceService>();
builder.Services.AddScoped<ChartOfAccountService>();
builder.Services.AddScoped<CashBookService>();
builder.Services.AddScoped<BankReconciliationService>();








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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
