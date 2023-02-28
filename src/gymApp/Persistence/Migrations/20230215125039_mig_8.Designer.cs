﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20230215125039_mig_8")]
    partial class mig_8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Name = "BodyInformation.Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BodyInformation.Create"
                        },
                        new
                        {
                            Id = 3,
                            Name = "BodyInformation.Update"
                        },
                        new
                        {
                            Id = 4,
                            Name = "BodyInformation.Delete"
                        },
                        new
                        {
                            Id = 5,
                            Name = "BodyInformation.Read"
                        },
                        new
                        {
                            Id = 6,
                            Name = "MemberType.Admin"
                        },
                        new
                        {
                            Id = 7,
                            Name = "MemberType.Create"
                        },
                        new
                        {
                            Id = 8,
                            Name = "MemberType.Update"
                        },
                        new
                        {
                            Id = 9,
                            Name = "MemberType.Delete"
                        },
                        new
                        {
                            Id = 10,
                            Name = "MemberType.Read"
                        },
                        new
                        {
                            Id = 11,
                            Name = "OperationClaim.Admin"
                        },
                        new
                        {
                            Id = 12,
                            Name = "OperationClaim.Create"
                        },
                        new
                        {
                            Id = 13,
                            Name = "OperationClaim.Update"
                        },
                        new
                        {
                            Id = 14,
                            Name = "OperationClaim.Delete"
                        },
                        new
                        {
                            Id = 15,
                            Name = "OperationClaim.Read"
                        },
                        new
                        {
                            Id = 16,
                            Name = "UserOperationClaim.Admin"
                        },
                        new
                        {
                            Id = 17,
                            Name = "UserOperationClaim.Create"
                        },
                        new
                        {
                            Id = 18,
                            Name = "UserOperationClaim.Update"
                        },
                        new
                        {
                            Id = 19,
                            Name = "UserOperationClaim.Delete"
                        },
                        new
                        {
                            Id = 20,
                            Name = "UserOperationClaim.Read"
                        },
                        new
                        {
                            Id = 21,
                            Name = "UserMemberTypeMapping.Admin"
                        },
                        new
                        {
                            Id = 22,
                            Name = "UserMemberTypeMapping.Create"
                        },
                        new
                        {
                            Id = 23,
                            Name = "UserMemberTypeMapping.Update"
                        },
                        new
                        {
                            Id = 24,
                            Name = "UserMemberTypeMapping.Delete"
                        },
                        new
                        {
                            Id = 25,
                            Name = "UserMemberTypeMapping.Read"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Movement.Admin"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Movement.Create"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Movement.Update"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Movement.Delete"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Movement.Read"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Customer.Admin"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Customer.Create"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Customer.Update"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Customer.Delete"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Customer.Read"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Company.Admin"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Company.Create"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Company.Update"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Company.Delete"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Company.Read"
                        },
                        new
                        {
                            Id = 41,
                            Name = "PersonalTrainer.Admin"
                        },
                        new
                        {
                            Id = 42,
                            Name = "PersonalTrainer.Create"
                        },
                        new
                        {
                            Id = 43,
                            Name = "PersonalTrainer.Update"
                        },
                        new
                        {
                            Id = 44,
                            Name = "PersonalTrainer.Delete"
                        },
                        new
                        {
                            Id = 45,
                            Name = "PersonalTrainer.Read"
                        },
                        new
                        {
                            Id = 46,
                            Name = "PersonalTrainerStudent.Admin"
                        },
                        new
                        {
                            Id = 47,
                            Name = "PersonalTrainerStudent.Create"
                        },
                        new
                        {
                            Id = 48,
                            Name = "PersonalTrainerStudent.Update"
                        },
                        new
                        {
                            Id = 49,
                            Name = "PersonalTrainerStudent.Delete"
                        },
                        new
                        {
                            Id = 50,
                            Name = "PersonalTrainerStudent.Read"
                        },
                        new
                        {
                            Id = 51,
                            Name = "UsersMovement.Admin"
                        },
                        new
                        {
                            Id = 52,
                            Name = "UsersMovement.Create"
                        },
                        new
                        {
                            Id = 53,
                            Name = "UsersMovement.Update"
                        },
                        new
                        {
                            Id = 54,
                            Name = "UsersMovement.Delete"
                        },
                        new
                        {
                            Id = 55,
                            Name = "UsersMovement.Read"
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

                    b.Property<int>("Type")
                        .HasColumnType("int");

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
                            PasswordHash = new byte[] { 252, 159, 176, 119, 183, 104, 123, 183, 247, 110, 104, 197, 7, 104, 184, 159, 7, 98, 4, 129, 121, 236, 75, 140, 71, 134, 138, 60, 246, 216, 215, 174, 111, 119, 50, 142, 186, 203, 101, 212, 183, 204, 155, 184, 239, 224, 223, 155, 185, 37, 34, 152, 150, 76, 242, 201, 28, 51, 198, 195, 123, 207, 222, 87 },
                            PasswordSalt = new byte[] { 124, 184, 2, 251, 79, 221, 189, 159, 224, 20, 114, 18, 251, 194, 84, 2, 111, 58, 6, 114, 138, 169, 177, 249, 181, 138, 139, 182, 217, 167, 128, 71, 211, 16, 112, 220, 68, 204, 171, 225, 180, 71, 176, 9, 79, 20, 231, 181, 196, 77, 221, 233, 190, 64, 127, 222, 161, 117, 81, 194, 111, 67, 176, 68, 199, 14, 16, 11, 122, 93, 42, 29, 181, 127, 100, 233, 167, 1, 248, 48, 81, 170, 70, 87, 247, 123, 137, 199, 116, 105, 46, 50, 118, 34, 223, 19, 165, 212, 168, 41, 231, 235, 22, 37, 214, 110, 99, 114, 32, 210, 226, 222, 255, 215, 210, 36, 34, 130, 176, 32, 182, 161, 129, 177, 4, 213, 242, 121 },
                            Status = true,
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
                        },
                        new
                        {
                            Id = 4,
                            OperationClaimId = 4,
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            OperationClaimId = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            OperationClaimId = 6,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            OperationClaimId = 7,
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            OperationClaimId = 8,
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            OperationClaimId = 9,
                            UserId = 1
                        },
                        new
                        {
                            Id = 10,
                            OperationClaimId = 10,
                            UserId = 1
                        },
                        new
                        {
                            Id = 11,
                            OperationClaimId = 11,
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            OperationClaimId = 12,
                            UserId = 1
                        },
                        new
                        {
                            Id = 13,
                            OperationClaimId = 13,
                            UserId = 1
                        },
                        new
                        {
                            Id = 14,
                            OperationClaimId = 14,
                            UserId = 1
                        },
                        new
                        {
                            Id = 15,
                            OperationClaimId = 15,
                            UserId = 1
                        },
                        new
                        {
                            Id = 16,
                            OperationClaimId = 16,
                            UserId = 1
                        },
                        new
                        {
                            Id = 17,
                            OperationClaimId = 17,
                            UserId = 1
                        },
                        new
                        {
                            Id = 18,
                            OperationClaimId = 18,
                            UserId = 1
                        },
                        new
                        {
                            Id = 19,
                            OperationClaimId = 19,
                            UserId = 1
                        },
                        new
                        {
                            Id = 20,
                            OperationClaimId = 20,
                            UserId = 1
                        },
                        new
                        {
                            Id = 21,
                            OperationClaimId = 21,
                            UserId = 1
                        },
                        new
                        {
                            Id = 22,
                            OperationClaimId = 22,
                            UserId = 1
                        },
                        new
                        {
                            Id = 23,
                            OperationClaimId = 23,
                            UserId = 1
                        },
                        new
                        {
                            Id = 24,
                            OperationClaimId = 24,
                            UserId = 1
                        },
                        new
                        {
                            Id = 25,
                            OperationClaimId = 25,
                            UserId = 1
                        },
                        new
                        {
                            Id = 26,
                            OperationClaimId = 26,
                            UserId = 1
                        },
                        new
                        {
                            Id = 27,
                            OperationClaimId = 27,
                            UserId = 1
                        },
                        new
                        {
                            Id = 28,
                            OperationClaimId = 28,
                            UserId = 1
                        },
                        new
                        {
                            Id = 29,
                            OperationClaimId = 29,
                            UserId = 1
                        },
                        new
                        {
                            Id = 30,
                            OperationClaimId = 30,
                            UserId = 1
                        },
                        new
                        {
                            Id = 31,
                            OperationClaimId = 31,
                            UserId = 1
                        },
                        new
                        {
                            Id = 32,
                            OperationClaimId = 32,
                            UserId = 1
                        },
                        new
                        {
                            Id = 33,
                            OperationClaimId = 33,
                            UserId = 1
                        },
                        new
                        {
                            Id = 34,
                            OperationClaimId = 34,
                            UserId = 1
                        },
                        new
                        {
                            Id = 35,
                            OperationClaimId = 35,
                            UserId = 1
                        },
                        new
                        {
                            Id = 36,
                            OperationClaimId = 36,
                            UserId = 1
                        },
                        new
                        {
                            Id = 37,
                            OperationClaimId = 37,
                            UserId = 1
                        },
                        new
                        {
                            Id = 38,
                            OperationClaimId = 38,
                            UserId = 1
                        },
                        new
                        {
                            Id = 39,
                            OperationClaimId = 39,
                            UserId = 1
                        },
                        new
                        {
                            Id = 40,
                            OperationClaimId = 40,
                            UserId = 1
                        },
                        new
                        {
                            Id = 41,
                            OperationClaimId = 41,
                            UserId = 1
                        },
                        new
                        {
                            Id = 42,
                            OperationClaimId = 42,
                            UserId = 1
                        },
                        new
                        {
                            Id = 43,
                            OperationClaimId = 43,
                            UserId = 1
                        },
                        new
                        {
                            Id = 44,
                            OperationClaimId = 44,
                            UserId = 1
                        },
                        new
                        {
                            Id = 45,
                            OperationClaimId = 45,
                            UserId = 1
                        },
                        new
                        {
                            Id = 46,
                            OperationClaimId = 46,
                            UserId = 1
                        },
                        new
                        {
                            Id = 47,
                            OperationClaimId = 47,
                            UserId = 1
                        },
                        new
                        {
                            Id = 48,
                            OperationClaimId = 48,
                            UserId = 1
                        },
                        new
                        {
                            Id = 49,
                            OperationClaimId = 49,
                            UserId = 1
                        },
                        new
                        {
                            Id = 50,
                            OperationClaimId = 50,
                            UserId = 1
                        },
                        new
                        {
                            Id = 51,
                            OperationClaimId = 51,
                            UserId = 1
                        },
                        new
                        {
                            Id = 52,
                            OperationClaimId = 52,
                            UserId = 1
                        },
                        new
                        {
                            Id = 53,
                            OperationClaimId = 53,
                            UserId = 1
                        },
                        new
                        {
                            Id = 54,
                            OperationClaimId = 54,
                            UserId = 1
                        },
                        new
                        {
                            Id = 55,
                            OperationClaimId = 55,
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

            modelBuilder.Entity("Domain.Entities.MemberType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MemberTypes");
                });

            modelBuilder.Entity("Domain.Entities.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

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

            modelBuilder.Entity("Domain.Entities.PersonalTrainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PersonalTrainers");
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

                    b.Property<int>("MovementId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
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

            modelBuilder.Entity("Domain.MappingEntities.UserMemberTypeMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MemberTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMemberTypeMappings");
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

            modelBuilder.Entity("Domain.MappingEntities.UserMemberTypeMapping", b =>
                {
                    b.HasOne("Domain.Entities.MemberType", "MemberType")
                        .WithMany()
                        .HasForeignKey("MemberTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MemberType");

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
