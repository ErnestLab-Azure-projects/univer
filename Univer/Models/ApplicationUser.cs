using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Univer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Student> Students { get; set; }
    }
}
