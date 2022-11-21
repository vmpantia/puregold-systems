using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Puregold.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable202211120 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "InternalID",
                table: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                columns: new[] { "AccessKey", "Account_InternalID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "InternalID",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                columns: new[] { "InternalID", "Account_InternalID", "AccessKey" });
        }
    }
}
