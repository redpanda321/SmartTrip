using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace SmartTrip.Migrations
{
    public partial class nofk : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Image_Hotel_HotelId", table: "Image");
            migration.DropForeignKey(name: "FK_Scenery_City_CityId", table: "Scenery");
            migration.AlterColumn(
                name: "SceneryId",
                table: "Image",
                type: "int",
                nullable: false);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "SceneryId",
                table: "Image",
                type: "int",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Image_Hotel_HotelId",
                table: "Image",
                column: "HotelId",
                referencedTable: "Hotel",
                referencedColumn: "Id");
            migration.AddForeignKey(
                name: "FK_Scenery_City_CityId",
                table: "Scenery",
                column: "CityId",
                referencedTable: "City",
                referencedColumn: "Id");
        }
    }
}
