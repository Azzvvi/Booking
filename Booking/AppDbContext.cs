using System;
using System.Linq;
using Booking.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Booking
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //создает бд, если она отсутствует
            Database.EnsureCreated();
        }

        public DbSet<UserModel> users { get; set; }
        public DbSet<HotelModel> hotels { get; set; }
        public DbSet<RoomModel> rooms { get; set; }
    }
}
