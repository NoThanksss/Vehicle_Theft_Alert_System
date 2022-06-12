﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vehicle_Theft_Alert_System_DAL;

namespace Vehicle_Theft_Alert_System_DAL.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20220515173736_adding_nullable_properties")]
    partial class adding_nullable_properties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.AccountDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("BillAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<Guid?>("FamilyDBId")
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<Guid>("UserDBId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FamilyDBId");

                    b.HasIndex("UserDBId")
                        .IsUnique();

                    b.ToTable("AccountDBs");
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.ActivityScheduleDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("ActivityStatus")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TrackerDBId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TrackerDBId");

                    b.ToTable("ActivityScheduleDBs");
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.ConnectionDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AccountDBId")
                        .HasColumnType("uuid");

                    b.Property<string>("ConnectionType")
                        .HasColumnType("text");

                    b.Property<Guid?>("FamilyDBId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("TrackerDBId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AccountDBId");

                    b.HasIndex("FamilyDBId");

                    b.HasIndex("TrackerDBId");

                    b.ToTable("ConnectionDBs");
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.CountryDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContinentName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CountryDBs");
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.FamilyDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("FamilyPlanDBId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FamilyPlanDBId");

                    b.ToTable("FamilyDBs");
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.FamilyPlanDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Discount")
                        .HasColumnType("integer");

                    b.Property<int>("MaxMemberNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FamilyPlanDBs");
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.TrackerDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExperationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IP")
                        .HasColumnType("text");

                    b.Property<bool>("IsOn")
                        .HasColumnType("boolean");

                    b.Property<string>("LastCoordinates")
                        .HasColumnType("text");

                    b.Property<string>("Mac")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TrackerDBs");
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.UserDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CountryDBId")
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryDBId");

                    b.ToTable("UserDBs");
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.AccountDB", b =>
                {
                    b.HasOne("Vehicle_Theft_Alert_System_DAL.Models.FamilyDB", "FamilyDB")
                        .WithMany("AccountDBs")
                        .HasForeignKey("FamilyDBId");

                    b.HasOne("Vehicle_Theft_Alert_System_DAL.Models.UserDB", "UserDB")
                        .WithOne("AccountDB")
                        .HasForeignKey("Vehicle_Theft_Alert_System_DAL.Models.AccountDB", "UserDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.ActivityScheduleDB", b =>
                {
                    b.HasOne("Vehicle_Theft_Alert_System_DAL.Models.TrackerDB", "TrackerDB")
                        .WithMany("ActivityScheduleDBs")
                        .HasForeignKey("TrackerDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.ConnectionDB", b =>
                {
                    b.HasOne("Vehicle_Theft_Alert_System_DAL.Models.AccountDB", "AccountDB")
                        .WithMany()
                        .HasForeignKey("AccountDBId");

                    b.HasOne("Vehicle_Theft_Alert_System_DAL.Models.FamilyDB", "FamilyDB")
                        .WithMany()
                        .HasForeignKey("FamilyDBId");

                    b.HasOne("Vehicle_Theft_Alert_System_DAL.Models.TrackerDB", "TrackerDB")
                        .WithMany()
                        .HasForeignKey("TrackerDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.FamilyDB", b =>
                {
                    b.HasOne("Vehicle_Theft_Alert_System_DAL.Models.FamilyPlanDB", "FamilyPlanDB")
                        .WithMany("FamilyDBs")
                        .HasForeignKey("FamilyPlanDBId");
                });

            modelBuilder.Entity("Vehicle_Theft_Alert_System_DAL.Models.UserDB", b =>
                {
                    b.HasOne("Vehicle_Theft_Alert_System_DAL.Models.CountryDB", "CountryDB")
                        .WithMany("UserDBs")
                        .HasForeignKey("CountryDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
