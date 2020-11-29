using DatabaseCar.Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseCar.Data_Access_Layer.EFDataContext
{
    public class ShowroomContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmploymentContract> EmploymentContracts { get; set; }
        public DbSet<FinanceReport> FinanceReports { get; set; }
        public DbSet<ITWorkApplication> ITWorkApplications { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PurchaseContract> PurchaseContracts { get; set; }
        public DbSet<SellDocument> SellDocuments { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
        public DbSet<TripOrder> TripOrders { get; set; }
        public DbSet<VacationDocument> VacationDocuments { get; set; }
        public DbSet<Table> Tables { get; set; }

        public ShowroomContext(DbContextOptions<ShowroomContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CarPurchaseContract>()
            .HasKey(t => new { t.CarId, t.PurchaseContractId });

            modelBuilder.Entity<CarPurchaseContract>()
                .HasOne(sc => sc.Car)
                .WithMany(s => s.CarPurchaseContracts)
                .HasForeignKey(sc => sc.CarId);

            modelBuilder.Entity<CarPurchaseContract>()
                .HasOne(sc => sc.PurchaseContract)
                .WithMany(c => c.CarPurchaseContracts)
                .HasForeignKey(sc => sc.PurchaseContractId);


            ////Конфигурация, заполняем таблицу ролей и добавляем админа
            //string adminRoleName = "admin";
            //string userRoleName = "user";
            //string employeeRoleName = "employee";

            //string adminEmail = "alex27super@gmail.com";
            //string adminPassword = "12345678";

            //// добавляем роли
            //Role adminRole = new Role { Id = 1, Name = adminRoleName };
            //Role userRole = new Role { Id = 2, Name = userRoleName };
            //Role employeeRole = new Role { Id = 3, Name = employeeRoleName };

            Position admin = new Position() { Id = 1, Name = "admin" };
            Position director = new Position() { Id = 2, Name = "alex27super" };

            modelBuilder.Entity<Position>().HasData(admin, director);

            //User adminUser = new User { Id = 1, Firstname = "Oleksiy", Surname = "Garnik", Patronymic = "Igorovich", Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            //modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole, employeeRole });
            EmploymentContract lol = new EmploymentContract() { Id = 1, Salary = 300, PositionId = admin.Id };

            modelBuilder.Entity<EmploymentContract>().HasData(lol);

            ContactInfo cinfo = new ContactInfo() { Id = 1, Phone = "0971844085" };

            modelBuilder.Entity<ContactInfo>().HasData(cinfo);

            Employee adminUser = new Employee { Id = 1, Name = "Leha", Surname = "Garnich", Patronymic = "Igorovich",
                Age = 20, ContactInfoId = cinfo.Id, 
                Email = "alex27super@gmail.com", Password = "12345678", EmploymentContractId = lol.Id  };


            modelBuilder.Entity<Employee>().HasData(new Employee[] { adminUser });

            base.OnModelCreating(modelBuilder);
        }
    }
}
