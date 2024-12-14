using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTV2.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocGias",
                columns: table => new
                {
                    SoTheDG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiDG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDTDG = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocGias", x => x.SoTheDG);
                });

            migrationBuilder.CreateTable(
                name: "NhaXuatBans",
                columns: table => new
                {
                    TenNXB = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiaChiNXB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDTNXB = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXuatBans", x => x.TenNXB);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuViens",
                columns: table => new
                {
                    MaThuVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuViens", x => x.MaThuVien);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "TuaSaches",
                columns: table => new
                {
                    TuaSachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTuaSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenNXB = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuaSaches", x => x.TuaSachID);
                    table.ForeignKey(
                        name: "FK_TuaSaches_NhaXuatBans_TenNXB",
                        column: x => x.TenNXB,
                        principalTable: "NhaXuatBans",
                        principalColumn: "TenNXB",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuonSaches",
                columns: table => new
                {
                    MaTuaSach = table.Column<int>(type: "int", nullable: false),
                    MaThuVien = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuonSaches", x => new { x.MaTuaSach, x.MaThuVien });
                    table.ForeignKey(
                        name: "FK_CuonSaches_ThuViens_MaThuVien",
                        column: x => x.MaThuVien,
                        principalTable: "ThuViens",
                        principalColumn: "MaThuVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuonSaches_TuaSaches_MaTuaSach",
                        column: x => x.MaTuaSach,
                        principalTable: "TuaSaches",
                        principalColumn: "TuaSachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuonSaches",
                columns: table => new
                {
                    MaTuaSach = table.Column<int>(type: "int", nullable: false),
                    MaThuVien = table.Column<int>(type: "int", nullable: false),
                    SoTheDG = table.Column<int>(type: "int", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuonSaches", x => new { x.MaTuaSach, x.MaThuVien, x.SoTheDG });
                    table.ForeignKey(
                        name: "FK_MuonSaches_DocGias_SoTheDG",
                        column: x => x.SoTheDG,
                        principalTable: "DocGias",
                        principalColumn: "SoTheDG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuonSaches_ThuViens_MaThuVien",
                        column: x => x.MaThuVien,
                        principalTable: "ThuViens",
                        principalColumn: "MaThuVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuonSaches_TuaSaches_MaTuaSach",
                        column: x => x.MaTuaSach,
                        principalTable: "TuaSaches",
                        principalColumn: "TuaSachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SachTacGias",
                columns: table => new
                {
                    TuaSachID = table.Column<int>(type: "int", nullable: false),
                    TenTacGia = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SachTacGias", x => new { x.TuaSachID, x.TenTacGia });
                    table.ForeignKey(
                        name: "FK_SachTacGias_TuaSaches_TuaSachID",
                        column: x => x.TuaSachID,
                        principalTable: "TuaSaches",
                        principalColumn: "TuaSachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuonSaches_MaThuVien",
                table: "CuonSaches",
                column: "MaThuVien");

            migrationBuilder.CreateIndex(
                name: "IX_MuonSaches_MaThuVien",
                table: "MuonSaches",
                column: "MaThuVien");

            migrationBuilder.CreateIndex(
                name: "IX_MuonSaches_SoTheDG",
                table: "MuonSaches",
                column: "SoTheDG");

            migrationBuilder.CreateIndex(
                name: "IX_TuaSaches_TenNXB",
                table: "TuaSaches",
                column: "TenNXB");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuonSaches");

            migrationBuilder.DropTable(
                name: "MuonSaches");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SachTacGias");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "DocGias");

            migrationBuilder.DropTable(
                name: "ThuViens");

            migrationBuilder.DropTable(
                name: "TuaSaches");

            migrationBuilder.DropTable(
                name: "NhaXuatBans");
        }
    }
}
