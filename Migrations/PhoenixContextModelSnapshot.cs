﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Phoenix.Data;

#nullable disable

namespace Phoenix.Migrations
{
    [DbContext(typeof(PhoenixContext))]
    partial class PhoenixContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Phoenix.Domains.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("sta_name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "idx_sta_name")
                        .IsUnique();

                    b.ToTable("status");
                });

            modelBuilder.Entity("Phoenix.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("pro_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("pro_name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "idx_pro_name")
                        .IsUnique();

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("Phoenix.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("usr_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("usr_created");

                    b.Property<DateTime>("Deleted")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("usr_deleted");

                    b.Property<string>("Email")
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("usr_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("usr_name");

                    b.Property<string>("Password")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("usr_password");

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer")
                        .HasColumnName("pro_id");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("usr_updated");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Name" }, "idx_usr_name")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("Phoenix.Models.User", b =>
                {
                    b.HasOne("Phoenix.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
