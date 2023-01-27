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
    [Migration("20230121164721_mig_4")]
    partial class mig_4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 4,
                            AuthenticatorType = 0,
                            Email = "gymapp@gymapp.com",
                            FirstName = "gymapp",
                            LastName = "gymapp",
                            PasswordHash = new byte[] { 148, 24, 93, 136, 153, 150, 236, 101, 88, 83, 182, 95, 204, 63, 240, 195, 203, 222, 236, 181, 57, 59, 155, 224, 107, 63, 208, 53, 18, 66, 153, 1, 75, 236, 241, 212, 181, 26, 253, 123, 120, 219, 243, 254, 217, 43, 247, 156, 146, 58, 17, 186, 250, 143, 217, 202, 176, 62, 132, 103, 40, 55, 211, 3 },
                            PasswordSalt = new byte[] { 66, 142, 107, 234, 1, 97, 47, 25, 161, 77, 217, 162, 134, 64, 3, 157, 90, 229, 82, 11, 5, 197, 150, 231, 156, 245, 79, 127, 29, 164, 113, 95, 109, 207, 69, 91, 207, 35, 106, 120, 47, 222, 28, 137, 40, 210, 72, 143, 65, 236, 142, 35, 111, 159, 139, 36, 231, 149, 52, 61, 31, 129, 7, 165, 71, 166, 91, 6, 62, 2, 1, 189, 231, 92, 174, 66, 146, 147, 240, 20, 134, 173, 40, 58, 30, 237, 124, 84, 49, 0, 62, 155, 140, 224, 22, 69, 157, 45, 237, 77, 177, 222, 241, 20, 38, 51, 98, 33, 162, 167, 142, 169, 194, 205, 250, 164, 87, 237, 199, 165, 155, 45, 238, 231, 92, 14, 243, 5 },
                            Status = true
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
                            UserId = 4
                        },
                        new
                        {
                            Id = 2,
                            OperationClaimId = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 3,
                            OperationClaimId = 3,
                            UserId = 4
                        },
                        new
                        {
                            Id = 4,
                            OperationClaimId = 4,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            OperationClaimId = 5,
                            UserId = 4
                        },
                        new
                        {
                            Id = 6,
                            OperationClaimId = 6,
                            UserId = 4
                        },
                        new
                        {
                            Id = 7,
                            OperationClaimId = 7,
                            UserId = 4
                        },
                        new
                        {
                            Id = 8,
                            OperationClaimId = 8,
                            UserId = 4
                        },
                        new
                        {
                            Id = 9,
                            OperationClaimId = 9,
                            UserId = 4
                        },
                        new
                        {
                            Id = 10,
                            OperationClaimId = 10,
                            UserId = 4
                        },
                        new
                        {
                            Id = 11,
                            OperationClaimId = 11,
                            UserId = 4
                        },
                        new
                        {
                            Id = 12,
                            OperationClaimId = 12,
                            UserId = 4
                        },
                        new
                        {
                            Id = 13,
                            OperationClaimId = 13,
                            UserId = 4
                        },
                        new
                        {
                            Id = 14,
                            OperationClaimId = 14,
                            UserId = 4
                        },
                        new
                        {
                            Id = 15,
                            OperationClaimId = 15,
                            UserId = 4
                        },
                        new
                        {
                            Id = 16,
                            OperationClaimId = 16,
                            UserId = 4
                        },
                        new
                        {
                            Id = 17,
                            OperationClaimId = 17,
                            UserId = 4
                        },
                        new
                        {
                            Id = 18,
                            OperationClaimId = 18,
                            UserId = 4
                        },
                        new
                        {
                            Id = 19,
                            OperationClaimId = 19,
                            UserId = 4
                        },
                        new
                        {
                            Id = 20,
                            OperationClaimId = 20,
                            UserId = 4
                        },
                        new
                        {
                            Id = 21,
                            OperationClaimId = 21,
                            UserId = 4
                        },
                        new
                        {
                            Id = 22,
                            OperationClaimId = 22,
                            UserId = 4
                        },
                        new
                        {
                            Id = 23,
                            OperationClaimId = 23,
                            UserId = 4
                        },
                        new
                        {
                            Id = 24,
                            OperationClaimId = 24,
                            UserId = 4
                        },
                        new
                        {
                            Id = 25,
                            OperationClaimId = 25,
                            UserId = 4
                        },
                        new
                        {
                            Id = 26,
                            OperationClaimId = 26,
                            UserId = 4
                        },
                        new
                        {
                            Id = 27,
                            OperationClaimId = 27,
                            UserId = 4
                        },
                        new
                        {
                            Id = 28,
                            OperationClaimId = 28,
                            UserId = 4
                        },
                        new
                        {
                            Id = 29,
                            OperationClaimId = 29,
                            UserId = 4
                        },
                        new
                        {
                            Id = 30,
                            OperationClaimId = 30,
                            UserId = 4
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
