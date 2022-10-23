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

namespace TournamentGenerator.Helper
{
    public static class ExcelHelper
    {
        public static void CreateExcel(Dictionary<string, ListBox> poules)
        {
            WorkBook wb = WorkBook.Create(ExcelFileFormat.XLSX);

            foreach (var poule in poules)
            {
                WorkSheet ws = wb.CreateWorkSheet(poule.Key);
                ws[$"A1"].Value = "Player";
                int counter = 2;
                foreach (var participant in poule.Value.Items)
                {
                    ws[$"A{counter}"].Value = participant.ToString();
                    counter++;
                }
            }

            wb.SaveAs("TMDartsPoules.xlsx");

        }
    }
}
