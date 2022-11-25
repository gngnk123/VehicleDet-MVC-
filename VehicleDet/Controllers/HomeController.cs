using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleDet.Models;
using DataLibrary;
using static DataLibrary.BusinessLogic.VehicleProcessor;

namespace VehicleDet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewVehicles()
        {
            ViewBag.Message = "Vehicle List";

            var data = LoadVehicle();
            List<Vehiclemodel> vehicles = new List<Vehiclemodel>();

            foreach (var row in data)
            {
                vehicles.Add(new Vehiclemodel
                {
                    Id = row.Id,
                    CarId = row.CarId,
                    Make = row.Make,
                    C_Model = row.Model,
                    Year = row.Year,
                    Odo = row.Odo,
                    Color = row.Color,
                    Engine = row.Engine
                });
            }

            return View(vehicles);
        }


        public ActionResult CarAdd()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarAdd(Vehiclemodel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateVehicle(
                    model.CarId,
                    model.Make,
                    model.C_Model,
                    model.Year,
                    model.Odo,
                    model.Color,
                    model.Engine);
                return RedirectToAction("index");
            }
            return View();
        }

        public ActionResult CarDelete()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarDelete(int Id)
        {
            if (ModelState.IsValid)
            {
                var data = DeleteVehicle(
                    Id);

                return RedirectToAction("ViewVehicles","../ViewVehicles");
            }

            return View();
        }

    }
}