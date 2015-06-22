using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace SmartTrip.Migrations
{
    public partial class scenery : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AddColumn(
                name: "ImageUrl",
                table: "Scenery",
                type: "nvarchar(max)",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Scenery_City_CityId",
                table: "Scenery",
                column: "CityId",
                referencedTable: "City",
                referencedColumn: "Id");
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Scenery_City_CityId", table: "Scenery");
            migration.DropColumn(name: "ImageUrl", table: "Scenery");
        }
    }
}
