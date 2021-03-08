﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VerwaltungSchuelerdaten.Data;

namespace VerwaltungSchuelerdaten.Migrations
{
    [DbContext(typeof(VerwaltungSchuelerdatenContext))]
    partial class VerwaltungSchuelerdatenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VerwaltungSchuelerdaten.Models.Adresse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strasse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Adresse");
                });

            modelBuilder.Entity("VerwaltungSchuelerdaten.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("VerwaltungSchuelerdaten.Models.Klasse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschreibung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KlassenSprecherInID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KlassenSprecherInID");

                    b.ToTable("Klassen");
                });

            modelBuilder.Entity("VerwaltungSchuelerdaten.Models.Note", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschreibung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Notenwert")
                        .HasColumnType("int");

                    b.Property<int?>("SchuelerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SchuelerID");

                    b.ToTable("Noten");
                });

            modelBuilder.Entity("VerwaltungSchuelerdaten.Models.SchuelerDaten", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Anmeldedatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Geburtsdatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KlasseID")
                        .HasColumnType("int");

                    b.Property<string>("Kommentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Konfession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Staatsangehoerigkeit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefonnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZweiteStaatsangehoerigkeit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AdresseID");

                    b.HasIndex("KlasseID");

                    b.ToTable("SchuelerDaten");
                });

            modelBuilder.Entity("VerwaltungSchuelerdaten.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("VideoData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("VideoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("VerwaltungSchuelerdaten.Models.Klasse", b =>
                {
                    b.HasOne("VerwaltungSchuelerdaten.Models.SchuelerDaten", "KlassenSprecherIn")
                        .WithMany()
                        .HasForeignKey("KlassenSprecherInID");
                });

            modelBuilder.Entity("VerwaltungSchuelerdaten.Models.Note", b =>
                {
                    b.HasOne("VerwaltungSchuelerdaten.Models.SchuelerDaten", "Schueler")
                        .WithMany("Noten")
                        .HasForeignKey("SchuelerID");
                });

            modelBuilder.Entity("VerwaltungSchuelerdaten.Models.SchuelerDaten", b =>
                {
                    b.HasOne("VerwaltungSchuelerdaten.Models.Adresse", "Adresse")
                        .WithMany()
                        .HasForeignKey("AdresseID");

                    b.HasOne("VerwaltungSchuelerdaten.Models.Klasse", "Klasse")
                        .WithMany("Schueler")
                        .HasForeignKey("KlasseID");
                });
#pragma warning restore 612, 618
        }
    }
}
