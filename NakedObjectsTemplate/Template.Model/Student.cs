using NakedObjects;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Template.Model
{
    public class Student
    {
        #region Injected Services

        public TeacherRepository TeacherRepository { set; protected get; }

        #endregion


        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title, MaxLength(20)]
        public virtual string FullName { get; set; }

        public virtual DateTime DateOfBirth { get; set; }


        public string ValidateDateOfBirth(DateTime dob)
        {
            var rb = new ReasonBuilder();
            rb.AppendOnCondition(dob.Year <1998 || dob.Year > 2013, "Year must be between 1998 & 2013");
            return rb.Reason;
        }



        public virtual int TutorID { get; set; }


        public virtual Teacher Tutor { get; set; }


        [PageSize(10)]
        public IQueryable<Teacher> AutoCompleteTutor([MinLength(2)] string matching)
        {
            return TeacherRepository.FindTeacherByName(matching);
        }

    }
}
