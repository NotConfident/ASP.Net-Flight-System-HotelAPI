using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using web2020apr_p01_t3.Models;
using web2020apr_p01_t3.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;


namespace web2020apr_p01_t3.Controllers
{
    public class HomeController : Controller
    {
        //Add your DAL here for testing
        private CommonDAL commonContext = new CommonDAL();
        private CustomerDAL customerContext = new CustomerDAL();
        private ScheduleDAL scheduleContext = new ScheduleDAL();
        private RouteDAL routeContext = new RouteDAL();


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult Index(IFormCollection fData)
        {
            if(HttpContext.Session.GetString("Role") != "Administrator" || HttpContext.Session.GetString("Role") == "Customer")
            {
                HttpContext.Session.Clear();
            }
            string dCity = fData["dCity"].ToString();
            string aCity = fData["aCity"].ToString();
            int? routeID = routeContext.getRouteID(dCity, aCity);
            List<ScheduleModel> scheduleList = scheduleContext.getScheduleList(routeID);
            return View(scheduleList);
        }
       

        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult SearchAPI()
        {
            return View();  
        }

        public ActionResult SendEmail()
        {
            TempData["EmailReceived"] = "Thank you for your enquiry. We will get back to you as soon as possible.";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult login(IFormCollection formData)
        {
            // Read inputs from textboxes
            // Email address converted to lowercase
            //string loginID = formData["txtLoginID"].ToString();
            //string admin = "Admin";
            //string password = formData["txtPassword"].ToString();
            string time = DateTime.Now.ToString("dd-MMMM-yyyy hh:mm:ss tt");

            
            Login user = commonContext.CheckLogin(formData["txtLoginID"], formData["txtPassword"]);
            int id = customerContext.getID(formData["txtLoginID"], formData["txtPassword"]);

            if (user.Vocation == "Administrator")
            {
                // Store Login ID in session with the key “LoginID”
                HttpContext.Session.SetString("LoginID", user.Email);
                // Store user role “Admin” as a string in session with the key “Role”
                HttpContext.Session.SetString("Role", user.Vocation);

                HttpContext.Session.SetString("TimeLog", time);

                TempData["Login"] = "Logged in succesfully!!";
                // Redirect user to the "Admin" view through an action
                return RedirectToAction("Index", "AdminActions");
            }
            else if (id > 0)
            {
              
                HttpContext.Session.SetString("Role", "Customer");
                HttpContext.Session.SetInt32("userID", id);
                return RedirectToAction("Index", "Customer"); // change to user home
            }
            else
            {
                // Store an error message in TempData for display at the index view
                TempData["Message"] = "Invalid Login Credentials!";

                // Redirect user back to the index view through an action
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<ActionResult> HotelAPI(Hotel input)
        {
            //Retreive access token
            string accessToken =
            "[Insert API Key here]";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.makcorps.com");
            //Add the access token to the header
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", accessToken);

            HttpResponseMessage response = await
            client.GetAsync("/free/" + input.country);

            if (response.IsSuccessStatusCode)
            {
                List<Hotel> hotelList = new List<Hotel>();
                string data = await response.Content.ReadAsStringAsync();

                var obj = JsonConvert.DeserializeObject<Hotel>(data);
                //var jsonSerial = JsonConvert.SerializeObject(obj.Comparison);
                var jsonFormat = JObject.Parse(data);

                Hotel hotelModel = new Hotel();

                for (int i = 0; i < obj.Comparison.Count(); i++) //i < obj.Comparison.Count()
                {
                    var hotelObj = jsonFormat["Comparison"][i];
                    hotelModel.hotelList.Add(hotelObj);
                }


                for (int i = 0; i < hotelModel.hotelList.Count()-1; i++)
                {
                    Hotel hotel = new Hotel();

                    var jsonSerial = jsonFormat["Comparison"][i];

                    hotel.hotelName = jsonSerial[0]["hotelName"].ToString();
                    hotel.hotelId = jsonSerial[0]["hotelId"].ToString();

                    hotel.price1 = jsonSerial[1][0]["price1"].ToString();
                    hotel.tax1 = jsonSerial[1][0]["tax1"].ToString();
                    hotel.vendor1 = jsonSerial[1][0]["vendor1"].ToString();

                    hotel.price2 = jsonSerial[1][1]["price2"].ToString();
                    hotel.tax2 = jsonSerial[1][1]["tax2"].ToString();
                    hotel.vendor2 = jsonSerial[1][1]["vendor2"].ToString();

                    hotel.price3 = jsonSerial[1][2]["price3"].ToString();
                    hotel.tax3 = jsonSerial[1][2]["tax3"].ToString();
                    hotel.vendor3 = jsonSerial[1][2]["vendor3"].ToString();

                    hotel.price4 = jsonSerial[1][3]["price4"].ToString();
                    hotel.tax4 = jsonSerial[1][3]["tax4"].ToString();
                    hotel.vendor4 = jsonSerial[1][3]["vendor4"].ToString();

                    hotel.price5 = jsonSerial[1][4]["price5"].ToString();
                    hotel.tax5 = jsonSerial[1][4]["tax5"].ToString();
                    hotel.vendor5 = jsonSerial[1][4]["vendor5"].ToString();

                    hotelList.Add(hotel);              
                }
                return View(hotelList);
            }
            else if (!response.IsSuccessStatusCode)
            {
                TempData["APIError"] = "Unable to retrieve Data!";
                return RedirectToAction("HotelAPI" , "Home");
            }
            else
            {
                return RedirectToAction("HotelAPI", "Home");
            }
        }

        //public ActionResult profile()
        //{
        //    // Stop accessing the action if not logged in
        //    // or account not in the "Staff" role
        //    if ((HttpContext.Session.GetString("CustomerID") == null))
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return RedirectToAction("profile", "Customer");
        //}


        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult LogOut()
        {
            // Clear all key-values pairs stored in session state
            HttpContext.Session.Clear();
            TempData["Logout"] = "Logged out successfully!!";
            // Call the Index action of Home controller
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
