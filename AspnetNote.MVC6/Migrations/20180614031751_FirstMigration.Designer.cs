﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspnetNote.MVC6.DataContext;

namespace AspnetNote.MVC6.Migrations
{
    [DbContext(typeof(AspnetNoteDbContext))]
    [Migration("20180614031751_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspnetNote.MVC6.Models.Note", b =>
                {
                    b.Property<int>("NoteNo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NoteContents")
                        .IsRequired();

                    b.Property<string>("NoteTitle")
                        .IsRequired();

                    b.Property<int>("UserNo");

                    b.HasKey("NoteNo");

                    b.HasIndex("UserNo");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("AspnetNote.MVC6.Models.User", b =>
                {
                    b.Property<int>("UserNo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserPassword")
                        .IsRequired();

                    b.HasKey("UserNo");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AspnetNote.MVC6.Models.Note", b =>
                {
                    b.HasOne("AspnetNote.MVC6.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
