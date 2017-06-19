using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get;set;}
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string FirstMidName { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Position { get; set; }        
        public  int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
     }
}
