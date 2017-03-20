using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Model
{
    public class Teacher
    {

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title]
        public virtual string FullName { get; set; }

        public virtual string Department { get; set; }

    }
}
