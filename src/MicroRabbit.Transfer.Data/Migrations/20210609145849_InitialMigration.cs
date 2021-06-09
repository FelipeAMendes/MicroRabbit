using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroRabbit.Transfer.Data.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
					name: "TransfersLog",
					columns: table => new
					{
						Id = table.Column<int>(type: "int", nullable: false)
									.Annotation("SqlServer:Identity", "1, 1"),
						FromAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
						ToAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
						Account = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_TransfersLog", x => x.Id);
					});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					name: "TransfersLog");
		}
	}
}
