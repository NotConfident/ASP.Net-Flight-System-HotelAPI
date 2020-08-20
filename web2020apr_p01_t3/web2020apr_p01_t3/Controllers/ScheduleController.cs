using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web2020apr_p01_t3.DAL;
using web2020apr_p01_t3.Models;

namespace web2020apr_p01_t3.Controllers
{
    public class ScheduleController : Controller
    {
        private ScheduleDAL scheduleContext = new ScheduleDAL();
        private RouteDAL routeContext = new RouteDAL();
        // GET: ScheduleController
        
        public IActionResult viewSchedule(IFormCollection fData)
        {
            string dCity = fData["dCity"].ToString();
            string aCity = fData["aCity"].ToString();
            int? routeID = routeContext.getRouteID(dCity, aCity);
            List<ScheduleModel> scheduleList = scheduleContext.getScheduleList(routeID);
            return View(scheduleList);

        }

        // GET: ScheduleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScheduleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScheduleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScheduleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScheduleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScheduleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
