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
            List<Student> records = new List<Student>();
            string menuOption = "";
            while (menuOption != "0")
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Create new student record");
                Console.WriteLine("2. Read student record");
                Console.WriteLine("3. Update student record");
                Console.WriteLine("4. Delete student record");
                Console.WriteLine("5. Find student records");
                Console.WriteLine("6. Load Data File");
                Console.WriteLine("7. Back-up Data File");
                Console.WriteLine("8. Write Data File");
                Console.WriteLine("0. Quit");
                Console.WriteLine("Enter selection:");
                menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        CreateNewStudentRecord(records);
                        break;
                    case "2":
                        ReadStudentRecord(records);
                        break;
                    case "3":
                        UpdateStudentRecord(records);
                        break;
                    case "4":
                        DeleteStudentRecord(records);
                        break;
                    case "5":
                        FindStudents(records);
                        break;
                    case "6":
                        LoadDataFile(records);
                        break;
                    case "7":
                        WriteDataFile(records);
                        break;
                    case "8":
                        WriteDataFile(records);
                        break;
                    default:
                        Console.WriteLine("Selection not valid.");
                        break;
                }
            }
        }

        private static void CreateNewStudentRecord(List<Student> records)
        {
            //Comment Edd is working on this.
            Console.WriteLine("Please input the new students information using the format:");
            Console.WriteLine("Id no., forename, surname, D.O.B., grade");
            string recordInput = Console.ReadLine();
            var newrecord = ConvertStringToStudent(recordInput);
            Console.WriteLine("Thank you, input succesful");
            Console.ReadKey();
        }

        private static void ReadStudentRecord(List<Student> records)
        {
            Console.WriteLine("please select which record is required");
            string option = Console.ReadLine();
            int optionint = Convert.ToInt32(option);
            var record = records.First(r => r.Id == optionint);
            Console.WriteLine(record.ConvertToString());
        }

        private static void UpdateStudentRecord(List<Student> records)
        {
            throw new NotImplementedException();
        }

        private static void DeleteStudentRecord(List<Student> records)
        {
            throw new NotImplementedException();
        }

        static void FindStudents(List<Student> records)
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
                        FindByMatch(records);
                        break;
                    case "2":
                        FindById(records);
                        break;
                    case "3":
                        FindByFirstName(records);
                        break;
                    case "4":
                        FindByLastName(records);
                        break;
                    case "5":
                        FindByGrade(records);
                        break;
                    case "6":
                        FindByDateOfBirth(records);
                        break;
                    case "0":
                        return; //To Main method & hence main menu
                    default:
                        break;
                }
            }
        }

        static void LoadDataFile(List<Student> records)
        {
            string input = "";
            bool success = false;
            do
            {
                try
                {
                    Console.WriteLine("enter the file name .csv");
                    input = Console.ReadLine();
                    using (StreamReader reader = new StreamReader(input))
                    {
                    }
                    success = true;
                }

                catch (FileNotFoundException)
                {
                    Console.WriteLine("not a valid file name");
                }
            } while (success == false);
            using (StreamReader reader = new StreamReader(input))
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
                        var record = ConvertStringToStudent(line);
                        records.Add(record);
                    }

                }
            }
            Console.WriteLine("done");
        }
        static void WriteDataFile(List<Student> records)
        {
            Console.WriteLine("Please name the output file:");
            string outputFileName = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(outputFileName + ".csv"))
            {
                for (int i = 0; i < records.Count; i++)
                {
                    var line = records[i].ConvertToString();
                    writer.WriteLine(line);
                }
                writer.Flush();
            }
        }

        #region Find sub-menu actions
        private static void FindByMatch(List<Student> records)
        {
            throw new NotImplementedException();
        }

        private static void FindById(List<Student> records)
        {
            Console.WriteLine("Please Enter ID:");
            string option = Console.ReadLine();
            int optionint = Convert.ToInt32(option);
            Console.WriteLine(records.First(r => r.Id == optionint).ConvertToString());
        }

        private static void FindByFirstName(List<Student> records)
        {
            Console.WriteLine("Please enter first name:");
            string option = Console.ReadLine();
            var results = records.Where(r => r.FirstName.Trim().Contains(option));
            foreach (var sr in results)
            {
                Console.WriteLine(sr);
            }


        }

        private static void FindByLastName(List<Student> records)
        {
            Console.WriteLine("please enter their surname");
            string option = Console.ReadLine();
            var results = records.Where(r => r.LastName.Trim().Contains(option));
            foreach (var sr in results)
            {
                Console.WriteLine(sr.ConvertToString());
            }

        }

        private static void FindByGrade(List<Student> records)
        {

            Console.WriteLine("please enter which grade is required");
            string grade = Console.ReadLine();
            char gradechar = Convert.ToChar(grade);
            var results = (records.Where(r => r.Grade == gradechar));
            foreach (var result in results)
            {
                Console.WriteLine(result.ConvertToString());
            }
        }

        private static void FindByDateOfBirth(List<Student> records)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Helper methods for Tuples
        private static Student ConvertStringToStudent(string s)
        {
            string[] record = s.Split(',');
            int ID = Convert.ToInt32(record[0]);
            string firstname = Convert.ToString(record[1]);
            string surname = Convert.ToString(record[2]);
            DateTime DOB = Convert.ToDateTime(record[3]);
            char Grade = Convert.ToChar(record[4].Trim());
            var student = new Student(ID, firstname, surname, DOB);
            student.Grade = Grade;
            return student;
        }

      
        #endregion
    }
}

