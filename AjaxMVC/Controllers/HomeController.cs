using System.Linq;
using System.Web.Mvc;
using AjaxMVC.Models;

namespace AjaxMVC.Controllers
{
    public class HomeController : Controller
    {
        DepartmentContext db = new DepartmentContext();
        public ActionResult Index()
        {
            var listDepartments = db.Departments;
            return View(listDepartments);
        }

        public PartialViewResult PartialIndex()
        {            
            var listDepartments = db.Departments;
            return PartialView("_PartialIndex", listDepartments);
        }
        public PartialViewResult AddDepartment(int parentId)
        {
            
            var parentDepartment = db.Departments.Find(parentId);
            ViewBag.ParentDepartment = parentDepartment;
            return PartialView("_PartialAddDepartment");
        }
        public PartialViewResult CreateDepartment(Department department)
        {

            db.Departments.Add(department);
            db.SaveChanges();
            var departments = db.Departments;
            return PartialView("_PartialIndex",departments);

        }
        public PartialViewResult DeleteDepartment(int? departmentId)
        {

            var department = db.Departments.Find(departmentId);
            DeleteTree(department);
            db.SaveChanges();
            var departments = db.Departments;
            return PartialView("_PartialIndex", departments);

        }
        public void DeleteTree(Department department)
        {

            var depChild = db.Departments.Where(d => d.ParentDepartmentId == department.DepartmentId)
                .OrderBy(d => d.DepartmentId);
            if (depChild.Any())
            {
                foreach (var child in depChild)
                {
                    DeleteTree(child);
                    db.Departments.Remove(child);
                }
                db.Departments.Remove(department);
            }
            else
            {
                db.Departments.Remove(department);
            }
        }

    }
}