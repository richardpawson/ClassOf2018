using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Template.Model;

namespace Template.DataBase
{
    public class ExampleDbInitializer : DropCreateDatabaseAlways<ExampleDbContext>
    {
        private ExampleDbContext Context;
        protected override void Seed(ExampleDbContext context)
        {
            this.Context = context;
            AddNewStudent("Alie Algol", "21/03/2001");
            AddNewStudent("Forrest Fortran", "17/08/2001");
            AddNewStudent("James Java", "29/11/2000");
            AddNewStudent("Bas Basic", "25/12/2001");
            AddNewStudent("Dylan Dylan", "15/1/2000");
            AddNewStudent("Penny Python", "14/2/2001");
            AddNewStudent("Samantha Smalltalk", "20/9/2001");

            AddNewTeacher("David Dell", "Computer Science");
            AddNewTeacher("Andy Apple", "Computer Science");
            AddNewTeacher("Len Lenovo", "Computer Science");
            AddNewTeacher("Agnes Agincourt", "History");
            AddNewTeacher("Harry Hastings", "History");
            AddNewTeacher("Yolanda Ypres", "History");
            AddNewTeacher("Travis Trafalgar", "History");
            AddNewTeacher("Gwen Gondwanaland", "Geography");
        }

        private void AddNewStudent(string name, string dob)
        {
            var dobDate = Convert.ToDateTime(dob);
            var st = new Student() { FullName = name, DateOfBirth = dobDate };
            Context.Students.Add(st);
        }

        private void AddNewTeacher(string name, string dept)
        {
            var t = new Teacher() { FullName = name, Department = dept };
            Context.Teachers.Add(t);
        }
    }
}
