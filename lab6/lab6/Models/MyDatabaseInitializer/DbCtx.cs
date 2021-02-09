using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace lab6.Models.MyDatabaseInitializer
{
    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            Database.SetInitializer<DbCtx>(new Initp());
            //Database.SetInitializer<DbCtx>(new CreateDatabaseIfNotExists<DbCtx>());
            //Database.SetInitializer<DbCtx>(new DropCreateDatabaseIfModelChanges<DbCtx>());
            //Database.SetInitializer<DbCtx>(new DropCreateDatabaseAlways<DbCtx>());
        }


        public DbSet<Room> Rooms { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<Persone> Persones { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Region> Regions { get; set; }
    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            Furniture cover1 = new Furniture { FurnitureId = 67, TypeFurniture = "Single" };
            Furniture cover2 = new Furniture { FurnitureId = 68, TypeFurniture = "Double" };

            Region region1 = new Region { RegionId = 1, Name = "Alba" };
            Region region2 = new Region { RegionId = 2, Name = "Arad" };
            Region region3 = new Region { RegionId = 3, Name = "Argeș" };
            Region region4 = new Region { RegionId = 4, Name = "Bacău" };

            ctx.Furnitures.Add(cover1);
            ctx.Furnitures.Add(cover2);

            ctx.Regions.Add(region1);
            ctx.Regions.Add(region2);
            ctx.Regions.Add(region3);
            ctx.Regions.Add(region4);
            ctx.Regions.Add(new Region { RegionId = 5, Name = "Bihor" });
            ctx.Regions.Add(new Region { RegionId = 6, Name = "Bistrița-Năsăud" });
            ctx.Regions.Add(new Region { RegionId = 7, Name = "Botoșani" });
            ctx.Regions.Add(new Region { RegionId = 8, Name = "Brașov" });
            ctx.Regions.Add(new Region { RegionId = 9, Name = "Brăila" });
            ctx.Regions.Add(new Region { RegionId = 10, Name = "Buzău" });
            ctx.Regions.Add(new Region { RegionId = 11, Name = "Caraș-Severin" });
            ctx.Regions.Add(new Region { RegionId = 12, Name = "Cluj" });
            ctx.Regions.Add(new Region { RegionId = 13, Name = "Constanța" });
            ctx.Regions.Add(new Region { RegionId = 14, Name = "Covasna" });
            ctx.Regions.Add(new Region { RegionId = 15, Name = "Dâmbovița" });
            ctx.Regions.Add(new Region { RegionId = 16, Name = "Dolj" });
            ctx.Regions.Add(new Region { RegionId = 17, Name = "Galați" });
            ctx.Regions.Add(new Region { RegionId = 18, Name = "Gorj" });
            ctx.Regions.Add(new Region { RegionId = 19, Name = "Harghita" });
            ctx.Regions.Add(new Region { RegionId = 20, Name = "Hunedoara" });
            ctx.Regions.Add(new Region { RegionId = 21, Name = "Ialomița" });
            ctx.Regions.Add(new Region { RegionId = 22, Name = "Iași" });
            ctx.Regions.Add(new Region { RegionId = 23, Name = "Ilfov" });
            ctx.Regions.Add(new Region { RegionId = 24, Name = "Maramureș" });
            ctx.Regions.Add(new Region { RegionId = 25, Name = "Mehedinți" });
            ctx.Regions.Add(new Region { RegionId = 26, Name = "Mureș" });
            ctx.Regions.Add(new Region { RegionId = 27, Name = "Neamț" });
            ctx.Regions.Add(new Region { RegionId = 28, Name = "Olt" });
            ctx.Regions.Add(new Region { RegionId = 29, Name = "Prahova" });
            ctx.Regions.Add(new Region { RegionId = 30, Name = "Satu Mare" });
            ctx.Regions.Add(new Region { RegionId = 31, Name = "Sălaj" });
            ctx.Regions.Add(new Region { RegionId = 32, Name = "Sibiu" });
            ctx.Regions.Add(new Region { RegionId = 33, Name = "Suceava" });
            ctx.Regions.Add(new Region { RegionId = 34, Name = "Teleorman" });
            ctx.Regions.Add(new Region { RegionId = 35, Name = "Timiș" });
            ctx.Regions.Add(new Region { RegionId = 36, Name = "Tulcea" });
            ctx.Regions.Add(new Region { RegionId = 37, Name = "Vaslui" });
            ctx.Regions.Add(new Region { RegionId = 38, Name = "Vâlcea" });
            ctx.Regions.Add(new Region { RegionId = 39, Name = "Vrancea" });
            ctx.Regions.Add(new Region { RegionId = 40, Name = "București" });
            ctx.Regions.Add(new Region { RegionId = 41, Name = "București-Sector 1" });
            ctx.Regions.Add(new Region { RegionId = 42, Name = "București-Sector-2" });
            ctx.Regions.Add(new Region { RegionId = 43, Name = "București-Sector-3" });
            ctx.Regions.Add(new Region { RegionId = 44, Name = "București-Sector-4" });
            ctx.Regions.Add(new Region { RegionId = 45, Name = "București-Sector 5" });
            ctx.Regions.Add(new Region { RegionId = 46, Name = "București - Sector 6" });
            ctx.Regions.Add(new Region { RegionId = 51, Name = "Călărași" });
            ctx.Regions.Add(new Region { RegionId = 52, Name = "Giurgiu" });

            Persone contact1 = new Persone
            {
                PhoneNumber = "0712345678",
                BirthDay = "16",
                BirthMonth = "03",
                BirthYear = 1991,
                GenderType = Gender.Female,
                Resident = false,
                RegionId = region1.RegionId
            };

            Persone contact2 = new Persone
            {
                PhoneNumber = "0713345878",
                BirthDay = "07",
                BirthMonth = "04",
                BirthYear = 2002,
                GenderType = Gender.Female,
                Resident = false,
                RegionId = region2.RegionId
            };

            Persone contact3 = new Persone
            {
                PhoneNumber = "0711345678",
                BirthDay = "30",
                BirthMonth = "10",
                BirthYear = 2002,
                GenderType = Gender.Male,
                Resident = false,
                RegionId = region3.RegionId
            };



            ctx.Persones.Add(contact1);
            ctx.Persones.Add(contact2);
            ctx.Persones.Add(contact3);


            ctx.Rooms.Add(new Room
            {
                NrPeople = 3,
                Rezervation = new Rezervation { Name = "HarperCollins", Persone = contact1 },
                Furniture = cover1,
                Utilities = new List<Utility> {
                    new Utility { Name = "Modern"}
                }
            });
            ctx.Rooms.Add(new Room
            {
                NrPeople = 2,
                Rezervation = new Rezervation { Name = "Macmillan Publishers", Persone = contact2 },
                Furniture = cover1,
                Utilities = new List<Utility> {
                    new Utility { Name = "Coffee"}
                }
            });
            ctx.Rooms.Add(new Room
            {
                NrPeople = 5,
                Rezervation = new Rezervation { Name = "Scholastic", Persone = contact3 },
                Furniture = cover2,
                Utilities = new List<Utility> {
                    new Utility { Name = "View"},
                    new Utility { Name = "For children"},
                    new Utility { Name = "Room Service"}
                }
            });

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}