using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetOwnerAPI.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetInfoDto");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "PetInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetInfos_OwnerId",
                table: "PetInfos",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetInfos_Owners_OwnerId",
                table: "PetInfos",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetInfos_Owners_OwnerId",
                table: "PetInfos");

            migrationBuilder.DropIndex(
                name: "IX_PetInfos_OwnerId",
                table: "PetInfos");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "PetInfos");

            migrationBuilder.CreateTable(
                name: "PetInfoDto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetInfoDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetInfoDto_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetInfoDto_OwnerId",
                table: "PetInfoDto",
                column: "OwnerId");
        }
    }
}
