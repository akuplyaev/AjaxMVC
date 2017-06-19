using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxMVC.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string DepartmentName { get; set; }       
        public int? ParentDepartmentId { get; set; }
        [ForeignKey("ParentDepartmentId")]
        public Department ParentDepartment { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees=new List<Employee>();
        }
    }
    
    
   
}