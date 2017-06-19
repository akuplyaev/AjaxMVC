using System.Collections.Generic;
using System.Data.Entity;

namespace AjaxMVC.Models
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext() : base("AjaxMVC")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
    public class DbInitializer : CreateDatabaseIfNotExists<DepartmentContext>
    {
        protected override void Seed(DepartmentContext db)
        {
            Department control = new Department()
            {
                DepartmentName = "Управление",
                Employees = new List<Employee>()
                {
                    new Employee() {FirstMidName = "Иван",LastName = "Иванов",Position = "Руководитель управления"}
                }
            };
            Department department1 = new Department()
            {
                DepartmentName = "Отдел1",
                ParentDepartment = control,
                Employees = new List<Employee>()
                {
                    new Employee() {FirstMidName = "test11",LastName = "Test11",Position = "Руководитель отдела1"},

                }
            };
            Department department2 = new Department()
            {
                DepartmentName = "Отдел2",
                ParentDepartment = control,
                Employees = new List<Employee>()
                {
                    new Employee() {FirstMidName = "test21",LastName = "Test21",Position = "Руководитель отдела2"},
                    new Employee(){FirstMidName = "test22",LastName = "Test22",Position = "Заместитель руководителя отдела2"},
                }
            };
            Department department3 = new Department()
            {
                DepartmentName = "Отдел3", ParentDepartment = control,
                Employees = new List<Employee>()
                {
                    new Employee() {FirstMidName = "test31",LastName = "Test31",Position = "Руководитель отдела3"},                    
                }
            };
            Department group11 = new Department()
            {
                DepartmentName = "Группа11",
                ParentDepartment = department1,
                Employees = new List<Employee>()
                {
                    new Employee() {FirstMidName = "test111",LastName = "Test111",Position = "руководитель группы11"},
                    new Employee(){FirstMidName = "test112",LastName = "Test112",Position = "Еще какая-то должность"},
                }
            };
            Department group12 = new Department()
            {
                DepartmentName = "Группа12",
                ParentDepartment = department1,
                Employees = new List<Employee>()
                {
                    new Employee() {FirstMidName = "test121",LastName = "Test121",Position = "Еще какая-то должность"},
                    new Employee(){FirstMidName = "test121",LastName = "Test121",Position = "Еще какая-то должность"},
                }
            };                       
            Department group22 = new Department()
            {
                DepartmentName = "Группа22",
                ParentDepartment = department2,
                Employees = new List<Employee>()

                    {
                        new Employee() {FirstMidName = "Test221",LastName = "Test221",Position = "Еще какая-то должность"},
                        new Employee() {FirstMidName = "Test222",LastName = "Test222",Position = "Еще какая-то должность"}
                    }
            };
            db.Departments.AddRange(new List<Department>()
            {
                control,
                department1,
                department2,
                department3,
                group11,
                group12,                
                group22
            });
            db.SaveChanges();
            base.Seed(db);
        }
        
    }
}