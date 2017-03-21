using NakedObjects;
using System;

namespace Template.Model
{
    public class Student
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title]
        public virtual string FullName { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual Teacher Tutor { get; set; }
    }
}
