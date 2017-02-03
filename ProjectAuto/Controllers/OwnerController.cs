using Ninject;
using ProjectAuto.Models;
using ProjectAuto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAuto.Controllers
{
    public class OwnerController : Controller
    {
        private IRepository<Owner> OwnerRepository;
        private IRepository<Car> CarPepository;

        public OwnerController(IRepository<Car> CarRepository, IRepository<Owner> OwnerRepository) 
        {
            this.CarPepository = CarRepository;
            this.OwnerRepository = OwnerRepository;
        }
        //
        // GET: /Owner/
        public ActionResult Index()
        {
            return View(OwnerRepository.getAll());
        }

        public ActionResult Cars()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult CreateEditOwner(int? ID)
        {
            Owner model = new Owner();
            if (ID.HasValue)
            {
                model = OwnerRepository.get(ID.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditOwner(Owner model)
        {
            if (model.ID == 0)
            {
                OwnerRepository.add(model);
            }
            else
            {
                Owner editOwner = OwnerRepository.get(model.ID);
                editOwner.FirstName = model.FirstName;
                editOwner.SecondName = model.SecondName;
                editOwner.YearOfBirth = model.YearOfBirth;
                editOwner.DriverExpirience = model.DriverExpirience;
                OwnerRepository.update(editOwner, model.ID);

            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteOwner(int ID)
        {
            Owner model = OwnerRepository.get(ID);
            return View(model);
        }

        [HttpPost, ActionName("DeleteOwner")]
        public ActionResult ConfirmDeleteOwner(int ID)
        {
            OwnerRepository.remove(OwnerRepository.get(ID));
            return RedirectToAction("Index");
        }

        public ActionResult Back() 
        {
            return RedirectToAction("Index");
        }

        public ActionResult OwnerCarList(int ID) 
        {
            return View(OwnerRepository.get(ID).Cars);
        }

        public ActionResult CarList(int ID) 
        {
            TempData["OwnerID"] = ID;
            if (OwnerRepository.get(ID).Cars != null)
            {
                return View(CarPepository.getAll().Except(OwnerRepository.get(ID).Cars));
            }
            else 
            {
                return View(CarPepository.getAll());
            }
            
        }

        public ActionResult AddCar(int CarID)
        {
            int OwnerID = (Int32)TempData["OwnerID"];
            Owner editOwner= OwnerRepository.get(OwnerID);
            editOwner.Cars.Add(CarPepository.get(CarID));
            OwnerRepository.update(editOwner, OwnerID);
            return RedirectToAction("Index");
        }
	}
}