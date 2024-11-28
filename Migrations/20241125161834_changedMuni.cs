using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEleccionsM.Migrations
{
    /// <inheritdoc />
    public partial class changedMuni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PercentatgeMinimEstablert",
                table: "Municipis",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentatgeMinimEstablert",
                table: "Municipis");
        }
    }
}
