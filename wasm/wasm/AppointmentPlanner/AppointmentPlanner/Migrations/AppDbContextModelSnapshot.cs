﻿// <auto-generated />
using System;
using AppointmentPlanner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppointmentPlanner.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppointmentPlanner.Client.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("AppointmentPlanner.Client.CompanySite", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("CompanyId", "SiteId");

                    b.HasIndex("SiteId");

                    b.ToTable("CompanySites");
                });

            modelBuilder.Entity("AppointmentPlanner.Client.Site", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("AppointmentPlanner.Client.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("AccessLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppointmentPlanner.Shared.DTOs.UpdateNote", b =>
                {
                    b.Property<int>("UpdateNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UpdateNoteId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObservationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("UpdateNoteId");

                    b.HasIndex("ObservationId");

                    b.ToTable("UpdateNotes");
                });

            modelBuilder.Entity("Observation", b =>
                {
                    b.Property<int>("ObservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObservationId"));

                    b.Property<string>("CloseOutNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ClosedOutDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionOfObservation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionOfSuggestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NatureOfObservation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RaisedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonForInvalid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReporterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfReport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UploadedImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObservationId");

                    b.HasIndex("SiteId");

                    b.ToTable("Observations");
                });

            modelBuilder.Entity("AppointmentPlanner.Client.CompanySite", b =>
                {
                    b.HasOne("AppointmentPlanner.Client.Company", "Company")
                        .WithMany("CompanySites")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppointmentPlanner.Client.Site", "Site")
                        .WithMany("CompanySites")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("AppointmentPlanner.Shared.DTOs.UpdateNote", b =>
                {
                    b.HasOne("Observation", null)
                        .WithMany("Updates")
                        .HasForeignKey("ObservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Observation", b =>
                {
                    b.HasOne("AppointmentPlanner.Client.Site", "Site")
                        .WithMany("Observations")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("AppointmentPlanner.Client.Company", b =>
                {
                    b.Navigation("CompanySites");
                });

            modelBuilder.Entity("AppointmentPlanner.Client.Site", b =>
                {
                    b.Navigation("CompanySites");

                    b.Navigation("Observations");
                });

            modelBuilder.Entity("Observation", b =>
                {
                    b.Navigation("Updates");
                });
#pragma warning restore 612, 618
        }
    }
}
