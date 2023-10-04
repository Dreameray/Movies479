﻿// <auto-generated />
using System;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20231004141340_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataAccess.Entities.MovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("DataAccess.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Records");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Record");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DataAccess.Entities.Director", b =>
                {
                    b.HasBaseType("DataAccess.Record");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsRetired")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.ToTable("Records", t =>
                        {
                            t.Property("Name")
                                .HasColumnName("Director_Name");
                        });

                    b.HasDiscriminator().HasValue("Director");
                });

            modelBuilder.Entity("DataAccess.Entities.Genre", b =>
                {
                    b.HasBaseType("DataAccess.Record");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.ToTable("Records", t =>
                        {
                            t.Property("Name")
                                .HasColumnName("Genre_Name");
                        });

                    b.HasDiscriminator().HasValue("Genre");
                });

            modelBuilder.Entity("DataAccess.Entities.Movie", b =>
                {
                    b.HasBaseType("DataAccess.Record");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<double>("Revenue")
                        .HasColumnType("double");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasIndex("DirectorId");

                    b.HasIndex("GenreId");

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("DataAccess.Entities.MovieGenre", b =>
                {
                    b.HasOne("DataAccess.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("DataAccess.Entities.Movie", b =>
                {
                    b.HasOne("DataAccess.Entities.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Genre", null)
                        .WithMany("Movies")
                        .HasForeignKey("GenreId");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("DataAccess.Entities.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("DataAccess.Entities.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
