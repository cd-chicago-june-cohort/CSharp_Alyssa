﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using weddingPlanner.Models;

namespace weddingPlanner.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170920132124_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("weddingPlanner.Models.GuestConnection", b =>
                {
                    b.Property<int>("GuestConnectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GuestId");

                    b.Property<int>("WeddingId");

                    b.HasKey("GuestConnectionId");

                    b.HasIndex("GuestId");

                    b.HasIndex("WeddingId");

                    b.ToTable("GuestConnection");
                });

            modelBuilder.Entity("weddingPlanner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<string>("email");

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("password");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("weddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Date");

                    b.Property<int>("SpouseOneId");

                    b.Property<int>("SpouseTwoId");

                    b.HasKey("WeddingId");

                    b.HasIndex("SpouseOneId");

                    b.HasIndex("SpouseTwoId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("weddingPlanner.Models.GuestConnection", b =>
                {
                    b.HasOne("weddingPlanner.Models.User", "Guest")
                        .WithMany("WeddingsAttending")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("weddingPlanner.Models.Wedding", "Wedding")
                        .WithMany("Guests")
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("weddingPlanner.Models.Wedding", b =>
                {
                    b.HasOne("weddingPlanner.Models.User", "SpouseOne")
                        .WithMany()
                        .HasForeignKey("SpouseOneId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("weddingPlanner.Models.User", "SpouseTwo")
                        .WithMany()
                        .HasForeignKey("SpouseTwoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
