using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeMVC.Models
{
    public class DepartmentsMVC
    {
        [DisplayName("Department Name")]
        [Required(ErrorMessage ="Please enter the name")]
        public string DeptName { get; set; }
        [DisplayName("Department Group Name")]
        [Required(ErrorMessage ="Please enter the group name")]
        public string DeptGroupName { get; set; }
    }
}