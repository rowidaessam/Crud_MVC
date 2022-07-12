using CrudOperationMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace CrudOperationMVC.Models
{
    public interface Istudent
    {
        public List<StudentController> getAllStudents();
        public StudentController getStudentById(int id);
        public void updateStudent(int id, string name, int age);
        public void removeStudent(int id);
        public void addStudent(int id, string name, int age);
    }

    public class StudentMoc : Istudent
    {

        static List<StudentController> Students = new List<StudentController>()
        {
                new StudentController() { id = 1, name = "Rowida"  ,age = 22 },
                new StudentController() { id = 2, name = "Abdo"    ,age = 23  },
                new StudentController() { id = 3, name = "ahmed"   ,age = 18  },
                new StudentController() { id = 1, name = "Amr"     ,age = 25   },
                new StudentController() { id = 2, name = "mahmoud" ,age = 23   },
                new StudentController() { id = 3, name = "Nada"    ,age = 25  },
                new StudentController() { id = 1, name = "Marwa"   ,age = 24   },
                new StudentController() { id = 2, name = "toqa"    ,age = 26  },
                new StudentController() { id = 3, name = "saber"   ,age = 23   }
        };

        public List<StudentController> getAllStudents()
        {
            return Students;
        }
        public StudentController getStudentById(int id)
        {
            return Students.FirstOrDefault(q => q.id == id);
        }
        public void addStudent(int _id, string _name, int _age)
        {
            Students.Add(new StudentController() { id = _id, name = _name, age = _age });
        }
        public void removeStudent(int _id)
        {

            Students.Remove(getStudentById(_id));

        }
        public void updateStudent(int id, string name, int age)
        {
            var stdup = Students.FirstOrDefault(q => q.id == id);
            stdup.name = name;
            stdup.age = age;


        }




        public class StudentDb : Istudent
        {
            ITIContextDB context = new ITIContextDB();
            public void addStudent(int id, string name, int age)
            {
                //context.students.Add(context.students.FirstOrDefault(q => q.id == id));
                //context.students.Add(context.students.FirstOrDefault(n=>n.name==name));
                //context.students.Add(context.students.FirstOrDefault(a=>a.age==age));
                //context.SaveChanges();
                throw new NotImplementedException();
            }


            public List<StudentController> getAllStudents()
            {
                //return context.students.Include(a => a.Department).ToList();
                throw new NotImplementedException();
            }

            public StudentController getStudentById(int id)
            {
                //Student s = context.students.FirstOrDefault(a=>a.id==id);
                //return s;
                throw new NotImplementedException();
            }

            public void removeStudent(int id)
            {
                //Student std = context.students.FirstOrDefault(a=>a.id==id);
                //context.Remove(std);
                //context.SaveChanges();
                throw new NotImplementedException();
            }

            public void updateStudent(int id, string name, int age)
            {
                //Student std = context.students.FirstOrDefault(a => a.id == id);
                //std.name = name;
                //std.age = age;
                //std.deptId = depId;
                //context.SaveChanges();


                throw new NotImplementedException();
            }
        }

    }
}

