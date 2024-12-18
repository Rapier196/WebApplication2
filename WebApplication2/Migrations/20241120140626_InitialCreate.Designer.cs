﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication2.Data;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241120140626_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactInfo")
                        .HasColumnType("text")
                        .HasColumnName("contact_info");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("employee_id");

                    b.Property<int?>("EnterpriseId")
                        .HasColumnType("integer")
                        .HasColumnName("enterprise_id");

                    b.Property<int?>("Hours")
                        .HasColumnType("integer")
                        .HasColumnName("hours");

                    b.Property<string>("Position")
                        .HasColumnType("text")
                        .HasColumnName("position");

                    b.HasKey("Id");

                    b.ToTable("employee", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
