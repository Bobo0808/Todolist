﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sandy.Models;

public partial class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todolist> Todolist { get; set; }

    public virtual DbSet<Webuser> Webuser { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => e.TodoID).HasName("PK__Todolist__95862572488BA860");

            entity.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Remark)
                .IsRequired()
                .HasColumnType("text");
            entity.Property(e => e.ScaheduledDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Todolist)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Todolist__UserID__398D8EEE");
        });

        modelBuilder.Entity<Webuser>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK__Webuser__1788CCACD6038E7D");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.PWD)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}