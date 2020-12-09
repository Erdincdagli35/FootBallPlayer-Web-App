using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballicaWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballicaWebApp.Controllers
{
    public class FootballerController : Controller
    {
        FootballerDAL footDAL = new FootballerDAL();
      
        public IActionResult Index()
        {
            List<Footballer> fList = new List<Footballer>();
            fList = footDAL.GetAllFootballer().ToList();
            return View(fList);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Footballer obFoot)
        {
            if (ModelState.IsValid)
            {
                footDAL.AddFootballer(obFoot);
                return RedirectToAction("Index");
            }
            return View(obFoot);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Footballer f = footDAL.GetFootballerBy(id);
            if (f == null)
                return NotFound();
            
            return View(f);

        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,[Bind] Footballer obFoot)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                footDAL.UpdateFootballer(obFoot);
                return RedirectToAction("Index");
            }
            return View(footDAL);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Footballer f = footDAL.GetFootballerBy(id);
            if (f == null)
                return NotFound();

            return View(f);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Footballer f = footDAL.GetFootballerBy(id);
            if (f == null)
                return NotFound();

            return View(f);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFoot(int? id)
        {
            footDAL.DeleteFootballer(id);
            return RedirectToAction("Index");
        }


    }
}