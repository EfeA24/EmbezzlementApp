﻿// <auto-generated />
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entites.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250205182756_Item")]
    partial class Item
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entites.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<int>("ItemCount")
                        .HasColumnType("int");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ItemStockCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ItemType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
