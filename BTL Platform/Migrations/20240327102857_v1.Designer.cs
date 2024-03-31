﻿// <auto-generated />
using System;
using BTL_Platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTL_Platform.Migrations
{
    [DbContext(typeof(BTLContext))]
    [Migration("20240327102857_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BTL_Platform.Models.Employees", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MobileNumber")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BTL_Platform.Models.Inventory", b =>
                {
                    b.Property<long>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("InventoryId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("count")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PlaceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VisitId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("lastupdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("longitude")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

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

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrucksNeeded")
                        .HasColumnType("int");

                    b.Property<long?>("VisitId")
                        .HasColumnType("bigint");

                    b.Property<string>("WH_movements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestID");

                    b.HasIndex("VisitId");

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

                    b.Property<long?>("RequestID")
                        .HasColumnType("bigint");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VisitId")
                        .HasColumnType("bigint");

                    b.HasKey("RequestTypeID");

                    b.HasIndex("RequestID");

                    b.HasIndex("VisitId");

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("BTL_Platform.Models.Unit", b =>
                {
                    b.Property<long>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UnitId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("UnitName")
                        .HasColumnType("bigint");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("int");

                    b.HasKey("UnitId");

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

                    b.Property<long>("UnitId")
                        .HasColumnType("bigint");

                    b.Property<string>("UnitTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VisitId")
                        .HasColumnType("bigint");

                    b.HasKey("UnitTypeId");

                    b.HasIndex("UnitId");

                    b.HasIndex("VisitId");

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

                    b.Property<long>("VisitId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BTL_Platform.Models.Visit", b =>
                {
                    b.Property<long>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VisitId"));

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

                    b.Property<DateTime>("PlannedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<string>("Request_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("placeChain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("placeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitId");

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

                    b.Property<long>("VisitId")
                        .HasColumnType("bigint");

                    b.Property<string>("VisitStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitStatusId");

                    b.HasIndex("VisitId");

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

                    b.Property<long>("VisitId")
                        .HasColumnType("bigint");

                    b.Property<string>("VisitTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitTypeId");

                    b.HasIndex("VisitId");

                    b.ToTable("VisitTypes");
                });

            modelBuilder.Entity("BTL_Platform.Models.Places", b =>
                {
                    b.HasOne("BTL_Platform.Models.Visit", "Visit")
                        .WithMany("Places")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BTL_Platform.Models.Request", b =>
                {
                    b.HasOne("BTL_Platform.Models.Visit", null)
                        .WithMany("Requests")
                        .HasForeignKey("VisitId");
                });

            modelBuilder.Entity("BTL_Platform.Models.RequestType", b =>
                {
                    b.HasOne("BTL_Platform.Models.Request", null)
                        .WithMany("RequestTypes")
                        .HasForeignKey("RequestID");

                    b.HasOne("BTL_Platform.Models.Visit", "Visit")
                        .WithMany()
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BTL_Platform.Models.UnitType", b =>
                {
                    b.HasOne("BTL_Platform.Models.Unit", "Unit")
                        .WithMany("UnitTypes")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTL_Platform.Models.Visit", "Visit")
                        .WithMany("UnitTypes")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BTL_Platform.Models.User", b =>
                {
                    b.HasOne("BTL_Platform.Models.Visit", "Visit")
                        .WithMany("Users")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BTL_Platform.Models.VisitStatus", b =>
                {
                    b.HasOne("BTL_Platform.Models.Visit", "Visit")
                        .WithMany("VisitStatuses")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BTL_Platform.Models.VisitType", b =>
                {
                    b.HasOne("BTL_Platform.Models.Visit", "Visit")
                        .WithMany("VisitTypes")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BTL_Platform.Models.Request", b =>
                {
                    b.Navigation("RequestTypes");
                });

            modelBuilder.Entity("BTL_Platform.Models.Unit", b =>
                {
                    b.Navigation("UnitTypes");
                });

            modelBuilder.Entity("BTL_Platform.Models.Visit", b =>
                {
                    b.Navigation("Places");

                    b.Navigation("Requests");

                    b.Navigation("UnitTypes");

                    b.Navigation("Users");

                    b.Navigation("VisitStatuses");

                    b.Navigation("VisitTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
