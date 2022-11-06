using IronXL;
using IronXL.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TournamentGenerator.Models;

namespace TournamentGenerator.Helper
{
    public static class ExcelHelper
    {
        public static void CreateExcel(Dictionary<string, ListBox> poules)
        {
            WorkBook wb = WorkBook.Create(ExcelFileFormat.XLSX);
            List<string> players = new List<string>();

            foreach (var poule in poules)
            {
                players = new List<string>();
                WorkSheet ws = wb.CreateWorkSheet($"Poule {poule.Key.ToUpper()}");
                ws[$"A1"].Value = "Player";
                int counter = 2;
                foreach (Participant participant in poule.Value.Items)
                {
                    players.Add(participant.ToStringExcel());
                    ws[$"A{counter}"].Value = participant.ToStringExcel();
                    counter++;
                }

                List<MatchExcel> matches = MatchesGenerator.GenerateMatches(players, ws);

                RankingGenerator.GenerateRanking(players, matches, ws);
                
            }

            wb.SaveAs("TMDartsPoules.xlsx");

        }
    }
}
