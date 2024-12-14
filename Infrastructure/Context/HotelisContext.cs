using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public partial class HotelisContext : DbContext
{
    private readonly MySqlConnection mySqlConnection;
    public HotelisContext()
    {
        
    }
    public HotelisContext(DbContextOptions<HotelisContext> options)
        : base(options)
    {
    }

    public DbSet<Address> Address { get; set; }
    public DbSet<TimesAvailable> TimesAvialable { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Cost> Costs { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Province> Provincies { get; set; }
    public DbSet<Bookings> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomPicture> RoomPictures { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PreBooking> PreBooking { get; set; }


    public DbSet<HotelPicture> HotelPicture { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseMySQL("Server=PXSNTAR-37;port=3306; database=hotelis; user id=hotelis;password=Hotelis2024;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        //modelBuilder.SeedDataHotelis();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
