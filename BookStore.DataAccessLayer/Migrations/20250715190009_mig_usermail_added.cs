using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DataAccessLayer.Migrations
{
    public partial class mig_usermail_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Contacts",
                newName: "ContactAddress");

            migrationBuilder.CreateTable(
                name: "UserMails",
                columns: table => new
                {
                    UserMailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMails", x => x.UserMailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMails");

            migrationBuilder.RenameColumn(
                name: "ContactAddress",
                table: "Contacts",
                newName: "Adress");
        }
    }
}
