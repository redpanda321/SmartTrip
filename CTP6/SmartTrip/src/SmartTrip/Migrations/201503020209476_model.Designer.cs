using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using SmartTrip.Models;
using System;

namespace SmartTrip.Migrations
{
    [ContextType(typeof(SmartTrip.Models.ApplicationDbContext))]
    public partial class model : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201503020209476_model";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta3-12166";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRole", b =>
                    {
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken();
                        b.Property<string>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Property<string>("NormalizedName");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetRoles");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("RoleId");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetRoleClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("UserId");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetUserClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("LoginProvider");
                        b.Property<string>("ProviderDisplayName");
                        b.Property<string>("ProviderKey");
                        b.Property<string>("UserId");
                        b.Key("LoginProvider", "ProviderKey");
                        b.ForRelational().Table("AspNetUserLogins");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("RoleId");
                        b.Property<string>("UserId");
                        b.Key("UserId", "RoleId");
                        b.ForRelational().Table("AspNetUserRoles");
                    });
                
                builder.Entity("SmartTrip.Models.ApplicationUser", b =>
                    {
                        b.Property<int>("AccessFailedCount");
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken();
                        b.Property<string>("Email");
                        b.Property<bool>("EmailConfirmed");
                        b.Property<string>("Id")
                            .GenerateValueOnAdd();
                        b.Property<bool>("LockoutEnabled");
                        b.Property<DateTimeOffset?>("LockoutEnd");
                        b.Property<string>("NormalizedEmail");
                        b.Property<string>("NormalizedUserName");
                        b.Property<string>("PasswordHash");
                        b.Property<string>("PhoneNumber");
                        b.Property<bool>("PhoneNumberConfirmed");
                        b.Property<string>("SecurityStamp");
                        b.Property<bool>("TwoFactorEnabled");
                        b.Property<string>("UserName");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetUsers");
                    });
                
                builder.Entity("SmartTrip.Models.City", b =>
                    {
                        b.Property<string>("CityName");
                        b.Property<int?>("CountryId");
                        b.Property<string>("CountryName");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("ImageUrl");
                        b.Property<int?>("ScheduleId");
                        b.Property<string>("Summary");
                        b.Property<int?>("TripId");
                        b.Property<string>("UserName");
                        b.Property<int>("Visited");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.CityComment", b =>
                    {
                        b.Property<int?>("CityId");
                        b.Property<string>("Content");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("UserName");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Country", b =>
                    {
                        b.Property<string>("CountryName");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("UserName");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Hotel", b =>
                    {
                        b.Property<int?>("CityId");
                        b.Property<string>("Currency");
                        b.Property<int>("Hot");
                        b.Property<string>("HotelAddress");
                        b.Property<string>("HotelName");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<decimal>("Price");
                        b.Property<int>("Score");
                        b.Property<int>("Star");
                        b.Property<string>("Summary");
                        b.Property<string>("Traffic");
                        b.Property<string>("UserName");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.HotelComment", b =>
                    {
                        b.Property<string>("Content");
                        b.Property<int?>("HotelId");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("UserName");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Note", b =>
                    {
                        b.Property<string>("Content");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("UserName");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Scenery", b =>
                    {
                        b.Property<int?>("CityId");
                        b.Property<string>("Currency");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("OpenTime");
                        b.Property<decimal>("Price");
                        b.Property<int>("Ranking");
                        b.Property<string>("SceneryName");
                        b.Property<int?>("ScheduleId");
                        b.Property<int>("Score");
                        b.Property<int>("Star");
                        b.Property<string>("Summary");
                        b.Property<string>("Tel");
                        b.Property<string>("Ticket");
                        b.Property<string>("Traffic");
                        b.Property<string>("UserName");
                        b.Property<int>("Visited");
                        b.Property<string>("WebUrl");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.SceneryComment", b =>
                    {
                        b.Property<string>("Content");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<int?>("SceneryId");
                        b.Property<string>("UserName");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Schedule", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("ScheduleName");
                        b.Property<int?>("TripId");
                        b.Property<string>("UserName");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Transit", b =>
                    {
                        b.Property<int>("Amount");
                        b.Property<string>("Currency");
                        b.Property<int?>("DestinationCityId");
                        b.Property<DateTime>("EndTime");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Memo");
                        b.Property<decimal>("Price");
                        b.Property<int?>("ScheduleId");
                        b.Property<DateTime>("StartTime");
                        b.Property<int?>("StartingCityId");
                        b.Property<string>("TransitName");
                        b.Property<string>("TransitNumber");
                        b.Property<string>("UserName");
                        b.Key("Id");
                    });
                
                builder.Entity("SmartTrip.Models.Trip", b =>
                    {
                        b.Property<int>("Days");
                        b.Property<int?>("DestinationCountryId");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<DateTime>("StartTime");
                        b.Property<int?>("StartingCityId");
                        b.Property<string>("TripName");
                        b.Property<string>("UserName");
                        b.Key("Id");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.IdentityRole", "RoleId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.ApplicationUser", "UserId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.ApplicationUser", "UserId");
                    });
                
                builder.Entity("SmartTrip.Models.City", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.Country", "CountryId");
                        b.ForeignKey("SmartTrip.Models.Schedule", "ScheduleId");
                        b.ForeignKey("SmartTrip.Models.Trip", "TripId");
                    });
                
                builder.Entity("SmartTrip.Models.CityComment", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.City", "CityId");
                    });
                
                builder.Entity("SmartTrip.Models.Hotel", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.City", "CityId");
                    });
                
                builder.Entity("SmartTrip.Models.HotelComment", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.Hotel", "HotelId");
                    });
                
                builder.Entity("SmartTrip.Models.Note", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.Schedule", "Id");
                    });
                
                builder.Entity("SmartTrip.Models.Scenery", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.City", "CityId");
                        b.ForeignKey("SmartTrip.Models.Schedule", "ScheduleId");
                    });
                
                builder.Entity("SmartTrip.Models.SceneryComment", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.Scenery", "SceneryId");
                    });
                
                builder.Entity("SmartTrip.Models.Schedule", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.Trip", "TripId");
                    });
                
                builder.Entity("SmartTrip.Models.Transit", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.City", "DestinationCityId");
                        b.ForeignKey("SmartTrip.Models.City", "StartingCityId");
                        b.ForeignKey("SmartTrip.Models.Schedule", "ScheduleId");
                    });
                
                builder.Entity("SmartTrip.Models.Trip", b =>
                    {
                        b.ForeignKey("SmartTrip.Models.City", "StartingCityId");
                        b.ForeignKey("SmartTrip.Models.Country", "DestinationCountryId");
                    });
                
                return builder.Model;
            }
        }
    }
}