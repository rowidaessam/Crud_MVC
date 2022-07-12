using CrudOperationMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudOperationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Istudent std = new StudentMoc();
         Istudent std;
        public HomeController(Istudent _std)
        {
            std = _std;
        }
        public IActionResult Index(string searchText, int? num)
        {
            ViewBag.text = "";
            List<StudentController> students = std.getAllStudents();
            if (searchText != null)
            {
                students = students.FindAll(a => a.name.Contains(searchText));
                ViewBag.text = searchText;
                num = num;
            }
            if(num != null)
            {
                students = students.Take(num.Value).ToList();
            }

                return View(students);
        }
        #region StudentIndexViewModel
        //public IActionResult Index(string searchText)
        //{
        //    List<Student> students = std.getAllStudents();
        //    if (searchText != null)
        //    {
        //        students = students.FindAll(a => a.name.Contains(searchText));

        //    }
        //    StudentIndexViewModel model = new StudentIndexViewModel()
        //    {
        //        students = students,
        //        TextToSearch = searchText ?? "NA"

        //    };
        //    return View(students);
        //}
        #endregion
        [HttpGet]
        public IActionResult create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult create(int id, string name, int age)//, IFormFile formFile)
        {
            //var arr = formFile.FileName.Split('.');
            //string ext = arr[arr.Length - 1];
            //string path = ".//wwwroot//" + name + id + "." + ext;

            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    formFile.CopyTo(stream);
            //}
            //std.addStudent(id, name, age, formFile);
            std.addStudent(id, name, age);




            return RedirectToAction("index", std.getAllStudents());
            
            
        }
        // update
        public IActionResult update(int id)
        {
            StudentController model = std.getStudentById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult update(int id, string name, int age)
        {
            std.updateStudent(id, name, age);

            return RedirectToAction("index", std.getAllStudents());
        }
        // delete
        public IActionResult delete(int? id)
        {
           
            if (id == null)
                return BadRequest();
            StudentController stud = std.getStudentById(id.Value);
            if (stud == null)
                return NotFound();
            //  std.removeStudent(id.Value);
            // return RedirectToAction("index", std.getAllStudents());
            return View(stud);

        }
        [HttpPost]
       // [ActionName("delete")]
        public IActionResult deleteConfirmed(int? id)
        {
            std.removeStudent(id.Value);
            return RedirectToAction("index", std.getAllStudents());

        }
        //details
        public IActionResult details(int? id)
        {
            if (id == null)
                return BadRequest();
            StudentController stud = std.getStudentById(id.Value);
            if (stud == null)
                return NotFound();
            return View(stud);
        }
       

        //upload
        [HttpPost]
        public IActionResult Upload(string name, IFormFile formFile)
        {
            var arr = formFile.FileName.Split(".");
            string extension = arr[arr.Length-1];
            //string path = ".//wwwroot//Images//"+formFile.FileName;
            string path = ".//wwwroot//Images//" +name+"."+extension;
            using (var streamPath = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(streamPath);
            }
            //formFile.FileName
            return Content("Image added");
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