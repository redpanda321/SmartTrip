using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace SmartTrip.Migrations
{
    public partial class schedule : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AddColumn(
                name: "CountryId",
                table: "Schedule",
                type: "int",
                nullable: true);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropColumn(name: "CountryId", table: "Schedule");
        }
    }
}
