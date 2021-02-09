using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Proiect_web_final.Models.MyValidation;

namespace lab6.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        //nr persoane validare
        [RegularExpression(@"^[1-9]$", ErrorMessage = "This is not a valid number, out of 1-9!")]
        [PrimeNumberValidator]
        public int NrPeople { get; set; }

        // one-to-many relationship
        public int RezervationId { get; set; }
        public virtual Rezervation Rezervation { get; set; }

        //one-to-many

        [ForeignKey("Furniture")]
        public int FurnitureId { get; set; }

        public virtual Furniture Furniture { get; set; }

        // many-to-many relationship
        public virtual ICollection<Utility> Utilities { get; set; }

        // dropdown lists
        public IEnumerable<SelectListItem> FurnitureList { get; set; }
        public IEnumerable<SelectListItem> RezervationList { get; set; }

        // checkboxes list
        [NotMapped]
        public List<CheckBoxViewModel> UtilitiesList { get; set; }

    }
    /*
    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            Database.SetInitializer<DbCtx>(new Initp());
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
    }
    
    public class Initp : DropCreateDatabaseIfModelChanges<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            Furniture type1 = new Furniture { FurnitureId = 12, TypeFurniture = "Single" };
            Furniture type2 = new Furniture { FurnitureId = 13, TypeFurniture = "Double" };
            Furniture type3 = new Furniture { FurnitureId = 14, TypeFurniture = "Family" };
            ctx.Furnitures.Add(type1);
            ctx.Furnitures.Add(type2);
            ctx.Furnitures.Add(type3);
            ctx.Rooms.Add(new Room
            {
                NrPeople = 3,
                //Furniture = new Furniture { TypeFurniture = "fnrejgnerg"}
                FurnitureId = type1.FurnitureId
            });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
    */
}