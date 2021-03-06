﻿// <auto-generated />
using System;
using MASB.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MASB.MyAirport.EF.Migrations
{
    [DbContext(typeof(MyAirportContext))]
    partial class MyAirportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MASB.MyAirport.EF.Bagage", b =>
                {
                    b.Property<int>("BagageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CLASSE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODE_IATA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DATA_CREATION")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESTINATION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ESCALE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("PRIORITAIRE")
                        .HasColumnType("tinyint");

                    b.Property<string>("SSUR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VolID")
                        .HasColumnType("int");

                    b.HasKey("BagageID");

                    b.HasIndex("VolID");

                    b.ToTable("Bagage");
                });

            modelBuilder.Entity("MASB.MyAirport.EF.Vol", b =>
                {
                    b.Property<int>("VolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CIE")
                        .HasColumnType("int");

                    b.Property<string>("DES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DHC")
                        .HasColumnType("datetime2");

                    b.Property<string>("IMM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JEK")
                        .HasColumnType("int");

                    b.Property<string>("LIG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PAX")
                        .HasColumnType("int");

                    b.Property<string>("PKG")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VolID");

                    b.ToTable("Vol");
                });

            modelBuilder.Entity("MASB.MyAirport.EF.Bagage", b =>
                {
                    b.HasOne("MASB.MyAirport.EF.Vol", "Vol")
                        .WithMany()
                        .HasForeignKey("VolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
