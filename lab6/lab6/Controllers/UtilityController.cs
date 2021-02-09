using lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab6.Models.MyDatabaseInitializer;

namespace lab6.Controllers
{
    public class UtilityController : Controller
    {
        private DbCtx db = new DbCtx();

        public ActionResult Index()
        {
            ViewBag.Utilities = db.Utilities.ToList();
            return View();
        }

        public ActionResult New()
        {
            Utility utility = new Utility();
            return View(utility);
        }

        [HttpPost]
        public ActionResult New(Utility roomTypeRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Utilities.Add(roomTypeRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(roomTypeRequest);
            }
            catch (Exception e)
            {
                return View(roomTypeRequest);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Utility utility = db.Utilities.Find(id);

                if (utility == null)
                {
                    return HttpNotFound("Couldn't find the utility type with id " + id.ToString() + "!");
                }
                return View(utility);
            }
            return HttpNotFound("Couldn't find the utility type with id " + id.ToString() + "!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Utility furnitureRequestor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Utility furniture = db.Utilities.Find(id);
                    if (TryUpdateModel(furniture))
                    {
                        furniture.Name = furnitureRequestor.Name;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(furnitureRequestor);
            }
            catch (Exception e)
            {
                return View(furnitureRequestor);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Utility furniture = db.Utilities.Find(id);
                if (furniture != null)
                {
                    db.Utilities.Remove(furniture);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the utility type with id " + id.ToString() + "!");
            }
            return HttpNotFound("Utility type id parameter is missing!");
        }
    }
}
