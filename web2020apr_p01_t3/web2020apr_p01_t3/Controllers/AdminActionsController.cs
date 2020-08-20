using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using web2020apr_p01_t3.DAL;
using web2020apr_p01_t3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web2020apr_p01_t3.Controllers
{
    public class AdminActionsController : Controller
    {
        private FlightDAL flightContext = new FlightDAL();
        private AircraftDAL aircraftContext = new AircraftDAL();
        private PersonnelDAL personnelContext = new PersonnelDAL();
        private FlightCrewDAL crewContext = new FlightCrewDAL();
        private ScheduleDAL scheduleContext = new ScheduleDAL();

        // GET: /<controller>/
        //Package 2
        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult FlightRoute()
        {
            // Stop accessing the action if not logged in
            // or account not in the "Administrator" role
            if ((HttpContext.Session.GetString("Role") == null) || (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }

            List<FlightRoute> routeList = flightContext.GetAllRoutes();

            return View(routeList);
        }

        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult Index()
        {
            // Stop accessing the action if not logged in
            // or account not in the "Administrator" role
            if ((HttpContext.Session.GetString("Role") == null) || (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: /<controller>/
        //Package 2
        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult FlightSchedule()
        {
            // Stop accessing the action if not logged in
            // or account not in the "Administrator" role
            if ((HttpContext.Session.GetString("Role") == null) || (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }

            List<FlightScheduleViewModel> flightList = flightContext.GetAllFlights();

            return View(flightList);
        }

        // GET: ~/Create
        //Package 2
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult CreateFlightRoute()
        {
            // Stop accessing the action if not logged in
            // or account not in the "Administrator" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: ~/Create
        //Package 2
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult CreateFlightRoute(FlightRoute flightRoute)
        {
            if (ModelState.IsValid)
            {
                int validate = flightContext.ValidateRoute(flightRoute);

                if (validate == 0)
                {
                    //Add Flight Route record to database
                    flightRoute.RouteID = flightContext.AddFlightRoute(flightRoute);
                    TempData["CreateRouteSuccess"] = "Flight Route created successfully.";
                }
                else
                {
                    TempData["CreateRouteFail"] = "Flight Route already exist!";
                    return RedirectToAction("CreateFlightRoute");
                }

                return RedirectToAction("FlightRoute");       

            }
            else
            {
                //Input validation fails, return to the Create view
                //to display error message
                return View(flightRoute);
            }
        }

        // GET: ~/Create
        //Package 2
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult CreateFlightSchedule()
        {
            // Stop accessing the action if not logged in
            // or account not in the "Administrator" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            //CheckRouteID Returns a list of FlightRoute objects that do have a FlightSchedule assigned to it
            //List<FlightRoute> routes = flightContext.CheckUnassignedRouteID();

            List<FlightRoute> routes = flightContext.GetAllRoutes();

            //FlightRouteViewModel will extract only the RouteID and store it in a SelectItemList for View to call it.
            FlightRouteViewModel viewModel = new FlightRouteViewModel(routes);

            return View(viewModel);
        }

        // POST: ~/Create
        //Package 2
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult CreateFlightSchedule(FlightRouteViewModel flightRoute)
        {

            if (ModelState.IsValid)
            {
                DateTime defaultDateTime = default(DateTime);

                DateTime currentDate = DateTime.Now.Date;
                string currentDateString = currentDate.ToString("dd-MMM-yyyy");

                DateTime currentDatePlus1 = currentDate.AddDays(1);
                //string currentDatePlus1String = currentDatePlus1.ToString("dd-MMM-yyyy");

                DateTime? flightRouteDate = flightRoute.DepartureDateTime.GetValueOrDefault();
                string departureDateTimeString = flightRouteDate?.ToString("dd-MMM-yyyy");

                //If DateTime is NOT empty. Validation kicks in.
                if (flightRouteDate != defaultDateTime)
                {
                    //To check for dates wayy before / same as the current date 
                    if (Convert.ToDateTime(departureDateTimeString) <= Convert.ToDateTime(currentDateString))
                    {
                        if (flightRoute.Business < 0 || flightRoute.Economy < 0)
                        {
                            TempData.Clear();
                            TempData["PriceError"] = "Price cannot be of negative value!";

                            //Redirect user to AdminActions/CreateFlightSchedule view
                            return RedirectToAction("CreateFlightSchedule");
                        }
                        TempData["DateError"] = "Date scheduled must be at least a day from today!";

                        //Redirect user to AdminActions/CreateFlightSchedule view
                        return RedirectToAction("CreateFlightSchedule");
                    }

                    //To check for dates that are just a day after the current date
                    else if (flightRouteDate == currentDatePlus1)
                    {
                        TempData["DateError"] = "Date scheduled must be at least a day from today!";

                        //Redirect user to AdminActions/CreateFlightSchedule view
                        return RedirectToAction("CreateFlightSchedule");

                    }

                    //Convert FlightRouteViewModel to FlightSchedule Object
                    FlightSchedule schedule = flightContext.ConvertToScheduleObj(flightRoute);
                    //Add Flight Route record to database
                    schedule.ScheduleID = flightContext.AddFlightSchedule(schedule);
                    TempData["CreateScheduleSuccess"] = "Flight Schedule created successfully.";

                    //Redirect user to AdminActions/FlightSchedule view
                    return RedirectToAction("FlightSchedule");
                }

                //If DateTime is empty - NULL
                else
                {
                    if (flightRoute.Business < 0 || flightRoute.Economy < 0)
                    {
                        TempData["PriceError"] = "Price cannot be of negative value!";
                        return RedirectToAction("CreateFlightSchedule");
                    }

                    //Convert FlightRouteViewModel to FlightSchedule Object
                    FlightSchedule schedule = flightContext.ConvertToScheduleObj(flightRoute);
                    //Add Flight Route record to database
                    schedule.ScheduleID = flightContext.AddFlightSchedule(schedule);
                    TempData["CreateScheduleSuccess"] = "Flight Schedule created successfully.";

                    //Redirect user to AdminActions/FlightSchedule view
                    return RedirectToAction("FlightSchedule");
                }
            }

            else
            {
                //Input validation fails, return to the Create view
                //to display error message
                TempData["InvalidInput"] = "Please enter a valid input!";

                //Redirect user to AdminActions/CreateFlightSchedule view
                return RedirectToAction("CreateFlightSchedule");
            }
        }

        //Package 2
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult ViewScheduleBooking(int scheduleID)
        {
            // Stop accessing the action if not logged in
            // or account not in the "Administrator" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            FlightSchedule route = flightContext.GetScheduleDetails(scheduleID);
            List<ScheduleBookingViewModel> flightList = flightContext.GetScheduleBookingDetails(scheduleID);
            
            ViewModel vm = new Models.ViewModel();
            vm.ScheduleBooking = flightList;
            vm.ScheduleID = route.ScheduleID;
            vm.RouteID = route.RouteID;
            vm.FlightNumber = route.FlightNumber;
            vm.AircraftID = route.AircraftID;
            vm.DepartureDateTime = route.DepartureDateTime;
            vm.PriceEco = route.PriceEco;
            vm.PriceBusiness = route.PriceBusiness;
            vm.Status = route.Status;
            
            return View(vm);
        }


        //Package 2
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult ViewScheduleBooking(ViewModel scheduleDetails)
        {

            if (ModelState.IsValid)
            {
                //Update Flight Record to database
                flightContext.UpdateStatus(scheduleDetails);
                TempData["UpdateScheduleBookingSuccess"] = "Flight Schedule status updated successfully!";

                //Redirect user to AdminActions/FlightSchedule view
                return RedirectToAction("FlightSchedule");
            }
            else
            {
                //Input validation fails, return to the view
                //to display error message
                return View(scheduleDetails);
            }
        }

        //View Aircraft Records
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult ViewAircraft()
        {
            // Stop accessing the action if not logged in or account not in the "Admin" role
            if ((HttpContext.Session.GetString("Role") == null) ||
                (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            //List<Aircraft> aircraftList = aircraftContext.GetAllAircraft();
            //return View(aircraftList);

            List<Aircraft> aircraftList = aircraftContext.GetAllAircraft();

            return View(aircraftList);

        }

        //Aircraft Date Filter
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult DateFilter()
        {
            // Stop accessing the action if not logged in or account not in the "Admin" role
            if ((HttpContext.Session.GetString("Role") == null) ||
                (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }


            List<Aircraft> aircraftList = aircraftContext.GetAllAircraftWithDateFilter();

            return View(aircraftList);

        }

        //Aicraft flight details
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult ViewAircraftFlightDetails(int id)
        {
            // Stop accessing the action if not logged in
            // or account not in the "Staff" role
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            Aircraft aircraft = aircraftContext.GetAircraftDetails(id);
            List<AircraftViewModel> aircraftVM = MapToAircraft(aircraft);

            return View(aircraftVM);
        }

        public List<AircraftViewModel> MapToAircraft(Aircraft aircraft)
        {
            int scheduleID = 0;
            string flightNumber = "";
            DateTime? departureDT = (DateTime?)null;
            DateTime? arrivalDT = (DateTime?)null;
            string status = "";

            string departureCountry = "";
            string departureCity = "";
            string arrivalCountry = "";
            string arrivalCity = "";


            //create an aircraft view model list to store aircraft view model because an aircraft might be assigned to more than a flights
            List<AircraftViewModel> aircraftVMList = new List<AircraftViewModel>();
            List<FlightScheduleViewModel> flightscheduleList = aircraftContext.GetAllAircraftWithFlightSchedule();
            foreach (FlightScheduleViewModel fs in flightscheduleList)
            {
                //check if selected aircraft id is in the flightschedule list. if so, add into the list
                if (fs.AircraftID == aircraft.AircraftID)
                {
                    scheduleID = fs.ScheduleID;
                    flightNumber = fs.FlightNumber;
                    departureDT = fs.DepartureDateTime;
                    arrivalDT = fs.ArrivalDateTime;
                    status = fs.Status;
                    departureCountry = fs.DepartureCountry;
                    departureCity = fs.DepartureCity;
                    arrivalCountry = fs.ArrivalCountry;
                    arrivalCity = fs.ArrivalCity;
                    aircraftVMList.Add(new AircraftViewModel
                    {
                        AircraftID = aircraft.AircraftID,
                        ScheduleID = scheduleID,
                        FlightNumber = flightNumber,
                        DepartureDateTime = departureDT,
                        ArrivalDateTime = arrivalDT,
                        Status = status,
                        AircraftModel = aircraft.modelName,
                        DepartureCountry = departureCountry,
                        DepartureCity = departureCity,
                        ArrivalCountry = arrivalCountry,
                        ArrivalCity = arrivalCity

                    });
                }
            }


            return aircraftVMList;

        }

        //Create aircraft records
        // GET: Aircraft/Create
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult CreateAircraft()
        {
            // Stop accessing the action if not logged in or account not in the "Admin" role
            if ((HttpContext.Session.GetString("Role") == null) ||
                (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Aircraft/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult CreateAircraft(Aircraft aircraft)
        {

            if (ModelState.IsValid)
            {
                //add aircraft record to database if no error
                aircraft.AircraftID = aircraftContext.Add(aircraft);
                //redirect user to aircraft/index view
                return RedirectToAction("Index");
            }
            else
            {
                //error when creating, input validation fails and return to create view
                //to display error message
                ModelState.AddModelError(string.Empty, "Error");

                return View(aircraft);
            }
        }

        // GET: Aircraft/Edit/5
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult EditAircraft(int? id)
        {
            // Stop accessing the action if not logged in or account not in the "Admin" role
            if ((HttpContext.Session.GetString("Role") == null) ||
                (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                //Query string parameter not provided, return to index page
                return RedirectToAction("Index");
            }

            Aircraft aircraft = aircraftContext.GetAircraftDetails(id.Value);
            ViewBag.status = aircraft.Status;

            if (aircraft == null)
            {
                //not allowed to edit return to index page
                return RedirectToAction("Index");
            }

            return View(aircraft);
        }

        // POST: Aircraft/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult EditAircraft(Aircraft aircraft)
        {

            //bool check = false;
            ViewBag.status = aircraft.Status;

            if (ModelState.IsValid)
            {
                if (aircraftContext.checkAircraft(aircraft.AircraftID) == true)
                {
                    aircraftContext.Update(aircraft);

                    return RedirectToAction("Index");

                }
                else if (aircraftContext.checkAircraft(aircraft.AircraftID) == false)
                {
                    //TempData["alertMessage"] = "Aircraft Status cannot be change as it is currently assigned to a flight";
                    ViewData["Error"] = "Aircraft Status cannot be change as it is currently assigned to a flight";
                    return View();

                }
                else
                {
                    //TempData["alertMessage"] = "Aircraft Status cannot be change as it is currently assigned to a flight";
                    ViewData["Error"] = "invalid choice";
                    return View();
                }

            }

            return View();



        }

        // return aircraft records table
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult ViewAiracraft(int? id)
        {
            // Stop accessing the action if not logged in or account not in the "Admin" role
            if ((HttpContext.Session.GetString("Role") == null) ||
                (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            AircraftAndFlightViewModel aircraftVM = new AircraftAndFlightViewModel();
            aircraftVM.flightScheduleList = flightContext.GetAllFlightScheduleForAssign();


            return View(aircraftVM);


        }


        // GET: Aircraft & Flights
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult AssignAircraft(int? id)
        {
            // Stop accessing the action if not logged in or account not in the "Admin" role
            if ((HttpContext.Session.GetString("Role") == null) ||
                (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            AircraftAndFlightViewModel aircraftVM = new AircraftAndFlightViewModel();
            aircraftVM.flightScheduleList = flightContext.GetAllFlightScheduleForAssign();

           
            if (id != null)
            {
                ViewData["selectedFlightScheduleID"] = id.Value;
                aircraftVM.aircraftList = aircraftContext.GetAllAircraftOperational();
            }
            else
            {
                ViewData["selectedFlightScheduleID"] = "";

            }

            return View(aircraftVM);    


        }

        // POST: Aircraft/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult AssignAircraft(string aircraftID, string scheduleID)
        {
            int sID = Convert.ToInt32(scheduleID);
            int aID = Convert.ToInt32(aircraftID);

            if (ModelState.IsValid)
            {
                try
                {
                    aircraftContext.Assign(aID, sID);
                    ViewData["success"] = "Successfully assigned";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
                

            }
            else
            {
                ModelState.AddModelError("", "Error");
                return View();
            }
           

        }
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult PersonnelIndex()
        {
            List<Personnel> personnelList = personnelContext.GetPersonnel();
            return View(personnelList);
        }
        [ResponseCache(NoStore = true, Duration = 0)]
        private List<FlightSchedule> GetScheduleList()
        {
            List<FlightSchedule> scheduleList = scheduleContext.GetSchListNoPara();
            scheduleList.Insert(0, new FlightSchedule
            {
                ScheduleID = 0,
                FlightNumber = "--Select--"
            });
            return scheduleList;
        }
        [ResponseCache(NoStore = true, Duration = 0)]
        private List<Personnel> GetPersonnel()
        {
            List<Personnel> personnelList = personnelContext.GetPersonnel();
            personnelList.Insert(0, new Personnel
            {
                StaffId = 0,
            });
            return personnelList;
        }
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult ViewPersonnel()
        {

            if ((HttpContext.Session.GetString("Role") == null) ||
               (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            List<Personnel> personnelList = personnelContext.GetPersonnel();

            return View(personnelList);
        }
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult CreatePersonnel()
        {
            ViewData["Vocations"] = GetVocation();
            return View();
        }
        [ResponseCache(NoStore = true, Duration = 0)]
        private List<SelectListItem> GetVocation()
        {
            List<SelectListItem> vocation = new List<SelectListItem>();
            vocation.Add(new SelectListItem { Value = "Administrator", Text = "Administrator" });
            vocation.Add(new SelectListItem { Value = "Pilot", Text = "Pilot" });
            vocation.Add(new SelectListItem { Value = "Flight Attendant", Text = "Flight Attendant" });
            vocation.Add(new SelectListItem { Value = null, Text = "" });

            return vocation;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult CreatePersonnel(Personnel personnel)
        {
            ViewData["Vocations"] = GetVocation();

            if (ModelState.IsValid)
            {
                personnel.StaffId = personnelContext.Add(personnel);
                return RedirectToAction("Index");
            }
            else
            {
                return View(personnel);
            }
        }
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult ViewPersonnelDetails(int id)
        {
            if ((HttpContext.Session.GetString("Role") == null) ||
            (HttpContext.Session.GetString("Role") != "Administrator"))
            {
                return RedirectToAction("Index", "Home");
            }
            Personnel personnel = personnelContext.GetDetails(id);
            PersonnelViewModel personnelvm = MapToPersonnelVM(personnel);
            return View(personnelvm);
        }
        [ResponseCache(NoStore = true, Duration = 0)]
        public PersonnelViewModel MapToPersonnelVM(Personnel personnel)
        {
            PersonnelViewModel personnelvm = new PersonnelViewModel();
            personnelvm.StaffId = personnel.StaffId;
            personnelvm.StaffName = personnel.StaffName;
            personnelvm.Gender = personnel.Gender;
            personnelvm.DateEmployed = personnel.DateEmployed;
            personnelvm.Vocation = personnel.Vocation;
            personnelvm.EmailAddr = personnel.EmailAddr;
            personnelvm.Status = personnel.Status;
            personnelvm.csList = personnelContext.FindScheduleBasedID(personnel.StaffId);

            return personnelvm;
        }

        public ActionResult AssignPersonnel(int id)
        {
            TempData["scheduleID"] = id;
            PersonnelViewModel personnelvm = new PersonnelViewModel();
            List<Personnel> pilotList = personnelContext.GetPilots();
            ViewData["Pilot List"] = PilotDropDown(pilotList);
            List<Personnel> attendantList = personnelContext.GetFlightAttendants();
            ViewData["Attendant List"] = AttendantDropDown(attendantList);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AssignPersonnel(CrewIDs id)
        {
            List<FlightCrew> crewList = new List<FlightCrew>();
            List<int> idList = id.crewID();
            List<string> roles = new List<string>() { "Flight Captain", "Second Pilot", "Cabin Crew Leader", "Flight Attendant" };
            for (int i = 0; i < idList.Count(); i++)
            {
                FlightCrew flightcrew = new FlightCrew();
                int index = i;
                if (i > 2)
                {
                    index = 3;
                }
                flightcrew.Role = roles[index];
                flightcrew.StaffId = idList[i];
                flightcrew.scheduleID = (int)TempData.Peek("scheduleID");
                crewList.Add(flightcrew);
                crewContext.Update(flightcrew);
            }
            return View();
        }

        public List<Personnel> GetPilots()
        {
            List<Personnel> pilotList = personnelContext.GetPilots();
            return pilotList;
        }

        public List<SelectListItem> PilotDropDown(List<Personnel> pilotList)
        {
            List<SelectListItem> pilotidlist = new List<SelectListItem>();
            foreach (Personnel pilot in pilotList)
            {
                pilotidlist.Add(new SelectListItem
                {
                    Value = pilot.StaffId.ToString(),
                    Text = pilot.StaffId.ToString()
                });
            }
            return pilotidlist;
        }

        public List<Personnel> GetFlightAttendants()
        {
            List<Personnel> attendantList = personnelContext.GetFlightAttendants();
            return attendantList;
        }
        public List<SelectListItem> AttendantDropDown(List<Personnel> attendantList)
        {
            List<SelectListItem> attendantidlist = new List<SelectListItem>();
            foreach (Personnel attendant in attendantList)
            {
                attendantidlist.Add(new SelectListItem
                {
                    Value = attendant.StaffId.ToString(),
                    Text = attendant.StaffId.ToString()
                });
            }
            return attendantidlist;
        }
        public ActionResult UpdatePersonnelStatus(int? id)
        {
            Personnel personnel = personnelContext.GetDetails(id.Value);
            if (personnel == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["StatusList"] = personnelContext.GetStatus();
            return View(personnel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePersonnelStatus(Personnel personnel)
        {
            ScheduleModel schedule = scheduleContext.getSchedule(personnel.StaffId);
            DateTime date = DateTime.Today;
            bool datecheck = false;
            if (schedule != null)
            {
                if (schedule.departDateTime > date)
                {
                    datecheck = true;
                }
                else
                {
                    datecheck = false;
                }
            }
            if (ModelState.IsValid)
            {
                personnelContext.Update(personnel);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}
