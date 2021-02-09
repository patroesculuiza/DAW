using lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab6.Models.MyDatabaseInitializer;


namespace lab6.Controllers
{
    public class RoomController : Controller
    {
        private DbCtx db = new DbCtx();

        [HttpGet]
        public ActionResult Index()
        {
            List<Room> rooms = db.Rooms.ToList();
            ViewBag.Rooms = rooms;
            return View();
        }


        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Room room = db.Rooms.Find(id);
                if (room != null)
                {
                    return View(room);
                }
                return HttpNotFound("Couldn't find the room with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing room id parameter!");
        }


        [HttpGet]
        public ActionResult New()
        {
            Room room = new Room();
            room.FurnitureList = GetAllFurnitures();
            room.RezervationList = GetAllRezervations();
            room.UtilitiesList = GetAllUtilities();
            room.Utilities = new List<Utility>();
            return View(room);
        }

        [HttpPost]
        public ActionResult New(Room roomRequest)
        {
            roomRequest.FurnitureList = GetAllFurnitures();
            roomRequest.RezervationList = GetAllRezervations();

            // memoram intr-o lista doar genurile care au fost selectate
            var selectedUtilities = roomRequest.UtilitiesList.Where(b => b.Checked).ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    roomRequest.Utilities = new List<Utility>();
                    for (int i = 0; i < selectedUtilities.Count(); i++)
                    {
                        // cartii pe care vrem sa o adaugam in baza de date ii 
                        // asignam genurile selectate 
                        Utility utility = db.Utilities.Find(selectedUtilities[i].Id);
                        roomRequest.Utilities.Add(utility);
                    }
                    db.Rooms.Add(roomRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(roomRequest);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                return View(roomRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Room room = db.Rooms.Find(id);
                room.FurnitureList = GetAllFurnitures();
                room.RezervationList = GetAllRezervations();
                room.UtilitiesList = GetAllUtilities();

                foreach (Utility checkedUtility in room.Utilities)
                {   // iteram prin genurile care erau atribuite cartii inainte de momentul accesarii formularului
                    // si le selectam/bifam  in lista de checkbox-uri
                    room.UtilitiesList.FirstOrDefault(g => g.Id == checkedUtility.UtilityId).Checked = true;
                }
                if (room == null)
                {
                    return HttpNotFound("Coludn't find the room with id " + id.ToString() + "!");
                }
                return View(room);
            }
            return HttpNotFound("Missing room id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Room roomRequest)
        {
            roomRequest.FurnitureList = GetAllFurnitures();
            roomRequest.RezervationList = GetAllRezervations();

            // preluam cartea pe care vrem sa o modificam din baza de date
            Room room = db.Rooms.Include("Rezervation").Include("Furniture")
                        .SingleOrDefault(b => b.RoomId.Equals(id));

            // memoram intr-o lista doar genurile care au fost selectate din formular
            var selectedUtilities = roomRequest.UtilitiesList.Where(b => b.Checked).ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(room))
                    {
                        room.NrPeople = roomRequest.NrPeople;
                        room.RezervationId = roomRequest.RezervationId;
                        room.FurnitureId = roomRequest.FurnitureId;

                        room.Utilities.Clear();
                        room.Utilities = new List<Utility>();

                        for (int i = 0; i < selectedUtilities.Count(); i++)
                        {
                            // cartii pe care vrem sa o editam ii asignam genurile selectate 
                            Utility utility = db.Utilities.Find(selectedUtilities[i].Id);
                            room.Utilities.Add(utility);
                        }
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(roomRequest);
            }
            catch (Exception)
            {
                return View(roomRequest);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room != null)
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the room with id " + id.ToString() + "!");
        }

        [NonAction]
        public List<CheckBoxViewModel> GetAllUtilities()
        {
            var checkboxList = new List<CheckBoxViewModel>();
            foreach (var utility in db.Utilities.ToList())
            {
                checkboxList.Add(new CheckBoxViewModel
                {
                    Id = utility.UtilityId,
                    Name = utility.Name,
                    Checked = false
                });
            }
            return checkboxList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllFurnitures()
        {
            var selectList = new List<SelectListItem>();
            foreach (var cover in db.Furnitures.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = cover.FurnitureId.ToString(),
                    Text = cover.TypeFurniture
                });
            }
            return selectList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllRezervations()
        {
            var selectList = new List<SelectListItem>();
            foreach (var rezervation in db.Rezervations.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = rezervation.RezervationId.ToString(),
                    Text = rezervation.Name
                });
            }
            return selectList;
        }
    }
}