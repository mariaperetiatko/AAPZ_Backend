using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AAPZ_Backend.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChairExists",
                table: "Workplace");

            migrationBuilder.DropColumn(
                name: "IsCofeMachineExists",
                table: "Workplace");

            migrationBuilder.DropColumn(
                name: "IsComputerExists",
                table: "Workplace");

            migrationBuilder.DropColumn(
                name: "IsConditionerExists",
                table: "Workplace");

            migrationBuilder.DropColumn(
                name: "IsLampExists",
                table: "Workplace");

            migrationBuilder.DropColumn(
                name: "IsTableExists",
                table: "Workplace");

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkplaceEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipmentId = table.Column<int>(nullable: false),
                    WorkplaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkplaceEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkplaceEquipment_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkplaceEquipment_Workplace_WorkplaceId",
                        column: x => x.WorkplaceId,
                        principalTable: "Workplace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkplaceEquipment_EquipmentId",
                table: "WorkplaceEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkplaceEquipment_WorkplaceId",
                table: "WorkplaceEquipment",
                column: "WorkplaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkplaceEquipment");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "IsChairExists",
                table: "Workplace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsCofeMachineExists",
                table: "Workplace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsComputerExists",
                table: "Workplace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsConditionerExists",
                table: "Workplace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsLampExists",
                table: "Workplace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsTableExists",
                table: "Workplace",
                nullable: false,
                defaultValue: 0);
        }
    }
}
