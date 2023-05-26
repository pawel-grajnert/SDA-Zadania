﻿// <auto-generated />
using System;
using BookRecord.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookRecord.Repository.Migrations
{
    [DbContext(typeof(BookRecordContext))]
    [Migration("20230526123752_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookRecord.Domain.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andrew",
                            Surname = "Servantes"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Conrad",
                            Surname = "Zimsky"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Agatha",
                            Surname = "Christie"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Claude",
                            Surname = "Experoxue"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Vittoria",
                            Surname = "Malisen"
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Debra",
                            Surname = "Lothsori"
                        });
                });

            modelBuilder.Entity("BookRecord.Domain.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CreationDate = new DateTime(2021, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum srata tata...",
                            GenreId = 1,
                            Isbn = "ISBN 9995554444",
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Stary Dom"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            CreationDate = new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum srata tata...",
                            GenreId = 1,
                            Isbn = "ISBN 1112223333",
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pośród Drzew"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            CreationDate = new DateTime(2020, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum srata tata...",
                            GenreId = 2,
                            Isbn = "ISBN 5554442222",
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Czarna Kawa"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            CreationDate = new DateTime(2020, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum srata tata...",
                            GenreId = 3,
                            Isbn = "ISBN 6475485585",
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Wraki czasu"
                        });
                });

            modelBuilder.Entity("BookRecord.Domain.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Criminal"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifyDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Epic Tale"
                        });
                });

            modelBuilder.Entity("BookRecord.Domain.Model.Book", b =>
                {
                    b.HasOne("BookRecord.Domain.Model.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRecord.Domain.Model.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookRecord.Domain.Model.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookRecord.Domain.Model.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
