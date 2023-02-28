﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Security.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("companies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Kartal/Istanbul",
                            Email = "gymapp@gymapp.com",
                            Name = "GymApp",
                            PhoneNumber = "+905535305501"
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Email = "gymapp@gymapp.com",
                            Name = "GymApp",
                            PhoneNumber = "+905535305501"
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("FirstName");

                    b.HasKey("Id");

                    b.ToTable("operationclaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "System Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Gym Admin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Personal Trainer"
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("longtext");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("int")
                        .HasColumnName("AuthenticatorType");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("LastName");

                    b.Property<DateTime?>("MemberEndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("MemberEndDate");

                    b.Property<DateTime>("MemberStartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("MemberStartDate");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob")
                        .HasColumnName("PasswordSalt");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Status");

                    b.Property<int>("TimeZone")
                        .HasColumnType("int")
                        .HasColumnName("TimeZone");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthenticatorType = 0,
                            CompanyId = 1,
                            CustomerId = 1,
                            Email = "gymapp@gymapp.com",
                            FirstName = "gymapp",
                            LastName = "gymapp",
                            MemberStartDate = new DateTime(2023, 2, 24, 10, 40, 58, 683, DateTimeKind.Utc).AddTicks(2866),
                            PasswordHash = new byte[] { 2, 221, 26, 153, 114, 71, 156, 176, 211, 231, 37, 60, 153, 170, 78, 122, 124, 135, 138, 9, 2, 53, 242, 109, 90, 24, 162, 3, 88, 230, 132, 86, 25, 80, 24, 183, 67, 137, 197, 179, 126, 109, 173, 223, 118, 214, 4, 156, 101, 160, 41, 223, 166, 78, 94, 194, 118, 53, 7, 8, 9, 91, 48, 14 },
                            PasswordSalt = new byte[] { 220, 97, 215, 203, 84, 19, 46, 102, 68, 31, 84, 123, 167, 85, 56, 96, 146, 165, 185, 214, 142, 151, 219, 184, 86, 231, 17, 22, 84, 194, 111, 133, 67, 196, 60, 235, 48, 185, 189, 66, 126, 179, 61, 235, 178, 160, 42, 87, 85, 247, 91, 206, 119, 227, 128, 238, 246, 95, 231, 141, 37, 72, 60, 238, 190, 126, 75, 13, 71, 255, 144, 113, 70, 191, 110, 114, 71, 240, 187, 137, 49, 153, 8, 218, 222, 190, 0, 255, 154, 77, 240, 84, 2, 164, 20, 165, 179, 210, 251, 187, 187, 236, 207, 44, 48, 103, 169, 76, 223, 67, 31, 231, 252, 71, 249, 232, 65, 223, 59, 36, 128, 155, 161, 53, 87, 81, 164, 203 },
                            Status = true,
                            TimeZone = 1,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int")
                        .HasColumnName("OperationClaimId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("useroperationclaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OperationClaimId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            OperationClaimId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            OperationClaimId = 3,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.BodyInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Arm")
                        .HasColumnType("float");

                    b.Property<float>("Chest")
                        .HasColumnType("float");

                    b.Property<float>("Leg")
                        .HasColumnType("float");

                    b.Property<float>("Length")
                        .HasColumnType("float");

                    b.Property<float>("Shoulder")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("BodyInformations");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entities.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("Domain.Entities.MovementImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext");

                    b.Property<int>("MovementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MovementImages");
                });

            modelBuilder.Entity("Domain.Entities.PersonalTrainerStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PersonalTrainerId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PersonalTrainerStudents");
                });

            modelBuilder.Entity("Domain.Entities.UsersMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsFriday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsMonday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSaturday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSunday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsThursday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsTuesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsWednesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MovementId")
                        .HasColumnType("int");

                    b.Property<int>("RepetitionNumber")
                        .HasColumnType("int");

                    b.Property<int>("SetNumber")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UsersMovements");
                });

            modelBuilder.Entity("Domain.MappingEntities.CustomerToMovementMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("MovementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CustomerToMovementMappings");
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.HasOne("Core.Security.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Security.Entities.OperationClaim", "OperationClaim")
                        .WithMany()
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
