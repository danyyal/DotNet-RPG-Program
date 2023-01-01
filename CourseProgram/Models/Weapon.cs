using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProgram.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int Damage { get; set; }

        public Character Character { get; set; } 
        public int CharacterId { get; set; }
    }
}
