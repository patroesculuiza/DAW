using lab6.Models;
using lab6.Models.MyDatabaseInitializer;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace lab6.Controllers
{
    public class RezervationController : Controller
    {
        // GET: Rezervation
        private DbCtx ctx = new DbCtx();

        // GET: Publisher
        public ActionResult Index()
        {
            ViewBag.Rezervations = ctx.Rezervations.ToList();
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Rezervation rezervation = ctx.Rezervations.Find(id);
                if (rezervation != null)
                {
                    ViewBag.Region = ctx.Regions.Find(rezervation.Persone.RegionId).Name;
                    return View(rezervation);
                }
                return HttpNotFound("Couldn't find the rezervation with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing rezervation id parameter!");
        }

        [HttpGet]
        public ActionResult New()
        {
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();

            RezervationContactViewModel pc = new RezervationContactViewModel();
            return View(pc);
        }

        [HttpPost]
        public ActionResult New( RezervationContactViewModel pcViewModel)
        {
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();
            
            try
            {
                if (ModelState.IsValid)
                {
                    Persone persone = new Persone
                    {
                        PhoneNumber = pcViewModel.PhoneNumber,
                        BirthDay = pcViewModel.BirthDay,
                        BirthMonth = pcViewModel.BirthMonth,
                        BirthYear = pcViewModel.BirthYear,
                        Resident = pcViewModel.Resident,
                        RegionId = pcViewModel.RegionId
                    };
                    // vom adauga in baza de date ambele obiecte 
                    ctx.Persones.Add(persone);
                    Rezervation rezervation = new Rezervation
                    {
                        Name = pcViewModel.Name,
                        Persone = persone
                    };
                    ctx.Rezervations.Add(rezervation);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(pcViewModel);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                return View(pcViewModel);
            }
        }
        
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Rezervation furniture = ctx.Rezervations.Find(id);

                if (furniture == null)
                {
                    return HttpNotFound("Couldn't find the rezervation type with id " + id.ToString() + "!");
                }
                return View(furniture);
                //return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the rezervation type with id " + id.ToString() + "!");
        }

        
        [HttpPut]
        public ActionResult Edit(int id, Rezervation pcViewModel)
        {
            //pcViewModel.Region= GetAllRegions();
            //roomRequest.RezervationList = GetAllGenderTypes();
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();
            

            // preluam cartea pe care vrem sa o modificam din baza de date
            Rezervation room = ctx.Rezervations
                        .SingleOrDefault(b => b.RezervationId.Equals(id));

            // memoram intr-o lista doar genurile care au fost selectate din formular

            try
            {
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(room))
                    {

                        room.Persone = pcViewModel.Persone;
                   
                        // vom adauga in baza de date ambele obiecte 
                        //ctx.Persones.Add(persone);

                        room.Name = pcViewModel.Name;
                        //ctx.Rezervations.Add(rezervation);
                        ctx.SaveChanges();
                        
                    }
                    return RedirectToAction("Index");
                }
                return View(pcViewModel);
            }
            catch (Exception)
            {
                return View(pcViewModel);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Rezervation rezervation = ctx.Rezervations.Find(id);
            Persone contact = ctx.Persones.Find(rezervation.Persone.PersoneId);

            if (rezervation != null)
            {
                ctx.Rezervations.Remove(rezervation);
                ctx.Persones.Remove(contact);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the rezervation with id " + id.ToString() + "!");
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllRegions()
        {
            var selectList = new List<SelectListItem>();
            foreach (var region in ctx.Regions.ToList())
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
        [NonAction]
        public IEnumerable<SelectListItem> GetAllPersones()
        {
            var selectList = new List<SelectListItem>();
            foreach (var rezervation in ctx.Persones.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = rezervation.PersoneId.ToString(),
                    Text = rezervation.BirthDay
                });
            }
            return selectList;
        }

    }
}