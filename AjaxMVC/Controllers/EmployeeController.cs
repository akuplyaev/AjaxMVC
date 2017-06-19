using System.Data.Entity;
using System.Web.Mvc;
using AjaxMVC.Models;

namespace AjaxMVC.Controllers
{
    public class EmployeeController : Controller
    {
        DepartmentContext db = new DepartmentContext();
        public PartialViewResult DeleteEmployee(int employeeId)
        {
            Employee employee = db.Employees.Find(employeeId);
            db.Employees.Remove(employee);
            db.SaveChanges();
            var list = db.Departments;
            return PartialView("_PartialIndex",list);
        }
        public PartialViewResult AddEmployee(int departmentId)
        {
            var department = db.Departments.Find(departmentId);
            ViewBag.Department = department;
            return PartialView("_PartialAddEmployee");
        }
        public PartialViewResult CreateEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            var departments = db.Departments;
            return PartialView("_PartialIndex", departments);
        }

        public PartialViewResult EditEmployee(int employeeId)
        {
            var employee = db.Employees.Find(employeeId);           
            SelectList departmentList = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Departments = departmentList;
            return PartialView("_PartialEditEmployee",employee);
        }

        public PartialViewResult UpdateEmployee(Employee employee)
        {
           
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            var departments = db.Departments;
            return PartialView("_PartialIndex", departments);
        }
    }
}