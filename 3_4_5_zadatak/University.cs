using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_4_5_zadatak
{
    class University
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }

        public University (string ime, Student[] student)
        {
            Name = ime;
            Students = student;
        }
    }
}
