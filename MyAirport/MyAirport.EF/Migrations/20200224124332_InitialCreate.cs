using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MASB.MyAirport.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vol",
                columns: table => new
                {
                    VolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIE = table.Column<int>(nullable: false),
                    LIG = table.Column<string>(nullable: true),
                    JEK = table.Column<int>(nullable: false),
                    DHC = table.Column<DateTime>(nullable: false),
                    PKG = table.Column<string>(nullable: true),
                    IMM = table.Column<string>(nullable: true),
                    PAX = table.Column<int>(nullable: false),
                    DES = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vol", x => x.VolID);
                });

            migrationBuilder.CreateTable(
                name: "Bagage",
                columns: table => new
                {
                    BagageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolID = table.Column<int>(nullable: false),
                    CODE_IATA = table.Column<string>(nullable: true),
                    DATA_CREATION = table.Column<DateTime>(nullable: false),
                    CLASSE = table.Column<string>(nullable: true),
                    PRIORITAIRE = table.Column<byte>(nullable: false),
                    STA = table.Column<string>(nullable: true),
                    SSUR = table.Column<string>(nullable: true),
                    DESTINATION = table.Column<string>(nullable: true),
                    ESCALE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bagage", x => x.BagageID);
                    table.ForeignKey(
                        name: "FK_Bagage_Vol_VolID",
                        column: x => x.VolID,
                        principalTable: "Vol",
                        principalColumn: "VolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bagage_VolID",
                table: "Bagage",
                column: "VolID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bagage");

            migrationBuilder.DropTable(
                name: "Vol");
        }
    }
}
