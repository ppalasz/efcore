﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesApp.DAL.Models;

namespace MoviesApp.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    partial class MoviesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesApp.DAL.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Street");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("MoviesApp.DAL.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MoviesApp.DAL.Models.Movie", b =>
                {
                    b.Property<int>("IdMovie")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(100);

                    b.Property<int?>("IdGenre");

                    b.Property<int?>("IdSecondaryGenre");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("FilmTitle");

                    b.Property<short>("Year")
                        .HasMaxLength(4);

                    b.HasKey("IdMovie");

                    b.HasIndex("IdGenre");

                    b.HasIndex("IdSecondaryGenre");

                    b.ToTable("Movie","Data");
                });

            modelBuilder.Entity("MoviesApp.DAL.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressID");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Sex")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AddressID")
                        .IsUnique();

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("MoviesApp.MovieXActor", b =>
                {
                    b.Property<int>("ActorId");

                    b.Property<int>("MovieId");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieXActor");
                });

            modelBuilder.Entity("MoviesApp.DAL.Models.Actor", b =>
                {
                    b.HasBaseType("MoviesApp.DAL.Models.Person");

                    b.HasDiscriminator().HasValue("Actor");
                });

            modelBuilder.Entity("MoviesApp.DAL.Models.Director", b =>
                {
                    b.HasBaseType("MoviesApp.DAL.Models.Person");

                    b.Property<bool>("AppearedAsActor");

                    b.HasDiscriminator().HasValue("Director");
                });

            modelBuilder.Entity("MoviesApp.DAL.Models.Movie", b =>
                {
                    b.HasOne("MoviesApp.DAL.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("IdGenre");

                    b.HasOne("MoviesApp.DAL.Models.Genre", "GenreSecondary")
                        .WithMany("MoviesSecondary")
                        .HasForeignKey("IdSecondaryGenre");

                    b.OwnsOne("MoviesApp.DAL.Models.FinancialData", "FinancialData", b1 =>
                        {
                            b1.Property<int>("MovieIdMovie")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("ProductionCost");

                            b1.Property<decimal>("Revenue");

                            b1.HasKey("MovieIdMovie");

                            b1.ToTable("Movie","Data");

                            b1.HasOne("MoviesApp.DAL.Models.Movie")
                                .WithOne("FinancialData")
                                .HasForeignKey("MoviesApp.DAL.Models.FinancialData", "MovieIdMovie")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MoviesApp.DAL.Models.Person", b =>
                {
                    b.HasOne("MoviesApp.DAL.Models.Address", "Address")
                        .WithOne("Person")
                        .HasForeignKey("MoviesApp.DAL.Models.Person", "AddressID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoviesApp.MovieXActor", b =>
                {
                    b.HasOne("MoviesApp.DAL.Models.Actor", "Actor")
                        .WithMany("MoviesActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoviesApp.DAL.Models.Movie", "Movie")
                        .WithMany("MoviesActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}