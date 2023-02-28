using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;
using Domain.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<BodyInformation> BodyInformations { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<MovementImage> MovementImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        #region MappingDbSet
        public DbSet<CustomerToMovementMapping> CustomerToMovementMappings { get; set; }
        public DbSet<PersonalTrainerStudent> PersonalTrainerStudents { get; set; }
        public DbSet<UsersMovement> UsersMovements { get; set; }
        #endregion

        #endregion

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Configuration.GetConnectionString("GymApp");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                optionsBuilder.EnableSensitiveDataLogging();
            }





            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Operation Claim
            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("operationclaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("FirstName");
            });

            OperationClaim[] operationClaims =
                { new(1,"System Admin"), new(2, "Gym Admin"),
                new(3, "Personal Trainer")};
            modelBuilder.Entity<OperationClaim>().HasData(operationClaims);




            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash("12345", out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("users").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.FirstName).HasColumnName("FirstName");
                u.Property(u => u.LastName).HasColumnName("LastName");
                u.Property(u => u.Email).HasColumnName("Email");
                u.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                u.Property(u => u.Status).HasColumnName("Status");
                u.Property(u => u.Type).HasColumnName("Type");
                u.Property(u => u.TimeZone).HasColumnName("TimeZone");
                u.Property(u => u.MemberStartDate).HasColumnName("MemberStartDate");
                u.Property(u => u.MemberEndDate).HasColumnName("MemberEndDate");
                u.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
                
            });

            User[] users = { new(1, "gymapp", "gymapp", "gymapp@gymapp.com", 1, 1, passwordSalt, passwordHash, true, 1,1,DateTime.UtcNow,null,0) };
            modelBuilder.Entity<User>().HasData(users);

            // User Operation Claim

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("useroperationclaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
            });
            int userOperationClaimId = 0;
            foreach (var operationClaim in operationClaims)
            {
                foreach (var user in users)
                {
                    userOperationClaimId++;
                    UserOperationClaim[] userOperationClaims = { new(userOperationClaimId, user.Id, operationClaim.Id) };
                    modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaims);
                }
            }

            //Company

            modelBuilder.Entity<Company>(c =>
            {
                c.ToTable("companies").HasKey(c => c.Id);
                c.Property(c => c.Id).HasColumnName("Id");
                c.Property(c => c.Name).HasColumnName("Name");
                c.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");
                c.Property(c => c.Email).HasColumnName("Email");
                c.Property(c => c.Address).HasColumnName("Address");
            });

            Company[] company = { new(1, "GymApp", "gymapp@gymapp.com", "+905535305501", "Kartal/Istanbul") };
            modelBuilder.Entity<Company>().HasData(company);

            //Customer

            modelBuilder.Entity<Customer>(c =>
            {
                c.ToTable("customers").HasKey(c => c.Id);
                c.Property(c => c.Id).HasColumnName("Id");
                c.Property(c => c.Name).HasColumnName("Name");
                c.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");
                c.Property(c => c.Email).HasColumnName("Email");
                c.Property(c => c.CompanyId).HasColumnName("CompanyId");
            });

            Customer[] customer = { new(1, "GymApp", "gymapp@gymapp.com", "+905535305501", 1) };
            modelBuilder.Entity<Customer>().HasData(customer);
        }
    }
}
