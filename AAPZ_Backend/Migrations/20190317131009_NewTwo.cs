using Microsoft.EntityFrameworkCore.Migrations;

namespace AAPZ_Backend.Migrations
{
    public partial class NewTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Landlord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Client",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Landlord_IdentityId",
                table: "Landlord",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdentityId",
                table: "Client",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_AspNetUsers_IdentityId",
                table: "Client",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Landlord_AspNetUsers_IdentityId",
                table: "Landlord",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_AspNetUsers_IdentityId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Landlord_AspNetUsers_IdentityId",
                table: "Landlord");

            migrationBuilder.DropIndex(
                name: "IX_Landlord_IdentityId",
                table: "Landlord");

            migrationBuilder.DropIndex(
                name: "IX_Client_IdentityId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Landlord");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Client");
        }
    }
}
