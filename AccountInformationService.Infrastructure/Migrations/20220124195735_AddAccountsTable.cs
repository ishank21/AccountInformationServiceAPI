using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountInformationService.Infrastructure.Migrations
{
    public partial class AddAccountsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientAccount_Detail",
                columns: table => new
                {
                    AccoundId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustodianId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustodianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustodialAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsClosed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientAccount_Detail");
        }
    }
}
