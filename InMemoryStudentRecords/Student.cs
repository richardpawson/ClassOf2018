using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InMemoryStudentRecords
{
    public class Student
    {
        public Student(int id, string first, string last, DateTime dob)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            DateOfBirth = dob;
            
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public char Grade { get;  set; }
        #region method 
        public string ConvertToString()
        {
            string id = Id.ToString();
            string Fname = FirstName.ToString();
            string Sname = LastName.ToString();
            string DOB = DateOfBirth.ToShortDateString();
            string G = Grade.ToString();
            string merged = id + ',' + Fname + ',' + Sname + ',' + DOB + ',' + Grade;
            return merged;
        }
        #endregion
    }
}
