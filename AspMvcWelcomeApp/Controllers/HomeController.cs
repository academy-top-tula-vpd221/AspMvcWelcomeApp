using AspMvcWelcomeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Xml.Linq;

namespace AspMvcWelcomeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ITimeService timeService;

        public HomeController(ILogger<HomeController> logger, ITimeService timeService)
        {
            _logger = logger;
            //this.timeService = timeService;
        }

        public IActionResult Index([FromServices] ITimeService timeService)
        {
            //return new HomeResult("Sammy");
            //return new ContentResult() 
            //{ 
            //    Content = "<h1>Hello world and people</h1>",
            //    ContentType = "text/html"
            //};
            //return new EmptyResult();
            // return new NoContentResult();

            //return Content("Hello");
            //return Json("Hello");

            //return new ObjectResult(new Employee() { Name = "Bobby", Age = 25 });
            //return Redirect("~/Home/Privacy");
            //return RedirectToAction("Home", "Name", new Employee() { Name = "Sammy", Age = 35 });

            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "doc.pdf");

            //return PhysicalFile(path, "text/plain");
            ITimeService? timeService1 = HttpContext.RequestServices.GetService<ITimeService>();
            return Content(timeService1.Time);
        }

        //[HttpGet]
        //public async Task Index()
        //{
        //    string form = @"
        //    <form method='post'>
        //        <input type='text' name='name'/>
        //        <input type='number' name='age'/>
        //        <input type='submit' value='Send'/>
        //    </form>";

        //    Response.ContentType = "text/html; charset=utf-8";
        //    await Response.WriteAsync(form);
        //}

        //[HttpPost]
        //public string Index(string name, int age)
        //{
        //    return $"You name: {name}, Age: {age}";
        //}

        //public async Task Index()
        ////public async IActionResult Index()
        ////public string Index()
        //{
        //    var context = this.ControllerContext.HttpContext;

        //    Response.ContentType = "text/html; charset=utf-8";
        //    await Response.WriteAsync("<h1>Hello world</h1>");
        //    //return View();
        //    //return "Hello world";
        //}

        public string Name(Employee employee)
        //public string Name()
        {
            string name = Request.Query["name"];
            string age = Request.Query["age"];

            return $"You name: {name}, Age: {age}";
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

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
