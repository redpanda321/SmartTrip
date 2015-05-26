using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace SmartTrip.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryName = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    ImageUrl = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });
            migration.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Content = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });
            migration.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Days = table.Column(type: "int", nullable: false),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    StartTime = table.Column(type: "datetime2", nullable: false),
                    StartingCity = table.Column(type: "nvarchar(max)", nullable: true),
                    TripName = table.Column(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                });
            migration.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityName = table.Column(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column(type: "int", nullable: false),
                    Days = table.Column(type: "int", nullable: false),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    ImageUrl = table.Column(type: "nvarchar(max)", nullable: true),
                    ScheduleId = table.Column(type: "int", nullable: true),
                    Summary = table.Column(type: "nvarchar(max)", nullable: true),
                    TripId = table.Column(type: "int", nullable: true),
                    Visited = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        columns: x => x.CountryId,
                        referencedTable: "Country",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_City_Trip_TripId",
                        columns: x => x.TripId,
                        referencedTable: "Trip",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "CityComment",
                columns: table => new
                {
                    CityId = table.Column(type: "int", nullable: true),
                    Content = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Time = table.Column(type: "datetime2", nullable: false),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityComment_City_CityId",
                        columns: x => x.CityId,
                        referencedTable: "City",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    CityId = table.Column(type: "int", nullable: false),
                    Currency = table.Column(type: "nvarchar(max)", nullable: true),
                    Hot = table.Column(type: "int", nullable: false),
                    HotelAddress = table.Column(type: "nvarchar(max)", nullable: true),
                    HotelName = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Price = table.Column(type: "decimal(18, 2)", nullable: false),
                    Score = table.Column(type: "int", nullable: false),
                    Star = table.Column(type: "int", nullable: false),
                    Summary = table.Column(type: "nvarchar(max)", nullable: true),
                    Traffic = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_City_CityId",
                        columns: x => x.CityId,
                        referencedTable: "City",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "HotelComment",
                columns: table => new
                {
                    Content = table.Column(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column(type: "int", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Time = table.Column(type: "datetime2", nullable: false),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelComment_Hotel_HotelId",
                        columns: x => x.HotelId,
                        referencedTable: "Hotel",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false),
                    NoteId = table.Column(type: "int", nullable: true),
                    ScheduleName = table.Column(type: "nvarchar(max)", nullable: true),
                    TripId = table.Column(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Hotel_Id",
                        columns: x => x.Id,
                        referencedTable: "Hotel",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedule_Note_NoteId",
                        columns: x => x.NoteId,
                        referencedTable: "Note",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedule_Trip_TripId",
                        columns: x => x.TripId,
                        referencedTable: "Trip",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "Scenery",
                columns: table => new
                {
                    Category = table.Column(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column(type: "int", nullable: false),
                    Currency = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    OpenTime = table.Column(type: "nvarchar(max)", nullable: true),
                    Price = table.Column(type: "decimal(18, 2)", nullable: false),
                    Ranking = table.Column(type: "int", nullable: false),
                    SceneryName = table.Column(type: "nvarchar(max)", nullable: true),
                    ScheduleId = table.Column(type: "int", nullable: true),
                    Score = table.Column(type: "int", nullable: false),
                    Star = table.Column(type: "int", nullable: false),
                    Summary = table.Column(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column(type: "nvarchar(max)", nullable: true),
                    Ticket = table.Column(type: "nvarchar(max)", nullable: true),
                    Traffic = table.Column(type: "nvarchar(max)", nullable: true),
                    Visited = table.Column(type: "int", nullable: false),
                    WebUrl = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scenery_City_CityId",
                        columns: x => x.CityId,
                        referencedTable: "City",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Scenery_Schedule_ScheduleId",
                        columns: x => x.ScheduleId,
                        referencedTable: "Schedule",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "Transit",
                columns: table => new
                {
                    Amount = table.Column(type: "int", nullable: false),
                    Currency = table.Column(type: "nvarchar(max)", nullable: true),
                    DestinationCity = table.Column(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column(type: "datetime2", nullable: false),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Memo = table.Column(type: "nvarchar(max)", nullable: true),
                    Price = table.Column(type: "decimal(18, 2)", nullable: false),
                    ScheduleId = table.Column(type: "int", nullable: true),
                    StartTime = table.Column(type: "datetime2", nullable: false),
                    StartingCity = table.Column(type: "nvarchar(max)", nullable: true),
                    TransitName = table.Column(type: "nvarchar(max)", nullable: true),
                    TransitNumber = table.Column(type: "nvarchar(max)", nullable: true),
                    TransitType = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transit_Schedule_ScheduleId",
                        columns: x => x.ScheduleId,
                        referencedTable: "Schedule",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "Image",
                columns: table => new
                {
                    HotelId = table.Column(type: "int", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    ImageUrl = table.Column(type: "nvarchar(max)", nullable: true),
                    SceneryId = table.Column(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Hotel_HotelId",
                        columns: x => x.HotelId,
                        referencedTable: "Hotel",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_Scenery_SceneryId",
                        columns: x => x.SceneryId,
                        referencedTable: "Scenery",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "SceneryComment",
                columns: table => new
                {
                    Content = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    SceneryId = table.Column(type: "int", nullable: true),
                    Time = table.Column(type: "datetime2", nullable: false),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneryComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SceneryComment_Scenery_SceneryId",
                        columns: x => x.SceneryId,
                        referencedTable: "Scenery",
                        referencedColumn: "Id");
                });
            migration.AddForeignKey(
                name: "FK_City_Schedule_ScheduleId",
                table: "City",
                column: "ScheduleId",
                referencedTable: "Schedule",
                referencedColumn: "Id");
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("City");
            migration.DropTable("CityComment");
            migration.DropTable("Country");
            migration.DropTable("Hotel");
            migration.DropTable("HotelComment");
            migration.DropTable("Image");
            migration.DropTable("Note");
            migration.DropTable("Scenery");
            migration.DropTable("SceneryComment");
            migration.DropTable("Schedule");
            migration.DropTable("Transit");
            migration.DropTable("Trip");
        }
    }
}
