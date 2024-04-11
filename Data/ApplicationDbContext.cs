using Hotel_Project_Marti_i_Stanko.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Project_Marti_i_Stanko.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationClient> ReservationClients { get; set; }
        public DbSet<Hotel_Project_Marti_i_Stanko.Models.User> User { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReservationClient>()
                .HasKey(rc => new { rc.ReservationId, rc.ClientId });

            modelBuilder.Entity<ReservationClient>()
                .HasOne(rc => rc.Reservation)
                .WithMany(r => r.ReservationClients)
                .HasForeignKey(rc => rc.ReservationId);

            modelBuilder.Entity<ReservationClient>()
                .HasOne(rc => rc.Client)
                .WithMany(c => c.ReservationClients)
                .HasForeignKey(rc => rc.ClientId);
    }
}*/


        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationClient>()
            .HasKey(ea => new { ea.ReservationId, ea.ClientId });

            modelBuilder.Entity<ReservationClient>()
                .HasOne(ea => ea.Reservation)
                .WithMany(e => e.ReservationClients)
                .HasForeignKey(ea => ea.ReservationId);

            modelBuilder.Entity<ReservationClient>()
                .HasOne(ea => ea.Client)
                .WithMany(a => a.ReservationClients)
                .HasForeignKey(ea => ea.ClientId);
        }*/
    }
}