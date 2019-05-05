 namespace Ef.codeFirst
{
    using Ef.codeFirst.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        // Your context has been configured to use a 'CodeFirst' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Ef.codeFirst.CodeFirst' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CodeFirst' 
        // connection string in the application configuration file.
        public ModelContext()
            : base("name=CodeFirst")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserVisits> UserVisits { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Cover> Cover { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .HasKey(d => d.DeptId)
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
               .ToTable("Employee")
               .Property(d => d.Name)
               .IsRequired()
               .HasMaxLength(50);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.Fk_DepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Books)
                .WithMany(b => b.Employees)
                .Map(t => t.ToTable("EmpBooks")
                .MapLeftKey("Fk_EmployeeId")
                .MapRightKey("Fk_bookId"));

            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Cover)
                .WithRequiredPrincipal(c => c.Book)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<City>()
               .HasOptional(c => c.Book)
               .WithRequired(b => b.City);
        }




    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}