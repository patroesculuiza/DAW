using lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab6.Models.MyDatabaseInitializer;

namespace lab6.Controllers
{

    public class FurnitureController : Controller
    {
        private DbCtx db = new DbCtx();

        public ActionResult Index()
        {
            ViewBag.Furnitures = db.Furnitures.ToList();
            return View();
        }

        public ActionResult New()
        {
            Furniture furniture = new Furniture();
            return View(furniture);
        }

        [HttpPost]
        public ActionResult New(Furniture roomTypeRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Furnitures.Add(roomTypeRequest);
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
                Furniture furniture = db.Furnitures.Find(id);

                if (furniture == null)
                {
                    return HttpNotFound("Couldn't find the furniture type with id " + id.ToString() + "!");
                }
                return View(furniture);
            }
            return HttpNotFound("Couldn't find the furniture type with id " + id.ToString() + "!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Furniture furnitureRequestor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Furniture furniture = db.Furnitures.Find(id);
                    if (TryUpdateModel(furniture))
                    {
                        furniture.TypeFurniture = furnitureRequestor.TypeFurniture;
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
                Furniture furniture = db.Furnitures.Find(id);
                if (furniture != null)
                {
                    db.Furnitures.Remove(furniture);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the furniture type with id " + id.ToString() + "!");
            }
            return HttpNotFound("Furniture type id parameter is missing!");
        }
    }

}