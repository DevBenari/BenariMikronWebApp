﻿// <auto-generated />
using System;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BenariMikronWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240223105429_UpdateTambahPasienBaru7")]
    partial class UpdateTambahPasienBaru7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BenariMikronWebApp.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NamaBelakang")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NamaDepan")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BenariMikronWebApp.Models.PasienBaru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AgamaPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlamatDomisiliPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlamatKantorPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlamatKeluargaPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlergiPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BagianPenjamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EmailAktifPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenerateQrCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GolonganDarahPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrupPenjamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HubunganKeluargaPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HubunganPenjamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InformasiAlamatPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisKelaminPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KaryawanRumahSakit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KewarganegaraanPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodePasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifyDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NamaAyahPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaIbuPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaKantorPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaKeluargaTerdekatPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaLengkapPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaPegawaiPenjamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaSutriPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorIdentitasPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorIdentitasSutriPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorPolisPenjamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorRekamMedisBaru")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorRekamMedisLama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorTeleponKantorPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorTeleponKeluargaPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorTeleponPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasienPrioritas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PekerjaanAyahPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PekerjaanIbuPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PekerjaanPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PekerjaanSutriPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PendidikanTerakhirPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PenjaminId")
                        .HasColumnType("int");

                    b.Property<string>("Perusahaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SukuPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TanggalKelahiranPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempatKelahiranPasien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PenjaminId");

                    b.ToTable("AdmPasienBaru", "dbo");
                });

            modelBuilder.Entity("BenariMikronWebApp.Models.Penjamin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AkhirKerjasama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AkunBankAtasNama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AkunBankKartuKredit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlamatTagihan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bagian")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Direktur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diskon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jabatan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JatuhTempo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisKerjasama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisKontrak")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodePenjamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodePerusahaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodePos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KomisiKartuKredit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KriteriaPembayaran")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenjaminPasienOTC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifyDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MulaiKerjasama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaBank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaCabang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaKontak")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaPerusahaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorFax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorRekeningBank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorTelepon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PerusahaanPenjamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pinalti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarifGroupPerusahaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TermasukPenjamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TermasukPenjaminRS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipePerusahaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdmPenjamin", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BenariMikronWebApp.Models.PasienBaru", b =>
                {
                    b.HasOne("BenariMikronWebApp.Models.Penjamin", "Penjamin")
                        .WithMany("PasienBaru")
                        .HasForeignKey("PenjaminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Penjamin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BenariMikronWebApp.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BenariMikronWebApp.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenariMikronWebApp.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BenariMikronWebApp.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BenariMikronWebApp.Models.Penjamin", b =>
                {
                    b.Navigation("PasienBaru");
                });
#pragma warning restore 612, 618
        }
    }
}
