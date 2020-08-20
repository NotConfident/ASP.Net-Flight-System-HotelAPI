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
    [ResponseCache(NoStore = true, Duration = 0)]
    public class BookingController : Controller
    {
        // GET: BookingController
        ScheduleDAL scheduleContext = new ScheduleDAL();
        BookingDAL bookingContext = new BookingDAL();
        CustomerDAL customerContext = new CustomerDAL();
        // GET: BookingController
        public ActionResult madeBooking(int? id)
        {
            HttpContext.Session.SetInt32("scheduleID", id.Value);
            BookingModel booking = new BookingModel();
            booking.customerID = HttpContext.Session.GetInt32("userID").Value;
            booking.scheduleID = id.Value;
            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult madeBooking(BookingModel booking)
        {
            BookingViewModel finalBooking = new BookingViewModel();
            ScheduleModel schedule = scheduleContext.getSchedule(booking.scheduleID);
            //[BookingID], [CustomerID], [ScheduleID], [PassengerName], [PassportNumber], [Nationality], [SeatClass], [AmtPayable], [Remarks], [DateTimeCreated]) 
            finalBooking.customerID = booking.customerID;
            finalBooking.scheduleID = schedule.scheduleID;
            finalBooking.customerName = booking.customerName;
            finalBooking.passpoerNum = booking.passpoerNum;
            finalBooking.nationality = booking.nationality;
            if (booking.sitClass == "Business")
            {
                finalBooking.seatClass = booking.sitClass;
                finalBooking.amtPayable = schedule.bClass;
            }
            else
            {
                finalBooking.seatClass = booking.sitClass;
                finalBooking.amtPayable = schedule.eClass;
            }
            finalBooking.remark = booking.remark;
            bookingContext.book(finalBooking);
            TempData["Message"] = "Booking Success";

            return View();


        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
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

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
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

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
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
