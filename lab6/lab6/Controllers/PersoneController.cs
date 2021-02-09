using lab6.Models;
using lab6.Models.MyDatabaseInitializer;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace lab6.Controllers
{
    public class PersoneController : Controller
    {
        // GET: Persone
        private DbCtx db = new DbCtx();

        [HttpGet]
        public ActionResult New()
        {
            Persone contact = new Persone();
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();
            return View(contact);
        }

        [HttpPost]
        public ActionResult New(Persone contactRequest)
        {
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();
            try
            {
                if (ModelState.IsValid)
                {
                    db.Persones.Add(contactRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Room");
                }
                return View(contactRequest);
            }
            catch (Exception e)
            {
                return View(contactRequest);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Persone furniture = db.Persones.Find(id);

                if (furniture == null)
                {
                    return HttpNotFound("Couldn't find the person with id " + id.ToString() + "!");
                }
                return View(furniture);
            }
            return HttpNotFound("Couldn't find the persone with id " + id.ToString() + "!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Persone furnitureRequestor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Persone furniture = db.Persones.Find(id);
                    if (TryUpdateModel(furniture))
                    {
                        furniture.PhoneNumber = furnitureRequestor.PhoneNumber;
                        furniture.BirthDay = furnitureRequestor.BirthDay;
                        furniture.BirthMonth = furnitureRequestor.BirthMonth;
                        furniture.BirthYear = furnitureRequestor.BirthYear;
                        furniture.Resident = furnitureRequestor.Resident;
                        furniture.RegionId = furnitureRequestor.RegionId;
                    
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

        [NonAction]
        public IEnumerable<SelectListItem> GetAllRegions()
        {
            var selectList = new List<SelectListItem>();
            foreach (var region in db.Regions.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = region.RegionId.ToString(),
                    Text = region.Name
                });
            }
            return selectList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllGenderTypes()
        {
            var selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem
            {
                Value = Gender.Male.ToString(),
                Text = "Male"
            });

            selectList.Add(new SelectListItem
            {
                Value = Gender.Female.ToString(),
                Text = "Female"
            });

            return selectList;
        }
    }
}