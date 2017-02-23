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
            List<Tuple<int, string, string, DateTime, char>> records = new List<Tuple<int, string, string, DateTime, char>>();
            LoadStudents(records, "StudentRecords.csv");
            string menuOption = "";
            while (menuOption != "0")
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Create new student record");
                Console.WriteLine("2. Find student records");
                Console.WriteLine("Enter selection:");
                menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        CreateNewStudentRecord(records);
                        break;
                    case "2":
                        FindStudents(records);
                        break;
                    default:
                        Console.WriteLine("Selection not valid.");
                        break;
                }
            }
        }

        private static void CreateNewStudentRecord(List<Tuple<int, string, string, DateTime, char>> records)
        {
            //Comment Edd is working on this.
            Console.WriteLine("Please input the new students information using the format:");
            Console.WriteLine("Id no., forename, surname, D.O.B., grade");
            string recordInput = Console.ReadLine();
            var newrecord = ConvertStringToTuple(recordInput);
            Console.WriteLine("Thank you, input succesful");
            Console.ReadKey();
        }

        private static void ReadStudentRecord(List<Tuple<int, string, string, DateTime, char>> records)
        {
            Console.WriteLine("please select which record is required");
            string option = Console.ReadLine();
            int optionint = Convert.ToInt32(option);
            var record = records.First(r => r.Item1 == optionint);
            Console.WriteLine(ConvertTupleToString(record));
        }

        static void FindStudents(List<Tuple<int, string, string, DateTime, char>> records)
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

        static void LoadStudents(List<Tuple<int, string, string, DateTime, char>> records, string fileName)
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
                        var record = ConvertStringToTuple(line);
                        records.Add(record);
                    }

                }
            }
            Console.WriteLine("done");
        }

        #region Find sub-menu actions
        private static void FindByMatch(List<Tuple<int, string, string, DateTime, char>> records)
        {
            throw new NotImplementedException();
        }

        private static void FindById(List<Tuple<int, string, string, DateTime, char>> records)
        {
            Console.WriteLine("Please Enter ID:");
            string option = Console.ReadLine();
            int optionint = Convert.ToInt32(option);
            Console.WriteLine(ConvertTupleToString(records.First(r => r.Item1 == optionint)));
        }

        private static void FindByFirstName(List<Tuple<int, string, string, DateTime, char>> records)
        {
            Console.WriteLine("Please enter first name:");
            string option = Console.ReadLine();
            var results = records.Where(r => r.Item2.Trim().Contains(option));
            foreach (var sr in results)
            {
                Console.WriteLine(sr);
            }


        }

        private static void FindByLastName(List<Tuple<int, string, string, DateTime, char>> records)
        {
            Console.WriteLine("please enter their surname");
            string option = Console.ReadLine();
            var results = records.Where(r => r.Item3.Trim().Contains(option));
            foreach (var sr in results)
            {
                Console.WriteLine(ConvertTupleToString(sr));
            }

        }

        private static void FindByGrade(List<Tuple<int, string, string, DateTime, char>> records)
        {

            Console.WriteLine("please enter which grade is required");
            string grade = Console.ReadLine();
            char gradechar = Convert.ToChar(grade);
            var results = (records.Where(r => r.Item5 == gradechar));
            foreach (var result in results)
            {
                Console.WriteLine(ConvertTupleToString(result));
            }
        }

        private static void FindByDateOfBirth(List<Tuple<int, string, string, DateTime, char>> records)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Helper methods for Tuples
        private static Tuple<int, string, string, DateTime, char> ConvertStringToTuple(string s)
        {
            string[] record = s.Split(',');
            int ID = Convert.ToInt32(record[0]);
            string firstname = Convert.ToString(record[1]);
            string surname = Convert.ToString(record[2]);
            DateTime DOB = Convert.ToDateTime(record[3]);
            char Grade = Convert.ToChar(record[4].Trim());
            return Tuple.Create(ID, firstname, surname, DOB, Grade);
        }

        private static string ConvertTupleToString(Tuple<int, string, string, DateTime, char> t)
        {
            string id = t.Item1.ToString();
            string Fname = t.Item2.ToString();
            string Sname = t.Item3.ToString();
            string DOB = t.Item4.ToShortDateString();
            string Grade = t.Item5.ToString();
            string merged = id + ',' + Fname + ',' + Sname + ',' + DOB + ',' + Grade;
            return merged;
        }
        #endregion
    }
}

