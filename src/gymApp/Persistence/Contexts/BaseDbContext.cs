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
        public DbSet<MemberType> MemberTypes { get; set; }
        public DbSet<Movement> Movements{ get; set; }
        public DbSet<ImageUpload> ImageUploads { get; set; }
        #region MappingDbSet

        public DbSet<UserMemberTypeMapping> UserMemberTypeMappings { get; set; }
        public DbSet<MovementImageUploadMapping> MovementImageUploadMappings { get; set; }

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

            OperationClaim[] operationClaims = { new(1,"BodyInformation.Admin"), new(2, "BodyInformation.Create"),
                new(3, "BodyInformation.Update"), new(4, "BodyInformation.Delete"), new(5, "BodyInformation.Read"),
                new(6, "MemberType.Admin"), new(7, "MemberType.Create"),
                new(8, "MemberType.Update"), new(9, "MemberType.Delete"), new(10, "MemberType.Read"),
                new(11, "OperationClaim.Admin"), new(12, "OperationClaim.Create"),
                new(13, "OperationClaim.Update"), new(14, "OperationClaim.Delete"), new(15, "OperationClaim.Read"),
                new(16, "UserOperationClaim.Admin"), new(17, "UserOperationClaim.Create"),
                new(18, "UserOperationClaim.Update"), new(19, "UserOperationClaim.Delete"), new(20, "UserOperationClaim.Read"),
                new(21, "UserMemberTypeMapping.Admin"), new(22, "UserMemberTypeMapping.Create"),
                new(23, "UserMemberTypeMapping.Update"), new(24, "UserMemberTypeMapping.Delete"), new(25, "UserMemberTypeMapping.Read"),
                new(26, "Movement.Admin"), new(27, "Movement.Create"),
                new(28, "Movement.Update"), new(29, "Movement.Delete"), new(30, "Movement.Read"),
                new(31, "MovementImageUploadMapping.Admin"), new(32, "MovementImageUploadMapping.Create"),
                new(33, "MovementImageUploadMapping.Update"), new(34, "MovementImageUploadMapping.Delete"), new(35, "MovementImageUploadMapping.Read")};
            modelBuilder.Entity<OperationClaim>().HasData(operationClaims);


            // User

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
                u.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
            });

            User[] users = { new(4, "gymapp", "gymapp", "gymapp@gymapp.com", passwordSalt, passwordHash, true, 0) };
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
                    UserOperationClaim[] userOperationClaims = { new(userOperationClaimId,user.Id,operationClaim.Id)};
                    modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaims);
                }
            }
        }
    }
}
