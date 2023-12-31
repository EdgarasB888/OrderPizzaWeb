﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderPizzaWeb2.Data;

#nullable disable

namespace OrderPizzaWeb2.Migrations
{
    [DbContext(typeof(OrderPizzaWebDbContext))]
    [Migration("20231022181258_Initial migration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OrderPizzaWeb2.Data.Entities.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PizzaOrders");
                });

            modelBuilder.Entity("OrderPizzaWeb2.Data.Entities.PizzaOrderTopping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("PizzaOrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ToppingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaOrderId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaOrderTopping");
                });

            modelBuilder.Entity("OrderPizzaWeb2.Data.Entities.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("OrderPizzaWeb2.Data.Entities.PizzaOrderTopping", b =>
                {
                    b.HasOne("OrderPizzaWeb2.Data.Entities.PizzaOrder", "PizzaOrder")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("PizzaOrderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OrderPizzaWeb2.Data.Entities.Topping", "Topping")
                        .WithMany("ToppingPizzas")
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("PizzaOrder");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("OrderPizzaWeb2.Data.Entities.PizzaOrder", b =>
                {
                    b.Navigation("PizzaToppings");
                });

            modelBuilder.Entity("OrderPizzaWeb2.Data.Entities.Topping", b =>
                {
                    b.Navigation("ToppingPizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
