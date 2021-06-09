using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroRabbit.Transfer.Data.Migrations
{
	public partial class NameTableToTransferLogs : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
					name: "PK_TransfersLog",
					table: "TransfersLog");

			migrationBuilder.RenameTable(
					name: "TransfersLog",
					newName: "TransferLogs");

			migrationBuilder.RenameColumn(
					name: "Account",
					table: "TransferLogs",
					newName: "TransferAmount");

			migrationBuilder.AlterColumn<int>(
					name: "ToAccount",
					table: "TransferLogs",
					type: "int",
					nullable: false,
					defaultValue: 0,
					oldClrType: typeof(string),
					oldType: "nvarchar(max)",
					oldNullable: true);

			migrationBuilder.AlterColumn<int>(
					name: "FromAccount",
					table: "TransferLogs",
					type: "int",
					nullable: false,
					defaultValue: 0,
					oldClrType: typeof(string),
					oldType: "nvarchar(max)",
					oldNullable: true);

			migrationBuilder.AddPrimaryKey(
					name: "PK_TransferLogs",
					table: "TransferLogs",
					column: "Id");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
					name: "PK_TransferLogs",
					table: "TransferLogs");

			migrationBuilder.RenameTable(
					name: "TransferLogs",
					newName: "TransfersLog");

			migrationBuilder.RenameColumn(
					name: "TransferAmount",
					table: "TransfersLog",
					newName: "Account");

			migrationBuilder.AlterColumn<string>(
					name: "ToAccount",
					table: "TransfersLog",
					type: "nvarchar(max)",
					nullable: true,
					oldClrType: typeof(int),
					oldType: "int");

			migrationBuilder.AlterColumn<string>(
					name: "FromAccount",
					table: "TransfersLog",
					type: "nvarchar(max)",
					nullable: true,
					oldClrType: typeof(int),
					oldType: "int");

			migrationBuilder.AddPrimaryKey(
					name: "PK_TransfersLog",
					table: "TransfersLog",
					column: "Id");
		}
	}
}
