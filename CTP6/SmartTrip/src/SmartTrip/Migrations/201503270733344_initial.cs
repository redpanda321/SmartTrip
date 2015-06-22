using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace SmartTrip.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("AspNetRoles",
                c => new
                    {
                        Id = c.String(),
                        ConcurrencyStamp = c.String(),
                        Name = c.String(),
                        NormalizedName = c.String()
                    })
                .PrimaryKey("PK_AspNetRoles", t => t.Id);
            
            migrationBuilder.CreateTable("AspNetRoleClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        RoleId = c.String()
                    })
                .PrimaryKey("PK_AspNetRoleClaims", t => t.Id);
            
            migrationBuilder.CreateTable("AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        UserId = c.String()
                    })
                .PrimaryKey("PK_AspNetUserClaims", t => t.Id);
            
            migrationBuilder.CreateTable("AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ProviderDisplayName = c.String(),
                        UserId = c.String()
                    })
                .PrimaryKey("PK_AspNetUserLogins", t => new { t.LoginProvider, t.ProviderKey });
            
            migrationBuilder.CreateTable("AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(),
                        RoleId = c.String()
                    })
                .PrimaryKey("PK_AspNetUserRoles", t => new { t.UserId, t.RoleId });
            
            migrationBuilder.CreateTable("AspNetUsers",
                c => new
                    {
                        Id = c.String(),
                        AccessFailedCount = c.Int(nullable: false),
                        ConcurrencyStamp = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        LockoutEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(),
                        NormalizedEmail = c.String(),
                        NormalizedUserName = c.String(),
                        PasswordHash = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        UserName = c.String()
                    })
                .PrimaryKey("PK_AspNetUsers", t => t.Id);
            
            migrationBuilder.CreateTable("City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        Days = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Summary = c.String(),
                        Visited = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        TripId = c.Int(),
                        ScheduleId = c.Int()
                    })
                .PrimaryKey("PK_City", t => t.Id);
            
            migrationBuilder.CreateTable("CityComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Time = c.DateTime(nullable: false),
                        UserName = c.String(),
                        CityId = c.Int()
                    })
                .PrimaryKey("PK_CityComment", t => t.Id);
            
            migrationBuilder.CreateTable("Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        ImageUrl = c.String()
                    })
                .PrimaryKey("PK_Country", t => t.Id);
            
            migrationBuilder.CreateTable("Hotel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Currency = c.String(),
                        Hot = c.Int(nullable: false),
                        HotelAddress = c.String(),
                        HotelName = c.String(),
                        Price = c.Decimal(nullable: false),
                        Score = c.Int(nullable: false),
                        Star = c.Int(nullable: false),
                        Summary = c.String(),
                        Traffic = c.String(),
                        CityId = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_Hotel", t => t.Id);
            
            migrationBuilder.CreateTable("HotelComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Time = c.DateTime(nullable: false),
                        UserName = c.String(),
                        HotelId = c.Int()
                    })
                .PrimaryKey("PK_HotelComment", t => t.Id);
            
            migrationBuilder.CreateTable("Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        SceneryId = c.Int(),
                        HotelId = c.Int()
                    })
                .PrimaryKey("PK_Image", t => t.Id);
            
            migrationBuilder.CreateTable("Note",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String()
                    })
                .PrimaryKey("PK_Note", t => t.Id);
            
            migrationBuilder.CreateTable("Scenery",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Currency = c.String(),
                        OpenTime = c.String(),
                        Price = c.Decimal(nullable: false),
                        Ranking = c.Int(nullable: false),
                        SceneryName = c.String(),
                        Score = c.Int(nullable: false),
                        Star = c.Int(nullable: false),
                        Summary = c.String(),
                        Telephone = c.String(),
                        Ticket = c.String(),
                        Traffic = c.String(),
                        Visited = c.Int(nullable: false),
                        WebUrl = c.String(),
                        CityId = c.Int(nullable: false),
                        ScheduleId = c.Int()
                    })
                .PrimaryKey("PK_Scenery", t => t.Id);
            
            migrationBuilder.CreateTable("SceneryComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Time = c.DateTime(nullable: false),
                        UserName = c.String(),
                        SceneryId = c.Int()
                    })
                .PrimaryKey("PK_SceneryComment", t => t.Id);
            
            migrationBuilder.CreateTable("Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleName = c.String(),
                        NoteId = c.Int(),
                        TripId = c.Int()
                    })
                .PrimaryKey("PK_Schedule", t => t.Id);
            
            migrationBuilder.CreateTable("Transit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Currency = c.String(),
                        DestinationCity = c.String(),
                        EndTime = c.DateTime(nullable: false),
                        Memo = c.String(),
                        Price = c.Decimal(nullable: false),
                        StartingCity = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        TransitName = c.String(),
                        TransitNumber = c.String(),
                        TransitType = c.String(),
                        ScheduleId = c.Int()
                    })
                .PrimaryKey("PK_Transit", t => t.Id);
            
            migrationBuilder.CreateTable("Trip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Days = c.Int(nullable: false),
                        StartingCity = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        TripName = c.String(),
                        UserName = c.String()
                    })
                .PrimaryKey("PK_Trip", t => t.Id);
            
            migrationBuilder.AddForeignKey(
                "AspNetRoleClaims",
                "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                new[] { "RoleId" },
                "AspNetRoles",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "AspNetUserClaims",
                "FK_AspNetUserClaims_AspNetUsers_UserId",
                new[] { "UserId" },
                "AspNetUsers",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "AspNetUserLogins",
                "FK_AspNetUserLogins_AspNetUsers_UserId",
                new[] { "UserId" },
                "AspNetUsers",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "City",
                "FK_City_Country_CountryId",
                new[] { "CountryId" },
                "Country",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "City",
                "FK_City_Trip_TripId",
                new[] { "TripId" },
                "Trip",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "City",
                "FK_City_Schedule_ScheduleId",
                new[] { "ScheduleId" },
                "Schedule",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "CityComment",
                "FK_CityComment_City_CityId",
                new[] { "CityId" },
                "City",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Hotel",
                "FK_Hotel_City_CityId",
                new[] { "CityId" },
                "City",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "HotelComment",
                "FK_HotelComment_Hotel_HotelId",
                new[] { "HotelId" },
                "Hotel",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Image",
                "FK_Image_Scenery_SceneryId",
                new[] { "SceneryId" },
                "Scenery",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Image",
                "FK_Image_Hotel_HotelId",
                new[] { "HotelId" },
                "Hotel",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Scenery",
                "FK_Scenery_City_CityId",
                new[] { "CityId" },
                "City",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Scenery",
                "FK_Scenery_Schedule_ScheduleId",
                new[] { "ScheduleId" },
                "Schedule",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "SceneryComment",
                "FK_SceneryComment_Scenery_SceneryId",
                new[] { "SceneryId" },
                "Scenery",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Schedule",
                "FK_Schedule_Hotel_Id",
                new[] { "Id" },
                "Hotel",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Schedule",
                "FK_Schedule_Note_NoteId",
                new[] { "NoteId" },
                "Note",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Schedule",
                "FK_Schedule_Trip_TripId",
                new[] { "TripId" },
                "Trip",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "Transit",
                "FK_Transit_Schedule_ScheduleId",
                new[] { "ScheduleId" },
                "Schedule",
                new[] { "Id" },
                cascadeDelete: false);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("AspNetRoleClaims", "FK_AspNetRoleClaims_AspNetRoles_RoleId");
            
            migrationBuilder.DropForeignKey("AspNetUserClaims", "FK_AspNetUserClaims_AspNetUsers_UserId");
            
            migrationBuilder.DropForeignKey("AspNetUserLogins", "FK_AspNetUserLogins_AspNetUsers_UserId");
            
            migrationBuilder.DropForeignKey("CityComment", "FK_CityComment_City_CityId");
            
            migrationBuilder.DropForeignKey("Hotel", "FK_Hotel_City_CityId");
            
            migrationBuilder.DropForeignKey("Scenery", "FK_Scenery_City_CityId");
            
            migrationBuilder.DropForeignKey("City", "FK_City_Country_CountryId");
            
            migrationBuilder.DropForeignKey("HotelComment", "FK_HotelComment_Hotel_HotelId");
            
            migrationBuilder.DropForeignKey("Image", "FK_Image_Hotel_HotelId");
            
            migrationBuilder.DropForeignKey("Schedule", "FK_Schedule_Hotel_Id");
            
            migrationBuilder.DropForeignKey("Schedule", "FK_Schedule_Note_NoteId");
            
            migrationBuilder.DropForeignKey("Image", "FK_Image_Scenery_SceneryId");
            
            migrationBuilder.DropForeignKey("SceneryComment", "FK_SceneryComment_Scenery_SceneryId");
            
            migrationBuilder.DropForeignKey("City", "FK_City_Schedule_ScheduleId");
            
            migrationBuilder.DropForeignKey("Scenery", "FK_Scenery_Schedule_ScheduleId");
            
            migrationBuilder.DropForeignKey("Transit", "FK_Transit_Schedule_ScheduleId");
            
            migrationBuilder.DropForeignKey("City", "FK_City_Trip_TripId");
            
            migrationBuilder.DropForeignKey("Schedule", "FK_Schedule_Trip_TripId");
            
            migrationBuilder.DropTable("AspNetRoles");
            
            migrationBuilder.DropTable("AspNetRoleClaims");
            
            migrationBuilder.DropTable("AspNetUserClaims");
            
            migrationBuilder.DropTable("AspNetUserLogins");
            
            migrationBuilder.DropTable("AspNetUserRoles");
            
            migrationBuilder.DropTable("AspNetUsers");
            
            migrationBuilder.DropTable("City");
            
            migrationBuilder.DropTable("CityComment");
            
            migrationBuilder.DropTable("Country");
            
            migrationBuilder.DropTable("Hotel");
            
            migrationBuilder.DropTable("HotelComment");
            
            migrationBuilder.DropTable("Image");
            
            migrationBuilder.DropTable("Note");
            
            migrationBuilder.DropTable("Scenery");
            
            migrationBuilder.DropTable("SceneryComment");
            
            migrationBuilder.DropTable("Schedule");
            
            migrationBuilder.DropTable("Transit");
            
            migrationBuilder.DropTable("Trip");
        }
    }
}