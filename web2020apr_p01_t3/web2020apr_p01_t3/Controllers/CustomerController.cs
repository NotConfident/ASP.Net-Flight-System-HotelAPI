using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web2020apr_p01_t3.DAL;
using web2020apr_p01_t3.Models;

namespace web2020apr_p01_t3.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDAL customerContext = new CustomerDAL();
        private BookingDAL bookingContext = new BookingDAL();
        private ScheduleDAL scheduleContext = new ScheduleDAL();
        private RouteDAL routeContext = new RouteDAL();
        // GET: CustomerController1
        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult Index(IFormCollection fData)
        {
            if(HttpContext.Session.GetInt32("userID") == null){
                return RedirectToAction("Index", "Home");
            }

            string dCity = fData["dCity"].ToString();
            string aCity = fData["aCity"].ToString();
            int? routeID = routeContext.getRouteID(dCity, aCity);
            List<ScheduleModel> scheduleList = scheduleContext.getScheduleList(routeID);
            return View(scheduleList);
        }


        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult profile()
        {
            if (HttpContext.Session.GetInt32("userID") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            int tempID = HttpContext.Session.GetInt32("userID").Value;
            CustomerModel customer = customerContext.getCustomer(tempID);

            List<BookingDetails> details = bookingContext.getDetails(tempID);

            var model = new ProfileModel { details = details, customer = customer };
            return View(model);



        }



        // GET: CustomerController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController1/Create
        public ActionResult createProfile()
        {
            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult createProfile(CustomerModel customer)
        {
            if (customerContext.checkEmail(customer.cEmail))
            {
                TempData["Message"] = "Email already exist Login instead";
                return View();

            }
            else
            {
                customer.id = customerContext.createCustomer(customer);
                HttpContext.Session.SetInt32("CustomerID", customer.id.Value);
                return RedirectToAction("Index");

            }



        }

        // GET: CustomerController1/Edit/5
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult updateProfile(int? id)
        {
            CustomerModel customer = customerContext.getCustomer(id.Value);
            return View(customer);
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult updateProfile(CustomerModel customer)
        {
            int id = customerContext.update(customer);
            return RedirectToAction("profile", new { id });
        }
    }

}