using System;

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
        public char Grade { get; set; }

        public string ConvertToString()
        {
            return Id.ToString() + ", " + FirstName + ", " + LastName + ", " + DateOfBirth.ToString("d") + ", " + Grade;
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

    }
}
