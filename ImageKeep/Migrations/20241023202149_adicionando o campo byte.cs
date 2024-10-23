using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageKeep.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoocampobyte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Fotos",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Fotos");
        }
    }
}
