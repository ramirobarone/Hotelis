using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;

namespace Infrastructure.Context;

public partial class HotelisContext : DbContext
{
    public HotelisContext()
    {
    }

    public HotelisContext(DbContextOptions<HotelisContext> options)
        : base(options)
    {
    }

    DbSet<Address> Address { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<Cost> Costs { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<Hotel> Hotels { get; set; }
    DbSet<Province> Provincies { get; set; }
    DbSet<Reserve> Reserves { get; set; }
    DbSet<Room> Rooms { get; set; }
    DbSet<RoomPicture> RoomPictures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=PXSNTAR-37;port=3306; database=hotelis; user id=hotelis;password=Hotelis2024;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
