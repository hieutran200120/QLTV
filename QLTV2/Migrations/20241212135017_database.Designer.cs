﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLTV2.Repository;

#nullable disable

namespace QLTV2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241212135017_database")]
    partial class database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
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

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("QLTV2.Models.AppUserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QLTV2.Models.CuonSach", b =>
                {
                    b.Property<int>("MaTuaSach")
                        .HasColumnType("int");

                    b.Property<int>("MaThuVien")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaTuaSach", "MaThuVien");

                    b.HasIndex("MaThuVien");

                    b.ToTable("CuonSaches");
                });

            modelBuilder.Entity("QLTV2.Models.DocGia", b =>
                {
                    b.Property<int>("SoTheDG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoTheDG"));

                    b.Property<string>("DiaChiDG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDTDG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SoTheDG");

                    b.ToTable("DocGias");
                });

            modelBuilder.Entity("QLTV2.Models.MuonSach", b =>
                {
                    b.Property<int>("MaTuaSach")
                        .HasColumnType("int");

                    b.Property<int>("MaThuVien")
                        .HasColumnType("int");

                    b.Property<int>("SoTheDG")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayMuon")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTra")
                        .HasColumnType("datetime2");

                    b.HasKey("MaTuaSach", "MaThuVien", "SoTheDG");

                    b.HasIndex("MaThuVien");

                    b.HasIndex("SoTheDG");

                    b.ToTable("MuonSaches");
                });

            modelBuilder.Entity("QLTV2.Models.NhaXuatBan", b =>
                {
                    b.Property<string>("TenNXB")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChiNXB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDTNXB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TenNXB");

                    b.ToTable("NhaXuatBans");
                });

            modelBuilder.Entity("QLTV2.Models.SachTacGia", b =>
                {
                    b.Property<int>("TuaSachID")
                        .HasColumnType("int");

                    b.Property<string>("TenTacGia")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TuaSachID", "TenTacGia");

                    b.ToTable("SachTacGias");
                });

            modelBuilder.Entity("QLTV2.Models.ThuVien", b =>
                {
                    b.Property<int>("MaThuVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaThuVien"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenThuVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaThuVien");

                    b.ToTable("ThuViens");
                });

            modelBuilder.Entity("QLTV2.Models.TuaSach", b =>
                {
                    b.Property<int>("TuaSachID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TuaSachID"));

                    b.Property<string>("TenNXB")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenTuaSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TuaSachID");

                    b.HasIndex("TenNXB");

                    b.ToTable("TuaSaches");
                });

            modelBuilder.Entity("QLTV2.Models.CuonSach", b =>
                {
                    b.HasOne("QLTV2.Models.ThuVien", "ThuVien")
                        .WithMany()
                        .HasForeignKey("MaThuVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLTV2.Models.TuaSach", "TuaSach")
                        .WithMany()
                        .HasForeignKey("MaTuaSach")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThuVien");

                    b.Navigation("TuaSach");
                });

            modelBuilder.Entity("QLTV2.Models.MuonSach", b =>
                {
                    b.HasOne("QLTV2.Models.ThuVien", "ThuVien")
                        .WithMany()
                        .HasForeignKey("MaThuVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLTV2.Models.TuaSach", "TuaSach")
                        .WithMany()
                        .HasForeignKey("MaTuaSach")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLTV2.Models.DocGia", "DocGia")
                        .WithMany()
                        .HasForeignKey("SoTheDG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocGia");

                    b.Navigation("ThuVien");

                    b.Navigation("TuaSach");
                });

            modelBuilder.Entity("QLTV2.Models.SachTacGia", b =>
                {
                    b.HasOne("QLTV2.Models.TuaSach", "TuaSach")
                        .WithMany()
                        .HasForeignKey("TuaSachID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TuaSach");
                });

            modelBuilder.Entity("QLTV2.Models.TuaSach", b =>
                {
                    b.HasOne("QLTV2.Models.NhaXuatBan", "NhaXuatBan")
                        .WithMany("TuaSaches")
                        .HasForeignKey("TenNXB")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaXuatBan");
                });

            modelBuilder.Entity("QLTV2.Models.NhaXuatBan", b =>
                {
                    b.Navigation("TuaSaches");
                });
#pragma warning restore 612, 618
        }
    }
}
