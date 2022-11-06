using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentGenerator.Models;

namespace TournamentGenerator.Helper
{
    public static class RankingGenerator
    {
        public static void GenerateRanking(List<string> players, List<MatchExcel> matches, WorkSheet ws)
        {
            ws[$"J1"].Value = "Rangschikking";
            ws[$"K1"].Value = "Player";
            ws[$"L1"].Value = "Gew legs";
            ws[$"M1"].Value = "Punten over";

            int rowCounter = 2;

            // Write players and formulas to rank in excel
            foreach (var p in players)
            {
                ws[$"K{rowCounter}"].Value = p;

                //Calculate the formula for summing up all the won legs
                string formulaLegs = "SUM(";
                List<string> cellsLegs = new List<string>();
                List<string> cellsPoints = new List<string>();
                foreach (var me in matches.Where(m => m.Participant1 == p || m.Participant2 == p))
                {
                    //get cell with won legs (= column + 2)
                    if (me.Participant1 == p)
                    {
                        cellsLegs.Add($"{ColumnMap.Columns.First(c => c.Key == (ColumnMap.Columns.First(c => c.Value == me.Cell1Column).Key + 2)).Value}{me.Cell1Row}");
                        cellsPoints.Add($"{ColumnMap.Columns.First(c => c.Key == (ColumnMap.Columns.First(c => c.Value == me.Cell1Column).Key + 4)).Value}{me.Cell1Row}");
                    }
                    else if (me.Participant2 == p)
                    {
                        cellsLegs.Add($"{ColumnMap.Columns.First(c => c.Key == (ColumnMap.Columns.First(c => c.Value == me.Cell2Column).Key + 2)).Value}{me.Cell2Row}");
                        cellsPoints.Add($"{ColumnMap.Columns.First(c => c.Key == (ColumnMap.Columns.First(c => c.Value == me.Cell2Column).Key + 4)).Value}{me.Cell2Row}");
                    }

                }
                formulaLegs += string.Join('+', cellsLegs);
                formulaLegs += ")";

                ws[$"L{rowCounter}"].Formula = formulaLegs;

                //Calculate the formula for summing up all the leftover points
                string formulaPoints = "SUM(";

                formulaPoints += string.Join('+', cellsPoints);
                formulaPoints += ")";

                ws[$"M{rowCounter}"].Formula = formulaPoints;

                rowCounter++;
            }
        }
    }
}
