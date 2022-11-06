using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentGenerator.Models
{
    public class Participant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Seed { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {(Seed > 0 ? $"({Seed})" : "")}";
        } 
        
        public string ToStringExcel()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
