﻿// <auto-generated />
using Master.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Master.Migrations
{
    [DbContext(typeof(MasterDBContext))]
    [Migration("20240717055946_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Master.Models.ms_location", b =>
                {
                    b.Property<string>("location_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Master.Models.ms_user", b =>
                {
                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
