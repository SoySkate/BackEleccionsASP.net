using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEleccionsM.Migrations
{
    /// <inheritdoc />
    public partial class OneMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMunicipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroRegidors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PartitsPolitics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPartit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitsPolitics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PartitsPolitics_Municipis_MunicipiId",
                        column: x => x.MunicipiId,
                        principalTable: "Municipis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaulesElectorals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomTaula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CensTaula = table.Column<int>(type: "int", nullable: false),
                    MunicipiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaulesElectorals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaulesElectorals_Municipis_MunicipiId",
                        column: x => x.MunicipiId,
                        principalTable: "Municipis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCandidat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartitPoliticId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Candidats_PartitsPolitics_PartitPoliticId",
                        column: x => x.PartitPoliticId,
                        principalTable: "PartitsPolitics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultatsTaules",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VotsBlanc = table.Column<int>(type: "int", nullable: false),
                    VotsNul = table.Column<int>(type: "int", nullable: false),
                    VotsTotals = table.Column<int>(type: "int", nullable: false),
                    TaulaElectoralId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultatsTaules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ResultatsTaules_TaulesElectorals_TaulaElectoralId",
                        column: x => x.TaulaElectoralId,
                        principalTable: "TaulesElectorals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotsPerPartit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroVotsLlista = table.Column<int>(type: "int", nullable: false),
                    PartitId = table.Column<int>(type: "int", nullable: false),
                    ResultatsTaulaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotsPerPartit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VotsPerPartit_PartitsPolitics_PartitId",
                        column: x => x.PartitId,
                        principalTable: "PartitsPolitics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VotsPerPartit_ResultatsTaules_ResultatsTaulaId",
                        column: x => x.ResultatsTaulaId,
                        principalTable: "ResultatsTaules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidats_PartitPoliticId",
                table: "Candidats",
                column: "PartitPoliticId");

            migrationBuilder.CreateIndex(
                name: "IX_PartitsPolitics_MunicipiId",
                table: "PartitsPolitics",
                column: "MunicipiId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatsTaules_TaulaElectoralId",
                table: "ResultatsTaules",
                column: "TaulaElectoralId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaulesElectorals_MunicipiId",
                table: "TaulesElectorals",
                column: "MunicipiId");

            migrationBuilder.CreateIndex(
                name: "IX_VotsPerPartit_PartitId",
                table: "VotsPerPartit",
                column: "PartitId");

            migrationBuilder.CreateIndex(
                name: "IX_VotsPerPartit_ResultatsTaulaId",
                table: "VotsPerPartit",
                column: "ResultatsTaulaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidats");

            migrationBuilder.DropTable(
                name: "VotsPerPartit");

            migrationBuilder.DropTable(
                name: "PartitsPolitics");

            migrationBuilder.DropTable(
                name: "ResultatsTaules");

            migrationBuilder.DropTable(
                name: "TaulesElectorals");

            migrationBuilder.DropTable(
                name: "Municipis");
        }
    }
}
