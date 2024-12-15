﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(HotelisContext))]
    [Migration("20241014040418_bookings")]
    partial class Bookings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infrastructure.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCity")
                        .HasColumnType("int");

                    b.Property<string>("Latitud")
                        .HasColumnType("longtext");

                    b.Property<string>("Longitud")
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Infrastructure.Models.Bookings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CheckInTimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReserved")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdRoom")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("char(36)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CheckInTimeId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Infrastructure.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Infrastructure.Models.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("CostPerTime")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("Infrastructure.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Infrastructure.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressHotelId")
                        .HasColumnType("int");

                    b.Property<int>("CodeArea")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressHotelId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Infrastructure.Models.HotelPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelPicture");
                });

            modelBuilder.Entity("Infrastructure.Models.PreBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdRoom")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeToExpire")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("PreBooking");
                });

            modelBuilder.Entity("Infrastructure.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Provincies");
                });

            modelBuilder.Entity("Infrastructure.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AvialableNow")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("BedNumbers")
                        .HasColumnType("int");

                    b.Property<int>("CostId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("HotelsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CostId");

                    b.HasIndex("HotelsId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Infrastructure.Models.RoomPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomPictures");
                });

            modelBuilder.Entity("Infrastructure.Models.TimesAvailable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TimesAvialable");
                });

            modelBuilder.Entity("Infrastructure.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AccountActivate")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CodeArea")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("IdAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOwnAccount")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("ProviderAccount")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecondName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.Models.Bookings", b =>
                {
                    b.HasOne("Infrastructure.Models.TimesAvailable", "CheckInTime")
                        .WithMany()
                        .HasForeignKey("CheckInTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckInTime");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Models.City", b =>
                {
                    b.HasOne("Infrastructure.Models.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Infrastructure.Models.Hotel", b =>
                {
                    b.HasOne("Infrastructure.Models.Address", "AddressHotel")
                        .WithMany()
                        .HasForeignKey("AddressHotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressHotel");
                });

            modelBuilder.Entity("Infrastructure.Models.HotelPicture", b =>
                {
                    b.HasOne("Infrastructure.Models.Hotel", null)
                        .WithMany("HotelPictures")
                        .HasForeignKey("HotelId");
                });

            modelBuilder.Entity("Infrastructure.Models.PreBooking", b =>
                {
                    b.HasOne("Infrastructure.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Models.Province", b =>
                {
                    b.HasOne("Infrastructure.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Infrastructure.Models.Room", b =>
                {
                    b.HasOne("Infrastructure.Models.Cost", "Cost")
                        .WithMany()
                        .HasForeignKey("CostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.Hotel", "Hotels")
                        .WithMany()
                        .HasForeignKey("HotelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cost");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("Infrastructure.Models.RoomPicture", b =>
                {
                    b.HasOne("Infrastructure.Models.Room", null)
                        .WithMany("RoomPictures")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("Infrastructure.Models.User", b =>
                {
                    b.HasOne("Infrastructure.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Infrastructure.Models.Hotel", b =>
                {
                    b.Navigation("HotelPictures");
                });

            modelBuilder.Entity("Infrastructure.Models.Room", b =>
                {
                    b.Navigation("RoomPictures");
                });
#pragma warning restore 612, 618
        }
    }
}
