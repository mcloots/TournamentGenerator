using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentGenerator.Models
{
    public class MatchExcel
    {
        public string Sheet { get; set; }
        public string Participant1 { get; set; }
        public int Cell1Row { get; set; }
        public string Cell1Column { get; set; }
        
        public string Participant2 { get; set; }
        public int Cell2Row { get; set; }
        public string Cell2Column { get; set; }
    }
}
