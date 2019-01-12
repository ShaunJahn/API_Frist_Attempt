using Microsoft.EntityFrameworkCore.Migrations;

namespace PetOwnerAPI.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetInfos_Owners_OwnerId",
                table: "PetInfos");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "PetInfos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetInfos_Owners_OwnerId",
                table: "PetInfos",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetInfos_Owners_OwnerId",
                table: "PetInfos");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "PetInfos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PetInfos_Owners_OwnerId",
                table: "PetInfos",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
