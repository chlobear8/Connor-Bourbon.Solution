﻿// <auto-generated />
using ConnorBourbon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConnorBourbon.Migrations
{
    [DbContext(typeof(BourbonContext))]
    [Migration("20230316013709_AddTagEntity")]
    partial class AddTagEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ConnorBourbon.Models.Bourbon", b =>
                {
                    b.Property<int>("BourbonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("BourbonId");

                    b.HasIndex("BrandId");

                    b.ToTable("Bourbons");
                });

            modelBuilder.Entity("ConnorBourbon.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DistilleryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("BrandId");

                    b.HasIndex("DistilleryId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ConnorBourbon.Models.Distillery", b =>
                {
                    b.Property<int>("DistilleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("DistilleryId");

                    b.ToTable("Distilleries");
                });

            modelBuilder.Entity("ConnorBourbon.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ConnorBourbon.Models.Bourbon", b =>
                {
                    b.HasOne("ConnorBourbon.Models.Brand", "Brand")
                        .WithMany("Bourbons")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ConnorBourbon.Models.Brand", b =>
                {
                    b.HasOne("ConnorBourbon.Models.Distillery", "Distillery")
                        .WithMany("Brands")
                        .HasForeignKey("DistilleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distillery");
                });

            modelBuilder.Entity("ConnorBourbon.Models.Brand", b =>
                {
                    b.Navigation("Bourbons");
                });

            modelBuilder.Entity("ConnorBourbon.Models.Distillery", b =>
                {
                    b.Navigation("Brands");
                });
#pragma warning restore 612, 618
        }
    }
}
