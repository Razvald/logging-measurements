﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using log_data_well.Data;

#nullable disable

namespace log_data_well.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.27");

            modelBuilder.Entity("log_data_well.Data.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClientID");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("log_data_well.Data.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MeasurementID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialistID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WellMeasurementMeasurementID")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderID");

                    b.HasIndex("ClientID");

                    b.HasIndex("SpecialistID");

                    b.HasIndex("WellMeasurementMeasurementID");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("log_data_well.Data.Specialist", b =>
                {
                    b.Property<int>("SpecialistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SpecialistID");

                    b.ToTable("Specialists", (string)null);
                });

            modelBuilder.Entity("log_data_well.Data.SpecialistSpecialization", b =>
                {
                    b.Property<int>("SpecialistSpecializationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecialistID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecializationID")
                        .HasColumnType("INTEGER");

                    b.HasKey("SpecialistSpecializationID");

                    b.HasIndex("SpecialistID");

                    b.HasIndex("SpecializationID");

                    b.ToTable("SpecialistSpecializations", (string)null);
                });

            modelBuilder.Entity("log_data_well.Data.Specialization", b =>
                {
                    b.Property<int>("SpecializationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SpecializationID");

                    b.ToTable("Specializations", (string)null);
                });

            modelBuilder.Entity("log_data_well.Data.Well", b =>
                {
                    b.Property<int>("WellID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Depth")
                        .HasColumnType("REAL");

                    b.Property<string>("GeoCoordinates")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WellTypeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("WellID");

                    b.HasIndex("WellTypeID");

                    b.ToTable("Wells", (string)null);
                });

            modelBuilder.Entity("log_data_well.Data.WellMeasurement", b =>
                {
                    b.Property<int>("MeasurementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("MeasurementDateTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("MeasurementValue")
                        .HasColumnType("REAL");

                    b.Property<int>("WellID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MeasurementID");

                    b.HasIndex("WellID");

                    b.ToTable("WellMeasurements", (string)null);
                });

            modelBuilder.Entity("log_data_well.Data.WellType", b =>
                {
                    b.Property<int>("WellTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WellTypeID");

                    b.ToTable("WellTypes", (string)null);
                });

            modelBuilder.Entity("log_data_well.Data.Order", b =>
                {
                    b.HasOne("log_data_well.Data.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("log_data_well.Data.Specialist", "Specialist")
                        .WithMany()
                        .HasForeignKey("SpecialistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("log_data_well.Data.WellMeasurement", "WellMeasurement")
                        .WithMany()
                        .HasForeignKey("WellMeasurementMeasurementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Specialist");

                    b.Navigation("WellMeasurement");
                });

            modelBuilder.Entity("log_data_well.Data.SpecialistSpecialization", b =>
                {
                    b.HasOne("log_data_well.Data.Specialist", "Specialist")
                        .WithMany("SpecialistSpecializations")
                        .HasForeignKey("SpecialistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("log_data_well.Data.Specialization", "Specialization")
                        .WithMany("SpecialistSpecializations")
                        .HasForeignKey("SpecializationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialist");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("log_data_well.Data.Well", b =>
                {
                    b.HasOne("log_data_well.Data.WellType", "WellType")
                        .WithMany()
                        .HasForeignKey("WellTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WellType");
                });

            modelBuilder.Entity("log_data_well.Data.WellMeasurement", b =>
                {
                    b.HasOne("log_data_well.Data.Well", "Well")
                        .WithMany()
                        .HasForeignKey("WellID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Well");
                });

            modelBuilder.Entity("log_data_well.Data.Specialist", b =>
                {
                    b.Navigation("SpecialistSpecializations");
                });

            modelBuilder.Entity("log_data_well.Data.Specialization", b =>
                {
                    b.Navigation("SpecialistSpecializations");
                });
#pragma warning restore 612, 618
        }
    }
}