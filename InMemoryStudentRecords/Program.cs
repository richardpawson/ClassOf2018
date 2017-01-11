using System;
using System.Collections.Generic;
using System.IO;

namespace InMemoryStudentRecords
{
    class Program
    {
        static void Main()
        {
            List<string> records = new List<string>(); 
            string menuOption = "";
            while (menuOption != "0")
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Create new student record");
                Console.WriteLine("2. Read student record");
                Console.WriteLine("3. Update student record");
                Console.WriteLine("4. Delete student record");
                Console.WriteLine("5. List All Students");
                Console.WriteLine("6. Load Data File");
                Console.WriteLine("7. Back-up Data File");
                Console.WriteLine("8. Write Data File");
                Console.WriteLine("0. Quit");
                Console.WriteLine("Enter selection:");
                menuOption = Console.ReadLine();
                switch(menuOption)
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
                        ListAllStudents(records);
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

        private static void CreateNewStudentRecord(List<string> records)
        {
            throw new NotImplementedException();
        }

        private static void ReadStudentRecord(List<string> records)
        {
            throw new NotImplementedException();
        }

        private static void UpdateStudentRecord(List<string> records)
        {
            throw new NotImplementedException();
        }

        private static void DeleteStudentRecord(List<string> records)
        {
            throw new NotImplementedException();
        }

        static void ListAllStudents(List<string> records)
        {
            throw new NotImplementedException();
        }

        static void LoadDataFile(List<string> records) {
            throw new NotImplementedException();
        }

        static void WriteDataFile(List<string> records)
        {
            throw new NotImplementedException();
        }
    }
}
