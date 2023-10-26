using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class RegisterDTO
    {
        public int DNI { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Genre { get; set; }


        public string Email { get; set; }
        public string Password { get; set; }
    }
}
