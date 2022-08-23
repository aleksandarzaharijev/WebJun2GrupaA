using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kompanija",
                columns: table => new
                {
                    KompanijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prihod = table.Column<int>(type: "int", nullable: false),
                    BrojAngazovanja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompanija", x => x.KompanijaID);
                });

            migrationBuilder.CreateTable(
                name: "TipPrevoza",
                columns: table => new
                {
                    TipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPrevoza", x => x.TipID);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    VoziloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrevozTipID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.VoziloID);
                    table.ForeignKey(
                        name: "FK_Vozilo_TipPrevoza_PrevozTipID",
                        column: x => x.PrevozTipID,
                        principalTable: "TipPrevoza",
                        principalColumn: "TipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dostava",
                columns: table => new
                {
                    DostavaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZapreminaPaketa = table.Column<int>(type: "int", nullable: false),
                    TezinaPaketa = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    DatumPrijema = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDostave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KompanijaSpojKompanijaID = table.Column<int>(type: "int", nullable: true),
                    VoziloSpojVoziloID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostava", x => x.DostavaID);
                    table.ForeignKey(
                        name: "FK_Dostava_Kompanija_KompanijaSpojKompanijaID",
                        column: x => x.KompanijaSpojKompanijaID,
                        principalTable: "Kompanija",
                        principalColumn: "KompanijaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dostava_Vozilo_VoziloSpojVoziloID",
                        column: x => x.VoziloSpojVoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "VoziloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dostava_KompanijaSpojKompanijaID",
                table: "Dostava",
                column: "KompanijaSpojKompanijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Dostava_VoziloSpojVoziloID",
                table: "Dostava",
                column: "VoziloSpojVoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_PrevozTipID",
                table: "Vozilo",
                column: "PrevozTipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dostava");

            migrationBuilder.DropTable(
                name: "Kompanija");

            migrationBuilder.DropTable(
                name: "Vozilo");

            migrationBuilder.DropTable(
                name: "TipPrevoza");
        }
    }
}
