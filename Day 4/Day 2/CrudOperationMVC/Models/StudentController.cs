using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationMVC.Models
{
    public class StudentController : Controller
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int age { get; set; }
       // public IFormFile formFile { get; set; }
        //[Required(ErrorMessage ="Please Choose Student Image")]
        //[Display(Name ="Student Image")]
        //[NotMapped]
        //public IFormFile StudentImage { get; set; }
    }
}
