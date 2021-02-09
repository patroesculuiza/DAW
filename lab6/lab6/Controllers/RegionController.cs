using lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab6.Models.MyDatabaseInitializer;

namespace lab6.Controllers
{
    public class RegionController : Controller
    {
        // GET: Region
        private DbCtx db = new DbCtx();

        public ActionResult Index()
        {
            ViewBag.Furnitures = db.Furnitures.ToList();
            return View();
        }
    }
}