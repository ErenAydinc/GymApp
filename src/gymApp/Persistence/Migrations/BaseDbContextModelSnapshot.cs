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
                            Name = "MovementImageUploadMapping.Admin"
                        },
                        new
                        {
                            Id = 32,
                            Name = "MovementImageUploadMapping.Create"
                        },
                        new
                        {
                            Id = 33,
                            Name = "MovementImageUploadMapping.Update"
                        },
                        new
                        {
                            Id = 34,
                            Name = "MovementImageUploadMapping.Delete"
                        },
                        new
                        {
                            Id = 35,
                            Name = "MovementImageUploadMapping.Read"
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
                            PasswordHash = new byte[] { 109, 82, 237, 232, 252, 174, 56, 145, 70, 248, 118, 146, 167, 17, 0, 41, 96, 18, 86, 40, 102, 167, 27, 229, 175, 208, 68, 48, 227, 104, 245, 117, 25, 102, 118, 115, 146, 18, 204, 213, 17, 130, 24, 149, 157, 138, 44, 195, 134, 168, 174, 216, 182, 254, 137, 219, 246, 255, 60, 116, 8, 165, 68, 123 },
                            PasswordSalt = new byte[] { 79, 69, 34, 170, 90, 147, 107, 255, 90, 182, 83, 235, 44, 94, 221, 175, 42, 118, 170, 143, 112, 151, 48, 123, 4, 37, 150, 74, 11, 168, 162, 127, 123, 137, 81, 141, 174, 67, 114, 75, 236, 141, 146, 7, 55, 155, 166, 218, 150, 172, 54, 10, 61, 65, 79, 54, 181, 146, 146, 142, 67, 42, 162, 9, 131, 16, 12, 86, 13, 130, 157, 94, 88, 153, 201, 247, 196, 136, 197, 141, 193, 118, 232, 230, 152, 75, 125, 239, 56, 204, 212, 103, 178, 223, 145, 93, 143, 13, 141, 51, 25, 119, 236, 8, 160, 245, 145, 164, 138, 60, 111, 90, 51, 93, 54, 99, 220, 159, 165, 83, 182, 250, 191, 199, 56, 143, 202, 202 },
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
                        },
                        new
                        {
                            Id = 31,
                            OperationClaimId = 31,
                            UserId = 4
                        },
                        new
                        {
                            Id = 32,
                            OperationClaimId = 32,
                            UserId = 4
                        },
                        new
                        {
                            Id = 33,
                            OperationClaimId = 33,
                            UserId = 4
                        },
                        new
                        {
                            Id = 34,
                            OperationClaimId = 34,
                            UserId = 4
                        },
                        new
                        {
                            Id = 35,
                            OperationClaimId = 35,
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

            modelBuilder.Entity("Domain.Entities.ImageUpload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ImageUploads");
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

            modelBuilder.Entity("Domain.MappingEntities.MovementImageUploadMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ImageUploadId")
                        .HasColumnType("int");

                    b.Property<int>("MovementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MovementImageUploadMappings");
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
