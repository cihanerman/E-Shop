﻿// <auto-generated />
using System;
using E_Shop.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace EShop.Migrations {
    [DbContext (typeof (EShopContext))]
    [Migration ("20180302220737_InitialCreate")]
    partial class InitialCreate {
        protected override void BuildTargetModel (ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation ("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation ("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity ("E_Shop.Models.Order", b => {
                b.Property<int> ("OrderId")
                    .ValueGeneratedOnAdd ();

                b.Property<int> ("UserId");

                b.HasKey ("OrderId");

                b.HasIndex ("UserId");

                b.ToTable ("Orders");
            });

            modelBuilder.Entity ("E_Shop.Models.OrderProduct", b => {
                b.Property<int> ("OrderProductId")
                    .ValueGeneratedOnAdd ();

                b.Property<int> ("OrderId");

                b.Property<int> ("Piece");

                b.Property<int> ("ProductId");

                b.HasKey ("OrderProductId");

                b.HasIndex ("OrderId");

                b.HasIndex ("ProductId");

                b.ToTable ("OrderProduct");
            });

            modelBuilder.Entity ("E_Shop.Models.Product", b => {
                b.Property<int> ("ProductId")
                    .ValueGeneratedOnAdd ();

                b.Property<string> ("Description");

                b.Property<decimal> ("Price");

                b.Property<string> ("ProductName");

                b.Property<string> ("PruductImageUrl");

                b.Property<int> ("Stock");

                b.HasKey ("ProductId");

                b.ToTable ("Products");
            });

            modelBuilder.Entity ("E_Shop.Models.User", b => {
                b.Property<int> ("UserId")
                    .ValueGeneratedOnAdd ();

                b.Property<string> ("FirstName");

                b.Property<string> ("LastName");

                b.Property<string> ("Mail");

                b.Property<decimal> ("PhoneNumber");

                b.HasKey ("UserId");

                b.ToTable ("Users");
            });

            modelBuilder.Entity ("E_Shop.Models.Order", b => {
                b.HasOne ("E_Shop.Models.User", "User")
                    .WithMany ()
                    .HasForeignKey ("UserId")
                    .OnDelete (DeleteBehavior.Cascade);
            });

            modelBuilder.Entity ("E_Shop.Models.OrderProduct", b => {
                b.HasOne ("E_Shop.Models.Order", "Order")
                    .WithMany ()
                    .HasForeignKey ("OrderId")
                    .OnDelete (DeleteBehavior.Cascade);

                b.HasOne ("E_Shop.Models.Product", "Product")
                    .WithMany ()
                    .HasForeignKey ("ProductId")
                    .OnDelete (DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}