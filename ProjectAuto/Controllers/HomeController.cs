using Ninject;
using ProjectAuto.DAL;
using ProjectAuto.Repositories;
using ProjectAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAuto.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Car> CarRepository { get; set; }

        public HomeController(IRepository<Car> CarRepository) 
        {
            this.CarRepository = CarRepository;
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View(CarRepository.getAll());
        }

        public ActionResult Owners() 
        {
            return RedirectToAction("Index", "Owner", new { area = "" });
        }

        public ActionResult CreateEditCar(int? ID)
        {
            Car model = new Car();
            if (ID.HasValue)
            {
                model = CarRepository.get(ID.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditCar(Car model)
        {
            if (model.ID == 0)
            {
                CarRepository.add(model);
            }
            else
            {
                Car editCar = CarRepository.get(model.ID);
                editCar.CarModel = model.CarModel;
                editCar.CarMark = model.CarMark;
                editCar.CarType = model.CarType;
                editCar.Price = model.Price;
                editCar.Year = model.Year;
                CarRepository.update(editCar, model.ID);

            }
            return RedirectToAction("Index");
        }

        public ActionResult Back()
        {
            return RedirectToAction("Index");
        }

        public ActionResult OwnerList(int ID) 
        {
            return View(CarRepository.get(ID).Owners);
        }

        public ActionResult DeleteCar(int ID) 
        {
            Car model = CarRepository.get(ID);
            return View(model);
        }

        [HttpPost, ActionName("DeleteCar")]
        public ActionResult ConfirmDeleteCar(int ID)
        {
            CarRepository.remove(CarRepository.get(ID));
            return RedirectToAction("Index");
        }
	}
}