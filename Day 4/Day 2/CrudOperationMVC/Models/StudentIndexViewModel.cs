using System.Collections.Generic;

namespace CrudOperationMVC.Models
{
    public class StudentIndexViewModel
    {
      public  List<Student> students { get; set; } = new List<Student>();
        public string TextToSearch { get; set; }
    }
}
