using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using SmartTrip.Models;

namespace SmartTrip.Migrations
{
    [ContextType(typeof(ApplicationDbContext))]
    partial class schedule_username
    {
        public override string Id
        {
            get { return "20150629144427_schedule_username"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta4-12943"; }
        }
        
        public override IModel Target
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Identity");
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                    {
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken()
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<string>("NormalizedName")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetRoles");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("ClaimValue")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("RoleId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetRoleClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("ClaimValue")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("UserId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetUserClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("LoginProvider")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("ProviderDisplayName")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("ProviderKey")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<string>("UserId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("LoginProvider", "ProviderKey");
                        b.Annotation("Relational:TableName", "AspNetUserLogins");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("RoleId")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("UserId")
                            .Annotation("OriginalValueIndex", 1);
                        b.Key("UserId", "RoleId");
                        b.Annotation("Relational:TableName", "AspNetUserRoles");
                    });
                
                builder.Entity("SmartTrip.Models.ApplicationUser", b =>
                    {
                        b.Property<int>("AccessFailedCount")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken()
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Email")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<bool>("EmailConfirmed")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<bool>("LockoutEnabled")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<DateTimeOffset?>("LockoutEnd")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<string>("NormalizedEmail")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<string>("NormalizedUserName")
                            .Annotation("OriginalValueIndex", 8);
                        b.Property<string>("PasswordHash")
                            .Annotation("OriginalValueIndex", 9);
                        b.Property<string>("PhoneNumber")
                            .Annotation("OriginalValueIndex", 10);
                        b.Property<bool>("PhoneNumberConfirmed")
                            .Annotation("OriginalValueIndex", 11);
                        b.Property<string>("SecurityStamp")
                            .Annotation("OriginalValueIndex", 12);
                        b.Property<bool>("TwoFactorEnabled")
                            .Annotation("OriginalValueIndex", 13);
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 14);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetUsers");
                    });
                
                builder.Entity("SmartTrip.Models.City", b =>
                    {
                        b.Property<string>("CityName")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("CountryId")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Days")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 3)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("ImageUrl")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<string>("Summary")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<int>("Visited")
                            .Annotation("OriginalValueIndex", 6);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.CityComment", b =>
                    {
                        b.Property<int>("CityId")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("Content")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<DateTime>("Time")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 4);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Country", b =>
                    {
                        b.Property<string>("CountryName")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("ImageUrl")
                            .Annotation("OriginalValueIndex", 2);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Hotel", b =>
                    {
                        b.Property<int>("CityId")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("Currency")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Hot")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<string>("HotelAddress")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("HotelName")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 5)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<decimal>("Price")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<int>("ScheduleId")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<int>("Score")
                            .Annotation("OriginalValueIndex", 8);
                        b.Property<int>("Star")
                            .Annotation("OriginalValueIndex", 9);
                        b.Property<string>("Summary")
                            .Annotation("OriginalValueIndex", 10);
                        b.Property<string>("Traffic")
                            .Annotation("OriginalValueIndex", 11);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.HotelComment", b =>
                    {
                        b.Property<string>("Content")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("HotelId")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<DateTime>("Time")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 4);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Image", b =>
                    {
                        b.Property<int?>("HotelId")
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("ShadowIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("ImageUrl")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int?>("SceneryId")
                            .Annotation("OriginalValueIndex", 3)
                            .Annotation("ShadowIndex", 1);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Note", b =>
                    {
                        b.Property<string>("Content")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Scenery", b =>
                    {
                        b.Property<string>("Category")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("CityId")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Currency")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 3)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("ImageUrl")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<string>("OpenTime")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<decimal>("Price")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<int>("Ranking")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<string>("SceneryName")
                            .Annotation("OriginalValueIndex", 8);
                        b.Property<int>("ScheduleId")
                            .Annotation("OriginalValueIndex", 9);
                        b.Property<int>("Score")
                            .Annotation("OriginalValueIndex", 10);
                        b.Property<int>("Star")
                            .Annotation("OriginalValueIndex", 11);
                        b.Property<string>("Summary")
                            .Annotation("OriginalValueIndex", 12);
                        b.Property<string>("Telephone")
                            .Annotation("OriginalValueIndex", 13);
                        b.Property<string>("Ticket")
                            .Annotation("OriginalValueIndex", 14);
                        b.Property<string>("Traffic")
                            .Annotation("OriginalValueIndex", 15);
                        b.Property<int>("Visited")
                            .Annotation("OriginalValueIndex", 16);
                        b.Property<string>("WebUrl")
                            .Annotation("OriginalValueIndex", 17);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.SceneryComment", b =>
                    {
                        b.Property<string>("Content")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<int>("SceneryId")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<DateTime>("Time")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 4);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Schedule", b =>
                    {
                        b.Property<int?>("CountryId")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<DateTime>("ScheduleDate")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<string>("ScheduleName")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("StrCities")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<string>("StrHotels")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<string>("StrNote")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<string>("StrSceneries")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<string>("StrTransits")
                            .Annotation("OriginalValueIndex", 8);
                        b.Property<int>("TripId")
                            .Annotation("OriginalValueIndex", 9);
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 10);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Transit", b =>
                    {
                        b.Property<int>("Amount")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("Currency")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("DestinationCity")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<DateTime>("EndTime")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 4)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Memo")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<decimal>("Price")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<int>("ScheduleId")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<DateTime>("StartTime")
                            .Annotation("OriginalValueIndex", 8);
                        b.Property<string>("StartingCity")
                            .Annotation("OriginalValueIndex", 9);
                        b.Property<string>("TransitName")
                            .Annotation("OriginalValueIndex", 10);
                        b.Property<string>("TransitNumber")
                            .Annotation("OriginalValueIndex", 11);
                        b.Property<string>("TransitType")
                            .Annotation("OriginalValueIndex", 12);
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Trip", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("ImageUrl")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("StartCity")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<DateTime>("StartTime")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("TripCities")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<string>("TripDays")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<string>("TripName")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 7);
                        b.Key("Id");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", "RoleId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.ApplicationUser", "UserId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.ApplicationUser", "UserId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", "RoleId");
                        b.ForeignKey("SmartTrip.Models.ApplicationUser", "UserId");
                    });
                
                builder.Entity("SmartTrip.Models.Image", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.Hotel", "HotelId");
                        b.ForeignKey("SmartTrip.Models.Scenery", "SceneryId");
                    });
                
                builder.Entity("SmartTrip.Models.Scenery", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.City", "CityId");
                    });
                
                builder.Entity("SmartTrip.Models.SceneryComment", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.Scenery", "SceneryId");
                    });
                
                return builder.Model;
            }
        }
    }
}
