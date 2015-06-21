using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace SmartTrip.Migrations
{
    public partial class init : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    ConcurrencyStamp = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "nvarchar(450)", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });
            migration.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    AccessFailedCount = table.Column(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column(type: "nvarchar(max)", nullable: true),
                    Email = table.Column(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column(type: "bit", nullable: false),
                    Id = table.Column(type: "nvarchar(450)", nullable: true),
                    LockoutEnabled = table.Column(type: "bit", nullable: false),
                    LockoutEnd = table.Column(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column(type: "bit", nullable: false),
                    SecurityStamp = table.Column(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column(type: "bit", nullable: false),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                    Summary = table.Column(type: "nvarchar(max)", nullable: true),
                    Visited = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });
            migration.CreateTable(
                name: "CityComment",
                columns: table => new
                {
                    CityId = table.Column(type: "int", nullable: false),
                    Content = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Time = table.Column(type: "datetime2", nullable: false),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityComment", x => x.Id);
                });
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
                    ScheduleId = table.Column(type: "int", nullable: false),
                    Score = table.Column(type: "int", nullable: false),
                    Star = table.Column(type: "int", nullable: false),
                    Summary = table.Column(type: "nvarchar(max)", nullable: true),
                    Traffic = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });
            migration.CreateTable(
                name: "HotelComment",
                columns: table => new
                {
                    Content = table.Column(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column(type: "int", nullable: false),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Time = table.Column(type: "datetime2", nullable: false),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelComment", x => x.Id);
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
                    ScheduleId = table.Column(type: "int", nullable: false),
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
                });
            migration.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    ScheduleDate = table.Column(type: "datetime2", nullable: false),
                    ScheduleName = table.Column(type: "nvarchar(max)", nullable: true),
                    StrCities = table.Column(type: "nvarchar(max)", nullable: true),
                    StrHotels = table.Column(type: "nvarchar(max)", nullable: true),
                    StrNote = table.Column(type: "nvarchar(max)", nullable: true),
                    StrSceneries = table.Column(type: "nvarchar(max)", nullable: true),
                    StrTransits = table.Column(type: "nvarchar(max)", nullable: true),
                    TripId = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
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
                    ScheduleId = table.Column(type: "int", nullable: false),
                    StartTime = table.Column(type: "datetime2", nullable: false),
                    StartingCity = table.Column(type: "nvarchar(max)", nullable: true),
                    TransitName = table.Column(type: "nvarchar(max)", nullable: true),
                    TransitNumber = table.Column(type: "nvarchar(max)", nullable: true),
                    TransitType = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transit", x => x.Id);
                });
            migration.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    StartCity = table.Column(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column(type: "datetime2", nullable: false),
                    TripCities = table.Column(type: "nvarchar(max)", nullable: true),
                    TripDays = table.Column(type: "nvarchar(max)", nullable: true),
                    TripName = table.Column(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                });
            migration.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    ClaimType = table.Column(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    RoleId = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        columns: x => x.RoleId,
                        referencedTable: "AspNetRoles",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    ClaimType = table.Column(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    UserId = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        columns: x => x.UserId,
                        referencedTable: "AspNetUsers",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column(type: "nvarchar(450)", nullable: true),
                    ProviderDisplayName = table.Column(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        columns: x => x.UserId,
                        referencedTable: "AspNetUsers",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    RoleId = table.Column(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        columns: x => x.RoleId,
                        referencedTable: "AspNetRoles",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        columns: x => x.UserId,
                        referencedTable: "AspNetUsers",
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
                    SceneryId = table.Column(type: "int", nullable: false),
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
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("AspNetRoles");
            migration.DropTable("AspNetRoleClaims");
            migration.DropTable("AspNetUserClaims");
            migration.DropTable("AspNetUserLogins");
            migration.DropTable("AspNetUserRoles");
            migration.DropTable("AspNetUsers");
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
