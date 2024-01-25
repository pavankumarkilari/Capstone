using BlogMVC.Models;
using Microsoft.AspNetCore.Mvc;
using BlogWebApp;

namespace BlogMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Employee> adminlist;
            HttpResponseMessage response = GlobalVar.WebApiClient.GetAsync("EmpInfoes").Result;
            adminlist = response.Content.ReadFromJsonAsync<IEnumerable<Employee>>().Result;
            return View(adminlist);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new Employee());
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            HttpResponseMessage response = GlobalVar.WebApiClient.PostAsJsonAsync("EmpInfoes", employee).Result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            return RedirectToAction("Create", "Blog");

        }
        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Employee");
        }



    }
}