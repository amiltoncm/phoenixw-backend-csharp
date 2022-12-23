﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Phoenix.Data;

#nullable disable

namespace Phoenix.Migrations
{
    [DbContext(typeof(PhoenixContext))]
    [Migration("20221223170156_TableAdressTypes")]
    partial class TableAdressTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Phoenix.Domains.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("adt_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("adt_name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "idx_adt_name")
                        .IsUnique();

                    b.ToTable("address_types");
                });

            modelBuilder.Entity("Phoenix.Domains.MovimentType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("mvt_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("mvt_name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "idx_mvt_name")
                        .IsUnique();

                    b.ToTable("moviment_types");
                });

            modelBuilder.Entity("Phoenix.Domains.PaymentIndication", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("pin_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("pin_name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "idx_pin_name")
                        .IsUnique();

                    b.ToTable("payment_indications");
                });

            modelBuilder.Entity("Phoenix.Domains.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("pty_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("pty_name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "idx_pty_name")
                        .IsUnique();

                    b.ToTable("payment_types");
                });

            modelBuilder.Entity("Phoenix.Domains.PersonType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("pet_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("pet_name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "idx_pet_name")
                        .IsUnique();

                    b.ToTable("person_types");
                });

            modelBuilder.Entity("Phoenix.Domains.Profile", b =>
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

            modelBuilder.Entity("Phoenix.Domains.PublicPlace", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("pup_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("pup_name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "idx_pup_name")
                        .IsUnique();

                    b.ToTable("public_places");
                });

            modelBuilder.Entity("Phoenix.Domains.Status", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

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

            modelBuilder.Entity("Phoenix.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("acc_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BankId")
                        .HasColumnType("integer")
                        .HasColumnName("bnk_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("acc_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("acc_name");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("acc_updated");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Name" }, "idx_acc_name")
                        .IsUnique();

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("Phoenix.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("bnk_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("bnk_code");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("bnk_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("bnk_name");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("bnk_updated");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Code" }, "idx_bnk_code")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "idx_bnk_name")
                        .IsUnique();

                    b.ToTable("banks");
                });

            modelBuilder.Entity("Phoenix.Models.ChartAccounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cac_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cac_created");

                    b.Property<string>("MovimentTypeId")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("mvt_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cac_name");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cac_updated");

                    b.HasKey("Id");

                    b.HasIndex("MovimentTypeId");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Name" }, "idx_cac_name")
                        .IsUnique();

                    b.ToTable("chart_accounts");
                });

            modelBuilder.Entity("Phoenix.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cti_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("cti_code");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cti_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cti_name");

                    b.Property<int>("StateId")
                        .HasColumnType("integer")
                        .HasColumnName("ste_id");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cti_updated");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Name" }, "idx_cti_name");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("Phoenix.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cnt_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cnt_created");

                    b.Property<string>("Iso2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("cnt_iso2");

                    b.Property<string>("Iso3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("cnt_iso3");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cnt_name");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cnt_updated");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Iso2" }, "idx_cnt_iso2")
                        .IsUnique();

                    b.HasIndex(new[] { "Iso3" }, "idx_cnt_iso3")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "idx_cnt_name")
                        .IsUnique();

                    b.ToTable("countries");
                });

            modelBuilder.Entity("Phoenix.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("pay_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("acc_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("pay_created");

                    b.Property<int?>("Days")
                        .HasColumnType("integer")
                        .HasColumnName("pay_days");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("pay_name");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("pty_id");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("pay_updated");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Name" }, "idx_pay_name")
                        .IsUnique();

                    b.ToTable("payment_methods");
                });

            modelBuilder.Entity("Phoenix.Models.PaymentTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("pyt_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("pty_created");

                    b.Property<float>("Fees")
                        .HasColumnType("real")
                        .HasColumnName("pyt_fees");

                    b.Property<int>("Installments")
                        .HasColumnType("integer")
                        .HasColumnName("pyt_installments");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("pyt_name");

                    b.Property<int>("PaymentIndicationId")
                        .HasColumnType("integer")
                        .HasColumnName("pin_id");

                    b.Property<int>("Period")
                        .HasColumnType("integer")
                        .HasColumnName("pyt_periods");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("pty_updated");

                    b.HasKey("Id");

                    b.HasIndex("PaymentIndicationId");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Name" }, "idx_pyt_name")
                        .IsUnique();

                    b.ToTable("payment_terms");
                });

            modelBuilder.Entity("Phoenix.Models.PaymentTermMethod", b =>
                {
                    b.Property<int>("PaymentTermId")
                        .HasColumnType("integer")
                        .HasColumnName("pyt_id");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("integer")
                        .HasColumnName("pay_id");

                    b.HasKey("PaymentTermId", "PaymentMethodId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("payment_term_methods");
                });

            modelBuilder.Entity("Phoenix.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("peo_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("peo_address");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("peo_alias");

                    b.Property<bool>("Associate")
                        .HasColumnType("boolean")
                        .HasColumnName("peo_associate");

                    b.Property<int>("CityId")
                        .HasColumnType("integer")
                        .HasColumnName("cti_id");

                    b.Property<bool>("Client")
                        .HasColumnType("boolean")
                        .HasColumnName("peo_client");

                    b.Property<string>("Complement")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("peo_complement");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("peo_created");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("peo_deleted");

                    b.Property<string>("District")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("peo_district");

                    b.Property<string>("Document")
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)")
                        .HasColumnName("peo_document");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("peo_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("peo_name");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("peo_number");

                    b.Property<string>("PersonTypeId")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("pet_id");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("peo_phone");

                    b.Property<bool>("Provider")
                        .HasColumnType("boolean")
                        .HasColumnName("peo_provider");

                    b.Property<int>("PublicPlaceId")
                        .HasColumnType("integer")
                        .HasColumnName("pup_id");

                    b.Property<string>("Reference")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("peo_reference");

                    b.Property<string>("Registration")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("peo_resgistration");

                    b.Property<bool>("Shipping")
                        .HasColumnType("boolean")
                        .HasColumnName("peo_shipping");

                    b.Property<int>("StatusID")
                        .HasColumnType("integer")
                        .HasColumnName("peo_status");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("peo_updated");

                    b.Property<string>("Zip")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("peo_zip");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PersonTypeId");

                    b.HasIndex("PublicPlaceId");

                    b.HasIndex("StatusID");

                    b.HasIndex(new[] { "Alias" }, "idx_peo_alias");

                    b.HasIndex(new[] { "Name" }, "idx_peo_name");

                    b.ToTable("people");
                });

            modelBuilder.Entity("Phoenix.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ste_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("ste_abbreviation");

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("ste_code");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer")
                        .HasColumnName("cnt_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ste_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("ste_name");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("sta_id");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ste_updated");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Name" }, "idx_ste_name");

                    b.ToTable("states");
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

                    b.Property<DateTime?>("Deleted")
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
                        .IsRequired()
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

            modelBuilder.Entity("Phoenix.Models.Account", b =>
                {
                    b.HasOne("Phoenix.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Phoenix.Models.Bank", b =>
                {
                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Phoenix.Models.ChartAccounts", b =>
                {
                    b.HasOne("Phoenix.Domains.MovimentType", "MovimentType")
                        .WithMany()
                        .HasForeignKey("MovimentTypeId");

                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovimentType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Phoenix.Models.City", b =>
                {
                    b.HasOne("Phoenix.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Phoenix.Models.Country", b =>
                {
                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Phoenix.Models.PaymentMethod", b =>
                {
                    b.HasOne("Phoenix.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("Phoenix.Domains.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("PaymentType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Phoenix.Models.PaymentTerm", b =>
                {
                    b.HasOne("Phoenix.Domains.PaymentIndication", "PaymentIndication")
                        .WithMany()
                        .HasForeignKey("PaymentIndicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentIndication");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Phoenix.Models.PaymentTermMethod", b =>
                {
                    b.HasOne("Phoenix.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Models.PaymentTerm", "PaymentTerm")
                        .WithMany()
                        .HasForeignKey("PaymentTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");

                    b.Navigation("PaymentTerm");
                });

            modelBuilder.Entity("Phoenix.Models.Person", b =>
                {
                    b.HasOne("Phoenix.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Domains.PersonType", "PersonType")
                        .WithMany()
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Domains.PublicPlace", "PublicPlace")
                        .WithMany()
                        .HasForeignKey("PublicPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("PersonType");

                    b.Navigation("PublicPlace");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Phoenix.Models.State", b =>
                {
                    b.HasOne("Phoenix.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Phoenix.Domains.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Phoenix.Models.User", b =>
                {
                    b.HasOne("Phoenix.Domains.Profile", "Profile")
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
