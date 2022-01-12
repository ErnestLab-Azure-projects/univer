using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Univer.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int StudentAge { get; set; }
        public double StudentRate { get; set; }
        public int FacultyId { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }

        public Faculty Faculty { get; set; }
        public Group Group { get; set; }
        public ApplicationUser User { get; set; }
    }
}
