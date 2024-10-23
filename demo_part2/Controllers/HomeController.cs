using demo_part2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace demo_part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //check the connection
            try
            {
                //get the connection string from the connectoin class
                connection conn = new connection();
                //then check
                using (SqlConnection connect = new SqlConnection(conn.connecting()))
                {
                    //open the connetion
                    connect.Open();
                    Console.WriteLine("connected");
                    connect.Close();

                }

            }
            catch (IOException error) {
                //error message
                Console.WriteLine("Error : " + error.Message);

            }


            return View();
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


        //http post for the register 
        //From the register form
        [HttpPost]
        public IActionResult Register_user(register add_user)
        {
            //collect user's value
            string name = add_user.username;
            string email = add_user.email;
            string password = add_user.password;
            string role = add_user.role;

            //check if all are collected
           //Console.WriteLine("Name: " + name + "\nEmail: " + email + "Role: " + role);
           
            //pass all the values to insert method
          string message =  add_user.insert_user(name, email, role,password);

            //then check if the user is inserted
            if (message == "done")
            {
                //track error output
                Console.Write(message);
                //redirect
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //track error output
                Console.Write(message);
                //redirect
                return RedirectToAction("Index", "Home");
            }


        }

        //for login page
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        //login page
        [HttpPost]
        public IActionResult login_user(check_login user)
        {
            //then assign
            string email = user.email;
            string role = user.role;
            string password = user.password;

            string message = user.login_user(email, role, password);

            if (message=="found")
            {

                Console.WriteLine(message);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                Console.WriteLine(message);
                return RedirectToAction("Login", "Home");
            }

        }


        [HttpPost]
        public IActionResult claim_sub(claim insert)
        {
            //assign 
            string module_name = insert.user_email;
            string hour_work = insert.hours_worked;
            string hour_rate = insert.hour_rate;
            string description = insert.description;

            string message = insert.insert_claim(module_name,hour_work,hour_rate,description);


            if (message=="done")
            {
                Console.WriteLine(message);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                Console.WriteLine(message);
                return RedirectToAction("Dashboard", "Home");
            }
        }



    }
}
