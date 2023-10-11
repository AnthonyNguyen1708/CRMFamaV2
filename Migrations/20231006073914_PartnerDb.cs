using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMFamaV2.Migrations
{
    /// <inheritdoc />
    public partial class PartnerDb : Migration
    {
        public object PartnerList { get; internal set; }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartnerList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PartnerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerList", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerList");
        }
    }
}
