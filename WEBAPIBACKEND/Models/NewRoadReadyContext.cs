﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WEBAPIBACKEND.Models
{
    public partial class NewRoadReadyContext : DbContext
    {
        public NewRoadReadyContext()
        {
        }

        public NewRoadReadyContext(DbContextOptions<NewRoadReadyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<CarListing> CarListings { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-FBNFDUHS;database=NewRoadReady;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.Email, "UQ__Admin__A9D105342ECD9C45")
                    .IsUnique();

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.RePassword).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<CarListing>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__CarListi__68A0340EAEE46A43");

                entity.ToTable("CarListing");

                entity.HasIndex(e => e.CarPlateNumber, "UQ__CarListi__748419D177943734")
                    .IsUnique();

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.AvailableFrom).HasColumnType("datetime");

                entity.Property(e => e.AvailableTo).HasColumnType("datetime");

                entity.Property(e => e.CarCreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CarPlateNumber).HasMaxLength(30);

                entity.Property(e => e.CarType).HasMaxLength(50);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.DailyRate).HasColumnType("money");

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Mileage).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.Transmission).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.EmailAddress, "UQ__Customer__49A1474072E6C289")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E3877CB89BB")
                    .IsUnique();

                entity.HasIndex(e => e.LicenseNumber, "UQ__Customer__E8890166487DA3D9")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EmailAddress).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LicenseNumber).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.RePassword).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(30);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ReviewDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Feedback__CarID__4CA06362");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Feedback__Custom__4D94879B");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.HasIndex(e => e.Email, "UQ__Login__A9D105349BBA4A3D")
                    .IsUnique();

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(30);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Login__AdminID__4E88ABD4");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Login__CustomerI__4F7CD00D");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__PaymentD__9B556A5834E372B9");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionStatus).HasMaxLength(30);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PaymentDe__CarID__5070F446");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PaymentDe__Custo__5165187F");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DropoffDateTime).HasColumnType("datetime");

                entity.Property(e => e.PaidAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PickupDateTime).HasColumnType("datetime");

                entity.Property(e => e.ReservationStatus)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Waiting')");

                entity.Property(e => e.ReservationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reservati__CarID__52593CB8");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reservati__Custo__534D60F1");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Reservati__Payme__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
