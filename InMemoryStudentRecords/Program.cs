using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InMemoryStudentRecords
{
    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            LoadStudents(students, "StudentRecords.csv");
            string menuOption = "";
            while (menuOption != "0")
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Create new student student");
                Console.WriteLine("2. Find student students");
                Console.WriteLine("Enter selection:");
                menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        CreateNewStudentRecord(students);
                        break;
                    case "2":
                        FindStudents(students);
                        break;
                    default:
                        Console.WriteLine("Selection not valid.");
                        break;
                }
            }
        }

        private static void CreateNewStudentRecord(List<Student> students)
        {
            //Comment Edd is working on this.
            Console.WriteLine("Please input the new students information using the format:");
            Console.WriteLine("Id no., forename, surname, D.O.B., grade");
            string recordInput = Console.ReadLine();
            var student = ConvertStringToStudent(recordInput);
            students.Add(student);
            Console.WriteLine("Thank you, input succesful");
            Console.ReadKey();
        }

        private static void ReadStudentRecord(List<Student> students)
        {
            Console.WriteLine("please select which student is required");
            string option = Console.ReadLine();
            int optionint = Convert.ToInt32(option);
            var student = students.First(r => r.Id == optionint);
            Console.WriteLine(student.ConvertToString());
        }

        static void FindStudents(List<Student> students)
        {
            string menuOption = "";
            while (menuOption != "0")
            {
                Console.WriteLine("Find Students Menu");
                Console.WriteLine("1. Find by match");
                Console.WriteLine("2. Find by Id");
                Console.WriteLine("3. Find by first name");
                Console.WriteLine("4. Find by last name");
                Console.WriteLine("5. Find by Grade");
                Console.WriteLine("6. Find by Date Of Birth");
                Console.WriteLine("0. Back to Main Menu");
                Console.WriteLine("Enter selection:");
                menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        FindByMatch(students);
                        break;
                    case "2":
                        FindById(students);
                        break;
                    case "3":
                        FindByFirstName(students);
                        break;
                    case "4":
                        FindByLastName(students);
                        break;
                    case "5":
                        FindByGrade(students);
                        break;
                    case "6":
                        FindByDateOfBirth(students);
                        break;
                    case "0":
                        return; //To Main method & hence main menu
                    default:
                        break;
                }
            }
        }

        static void LoadStudents(List<Student> students, string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line.Length > 1000000)
                    {

                        throw new Exception("greater than 10 numbers");
                    }
                    if (line != "")
                    {
                        var student = ConvertStringToStudent(line);
                        students.Add(student);
                    }

                }
            }
            Console.WriteLine("done");
        }

        #region Find sub-menu actions
        private static void FindByMatch(List<Student> students)
        {
            throw new NotImplementedException();
        }

        private static void FindById(List<Student> students)
        {
            Console.WriteLine("Please Enter ID:");
            string option = Console.ReadLine();
            int optionint = Convert.ToInt32(option);
            Console.WriteLine(students.First(r => r.Id == optionint).ConvertToString());
        }

        private static void FindByFirstName(List<Student> students)
        {
            Console.WriteLine("Please enter first name:");
            string option = Console.ReadLine();
            var results = students.Where(r => r.FirstName.Trim().Contains(option));
            foreach (var student in results)
            {
                Console.WriteLine(student);
            }


        }

        private static void FindByLastName(List<Student> students)
        {
            Console.WriteLine("please enter their surname");
            string option = Console.ReadLine();
            var results = students.Where(r => r.LastName.Trim().Contains(option));
            foreach (var student in results)
            {
                Console.WriteLine(student.ConvertToString());
            }

        }

        private static void FindByGrade(List<Student> students)
        {

            Console.WriteLine("please enter which grade is required");
            string grade = Console.ReadLine();
            char gradechar = Convert.ToChar(grade);
            var results = (students.Where(r => r.Grade == gradechar));
            foreach (var student in results)
            {
                Console.WriteLine(student.ConvertToString());
            }
        }

        private static void FindByDateOfBirth(List<Student> students)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Helper methods for Tuples
        private static Student ConvertStringToStudent(string s)
        {
            string[] fields = s.Split(',');
            int Id = Convert.ToInt32(fields[0]);
            string firstname = Convert.ToString(fields[1]);
            string surname = Convert.ToString(fields[2]);
            DateTime DOB = Convert.ToDateTime(fields[3]);
            char Grade = Convert.ToChar(fields[4].Trim());
            var student = new Student(Id, firstname, surname, DOB);
            student.Grade = Grade;
            return student;
        }

        #endregion
    }
}

