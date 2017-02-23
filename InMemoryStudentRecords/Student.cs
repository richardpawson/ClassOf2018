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

        #region Properties
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private DateTime DateOfBirth { get;  set; }
        public char Grade { get; set; }
        #endregion

        public string ConvertToString()
        {
            return Id.ToString() + ", " + FirstName + ", " + LastName + ", " + DateOfBirth.ToString("d") + ", " + Grade;
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

        public bool IsOverAged(int requiredAge) {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age >= requiredAge;
        }

        public bool ConfirmDateOfBirthIs(DateTime claimedDoB) {
            return claimedDoB == DateOfBirth;
        }

        public bool IsBirthdayToday() {
            return DateTime.Today.Day == DateOfBirth.Day && DateTime.Today.Month == DateOfBirth.Month;
        }


    }
}
