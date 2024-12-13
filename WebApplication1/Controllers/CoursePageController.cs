using Cumulative1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative1.Controllers
{
    public class CoursePageController : Controller
    {
        private readonly CourseAPIController _api;

       
        public CoursePageController(CourseAPIController api) {
            _api = api;
        }

            public IActionResult List()
        {
            List<Course> courses = _api.ListCourse();
            return View(courses);
        }
    
        public IActionResult Show(int id)
        {
            Course SelectedCourse = _api.FindCourse(id);
            return View(SelectedCourse);
        }
 
        public IActionResult DeleteConfirm(int id)
        {
            Course SelectedStudent = _api.FindCourse(id);
            return View(SelectedStudent);
        }
     
        public IActionResult Delete(int id)
        {
            int StudentId = _api.DeleteCourse(id);
       
            return RedirectToAction("List");
        }
      
        public IActionResult New(int id)
        {
            return View();
        }

        public IActionResult Create(Course NewCourse)
        {
            int TeacherId = _api.AddCourse(NewCourse);


            return RedirectToAction("Show", new { id = TeacherId });
        }
    }
}