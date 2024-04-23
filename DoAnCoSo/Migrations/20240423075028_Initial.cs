using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnCoSo.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    ID_ChucVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_ChucVu = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.ID_ChucVu);
                });

            migrationBuilder.CreateTable(
                name: "diaDiems",
                columns: table => new
                {
                    ID_DiaDiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_DiaDiem = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diaDiems", x => x.ID_DiaDiem);
                });

            migrationBuilder.CreateTable(
                name: "hangXes",
                columns: table => new
                {
                    ID_HangXe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_HangXe = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hangXes", x => x.ID_HangXe);
                });

            migrationBuilder.CreateTable(
                name: "loaiXes",
                columns: table => new
                {
                    ID_LoaiXe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_LoaiXe = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiXes", x => x.ID_LoaiXe);
                });

            migrationBuilder.CreateTable(
                name: "quyens",
                columns: table => new
                {
                    ID_Quyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Quyen = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quyens", x => x.ID_Quyen);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanCuocCongDan = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    NgayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "ntext", nullable: true),
                    GiayPhepLaiXe = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false),
                    ID_ChucVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.Email);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_ChucVus_ID_ChucVu",
                        column: x => x.ID_ChucVu,
                        principalTable: "ChucVus",
                        principalColumn: "ID_ChucVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phanQuyens",
                columns: table => new
                {
                    Id_Quyen = table.Column<int>(type: "int", nullable: false),
                    Id_ChucVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phanQuyens", x => new { x.Id_Quyen, x.Id_ChucVu });
                    table.ForeignKey(
                        name: "FK_phanQuyens_ChucVus_Id_ChucVu",
                        column: x => x.Id_ChucVu,
                        principalTable: "ChucVus",
                        principalColumn: "ID_ChucVu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phanQuyens_quyens_Id_Quyen",
                        column: x => x.Id_Quyen,
                        principalTable: "quyens",
                        principalColumn: "ID_Quyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "xes",
                columns: table => new
                {
                    BienSoXe = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    TenXe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ID_Loai = table.Column<int>(type: "int", nullable: false),
                    ID_HangXe = table.Column<int>(type: "int", nullable: false),
                    ID_DiaDiem = table.Column<int>(type: "int", nullable: false),
                    GiaThue = table.Column<ulong>(type: "bigint", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    AnhXe = table.Column<string>(type: "ntext", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xes", x => x.BienSoXe);
                    table.ForeignKey(
                        name: "FK_xes_TaiKhoans_Email",
                        column: x => x.Email,
                        principalTable: "TaiKhoans",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_xes_diaDiems_ID_DiaDiem",
                        column: x => x.ID_DiaDiem,
                        principalTable: "diaDiems",
                        principalColumn: "ID_DiaDiem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_xes_hangXes_ID_HangXe",
                        column: x => x.ID_HangXe,
                        principalTable: "hangXes",
                        principalColumn: "ID_HangXe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_xes_loaiXes_ID_Loai",
                        column: x => x.ID_Loai,
                        principalTable: "loaiXes",
                        principalColumn: "ID_LoaiXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "datLichThueXes",
                columns: table => new
                {
                    ID_DatLich = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BienSoXe = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datLichThueXes", x => new { x.ID_DatLich, x.Email, x.BienSoXe });
                    table.ForeignKey(
                        name: "FK_datLichThueXes_TaiKhoans_Email",
                        column: x => x.Email,
                        principalTable: "TaiKhoans",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datLichThueXes_xes_BienSoXe",
                        column: x => x.BienSoXe,
                        principalTable: "xes",
                        principalColumn: "BienSoXe");
                });

            migrationBuilder.CreateTable(
                name: "hinhAnhXes",
                columns: table => new
                {
                    ID_HinhAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL_HinhAnh = table.Column<string>(type: "ntext", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false),
                    BienSoXe = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hinhAnhXes", x => x.ID_HinhAnh);
                    table.ForeignKey(
                        name: "FK_hinhAnhXes_xes_BienSoXe",
                        column: x => x.BienSoXe,
                        principalTable: "xes",
                        principalColumn: "BienSoXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoaDons",
                columns: table => new
                {
                    Id_HoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DatLich = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BienSoXe = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDons", x => x.Id_HoaDon);
                    table.ForeignKey(
                        name: "FK_hoaDons_datLichThueXes_ID_DatLich_Email_BienSoXe",
                        columns: x => new { x.ID_DatLich, x.Email, x.BienSoXe },
                        principalTable: "datLichThueXes",
                        principalColumns: new[] { "ID_DatLich", "Email", "BienSoXe" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_datLichThueXes_BienSoXe",
                table: "datLichThueXes",
                column: "BienSoXe");

            migrationBuilder.CreateIndex(
                name: "IX_datLichThueXes_Email",
                table: "datLichThueXes",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_hinhAnhXes_BienSoXe",
                table: "hinhAnhXes",
                column: "BienSoXe");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_ID_DatLich_Email_BienSoXe",
                table: "hoaDons",
                columns: new[] { "ID_DatLich", "Email", "BienSoXe" });

            migrationBuilder.CreateIndex(
                name: "IX_phanQuyens_Id_ChucVu",
                table: "phanQuyens",
                column: "Id_ChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_CanCuocCongDan",
                table: "TaiKhoans",
                column: "CanCuocCongDan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_GiayPhepLaiXe",
                table: "TaiKhoans",
                column: "GiayPhepLaiXe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_ID_ChucVu",
                table: "TaiKhoans",
                column: "ID_ChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_SoDienThoai",
                table: "TaiKhoans",
                column: "SoDienThoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_xes_Email",
                table: "xes",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_xes_ID_DiaDiem",
                table: "xes",
                column: "ID_DiaDiem");

            migrationBuilder.CreateIndex(
                name: "IX_xes_ID_HangXe",
                table: "xes",
                column: "ID_HangXe");

            migrationBuilder.CreateIndex(
                name: "IX_xes_ID_Loai",
                table: "xes",
                column: "ID_Loai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hinhAnhXes");

            migrationBuilder.DropTable(
                name: "hoaDons");

            migrationBuilder.DropTable(
                name: "phanQuyens");

            migrationBuilder.DropTable(
                name: "datLichThueXes");

            migrationBuilder.DropTable(
                name: "quyens");

            migrationBuilder.DropTable(
                name: "xes");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "diaDiems");

            migrationBuilder.DropTable(
                name: "hangXes");

            migrationBuilder.DropTable(
                name: "loaiXes");

            migrationBuilder.DropTable(
                name: "ChucVus");
        }
    }
}
