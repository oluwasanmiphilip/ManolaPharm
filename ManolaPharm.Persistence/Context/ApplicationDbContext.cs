using ManolaPharm.Domain.Entities.Customer;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Domain.Entities.HR;
using ManolaPharm.Domain.Entities.Inventory;
using ManolaPharm.Domain.Entities.Product;
using ManolaPharm.Domain.Entities.Purchasing;
using ManolaPharm.Domain.Entities.Sales;
using ManolaPharm.Domain.Entities.Supplier;
using ManolaPharm.Domain.Entities.Users;
using ManolaPharm.Domain.Entities.Warehouse;
using ManolaPharm.Persistence.Configurations;
using ManolaPharm.Persistence.Configurations.Finance;
using Microsoft.EntityFrameworkCore;


namespace ManolaPharm.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Example Entity Sets (commented out until entities are created)
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<AccountsReceivable> AccountsReceivables { get; set; } // Finance
        public DbSet<AccountsPayable> AccountsPayables { get; set; } // Finance
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations here later
            modelBuilder.ApplyConfiguration(new PayrollConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderConfiguration());
            modelBuilder.ApplyConfiguration(new SalesOrderConfiguration());
            modelBuilder.ApplyConfiguration(new AccountsReceivableConfig());
            modelBuilder.ApplyConfiguration(new AccountsPayableConfig());
            
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
           
            
            
        }
    }
}
