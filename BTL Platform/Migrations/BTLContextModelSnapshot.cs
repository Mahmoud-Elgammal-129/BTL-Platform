﻿// <auto-generated />
using System;
using BTL_Platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTL_Platform.Migrations
{
    [DbContext(typeof(BTLContext))]
    partial class BTLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BTL_Platform.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6c4ec3d7-17c8-4a9c-9c18-99f87a9d9779",
                            Email = "zaghlol@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "Zaghlol",
                            NormalizedEmail = "zaghlol@gmail.com",
                            NormalizedUserName = "zaghlol",
                            PasswordHash = "AQAAAAIAAYagAAAAEDzvxUuIQNjPtjnouuDSWxC3kgRoLjULO80Hl1lQfT5EhPG0DmSzfkG4cEauIIuoSQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5c3ff075-bd53-4fbe-81d4-e40f1af4e358",
                            TwoFactorEnabled = false,
                            UserName = "Zaghlol"
                        });
                });

            modelBuilder.Entity("BTL_Platform.Models.Inventory", b =>
                {
                    b.Property<long>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("InventoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("BTL_Platform.Models.Places", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Chain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PlaceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastupdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("longitude")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("BTL_Platform.Models.Request", b =>
                {
                    b.Property<long>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RequestID"));

                    b.Property<string>("Assignee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OnGroundTeams")
                        .HasColumnType("int");

                    b.Property<int>("POSNumber")
                        .HasColumnType("int");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RequestTypeID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrucksNeeded")
                        .HasColumnType("int");

                    b.Property<string>("WH_movements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestID");

                    b.HasIndex("Employee_Id");

                    b.HasIndex("RequestTypeID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("BTL_Platform.Models.RequestType", b =>
                {
                    b.Property<long>("RequestTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RequestTypeID"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestTypeID");

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("BTL_Platform.Models.Unit", b =>
                {
                    b.Property<long>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UnitId"));

                    b.Property<long>("InventoryId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("int");

                    b.Property<long>("Unit_type_Id")
                        .HasColumnType("bigint");

                    b.HasKey("UnitId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("Unit_type_Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("BTL_Platform.Models.UnitType", b =>
                {
                    b.Property<long>("UnitTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UnitTypeId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UnitTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitTypeId");

                    b.ToTable("UnitTypes");
                });

            modelBuilder.Entity("BTL_Platform.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Team")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BTL_Platform.Models.Visit", b =>
                {
                    b.Property<long>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VisitId"));

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("POSPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<long>("Place_Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PlannedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<long>("RequestID")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UTCoffset")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitsNumbers")
                        .HasColumnType("int");

                    b.Property<string>("UnitsPhotoAfter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitsPhotobefore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VisitStatusId")
                        .HasColumnType("bigint");

                    b.Property<long>("VisitTypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("placeChain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("placeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitId");

                    b.HasIndex("Id");

                    b.HasIndex("Place_Id");

                    b.HasIndex("RequestID");

                    b.HasIndex("VisitStatusId");

                    b.HasIndex("VisitTypeId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("BTL_Platform.Models.VisitStatus", b =>
                {
                    b.Property<long>("VisitStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VisitStatusId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("VisitStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitStatusId");

                    b.ToTable("VisitStatuses");
                });

            modelBuilder.Entity("BTL_Platform.Models.VisitType", b =>
                {
                    b.Property<long>("VisitTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VisitTypeId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("VisitTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitTypeId");

                    b.ToTable("VisitTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BTL_Platform.Models.Employee", b =>
                {
                    b.HasBaseType("BTL_Platform.Models.ApplicationUser");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("BTL_Platform.Models.Request", b =>
                {
                    b.HasOne("BTL_Platform.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("Employee_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTL_Platform.Models.RequestType", "Request_type")
                        .WithMany()
                        .HasForeignKey("RequestTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Request_type");
                });

            modelBuilder.Entity("BTL_Platform.Models.Unit", b =>
                {
                    b.HasOne("BTL_Platform.Models.Inventory", "inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTL_Platform.Models.UnitType", "Unit_type")
                        .WithMany()
                        .HasForeignKey("Unit_type_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit_type");

                    b.Navigation("inventory");
                });

            modelBuilder.Entity("BTL_Platform.Models.Visit", b =>
                {
                    b.HasOne("BTL_Platform.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTL_Platform.Models.Places", "Place")
                        .WithMany()
                        .HasForeignKey("Place_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTL_Platform.Models.Places", "request")
                        .WithMany()
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTL_Platform.Models.VisitStatus", "VisitStatus")
                        .WithMany()
                        .HasForeignKey("VisitStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTL_Platform.Models.VisitType", "VisitType")
                        .WithMany()
                        .HasForeignKey("VisitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");

                    b.Navigation("VisitStatus");

                    b.Navigation("VisitType");

                    b.Navigation("request");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BTL_Platform.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BTL_Platform.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTL_Platform.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BTL_Platform.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
