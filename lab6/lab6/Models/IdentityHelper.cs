using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class IdentityHelper
    {
        internal static void SeedIdentities(ApplicationDbContext ctx)
        {
            ctx.Rooms.Add(new Room
            {
                NrPeople = 3
            });
            ctx.SaveChanges();
        }
    }
}