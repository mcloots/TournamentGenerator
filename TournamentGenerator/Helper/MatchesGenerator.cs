using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentGenerator.Models;

namespace TournamentGenerator.Helper
{
    public static class MatchesGenerator
    {
        //public static void GenerateMatches(List<string> players, WorkSheet ws)
        //{
        //    var dictionaryRounds = new Dictionary<int, Dictionary<string, string>>();

        //    //get number of rounds, based on players
        //    int totalRounds = players.Count % 2 == 0 ? players.Count - 1 : players.Count;

        //    for (int i = 1; i <= totalRounds; i++)
        //    {
        //        // now we create the matches
        //        // if even number of players, we need to make sure that everyone plays each round a match
        //        // There can't be double matches
        //        var dictionaryMatchesForRound = new Dictionary<string, string>();

        //        if (players.Count % 2 == 0)
        //        {
        //            //first player
        //            for (int j = 0; j < players.Count; j++)
        //            {
        //                string p1 = players[j];
        //                if (!dictionaryMatchesForRound.Any(d => d.Key == p1 || d.Value == p1))
        //                {
        //                    for (int k = 0; k < players.Count; k++)
        //                    {
        //                        //check if player is not in dictionary already (as key or value)
        //                        if (!dictionaryMatchesForRound.Any(d => d.Key == players[k] || d.Value == players[k]) && p1 != players[k])
        //                        {
        //                            string p2 = players[k];
        //                            var match = new KeyValuePair<string, string>(p1, p2);
        //                            if (!dictionaryMatchesForRound.Contains(match) && 
        //                                !dictionaryRounds.Any(dr=>dr.Value.Any(drv=>(drv.Key == p1 && drv.Value == p2) || 
        //                                (drv.Key == p2 && drv.Value == p1))))
        //                            {
        //                                dictionaryMatchesForRound.Add(match.Key, match.Value);
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //        }

        //        dictionaryRounds.Add(i, dictionaryMatchesForRound);
        //    }

        //    var ii = 1;
        //}

        public static List<MatchExcel> GenerateMatches(List<string> players, WorkSheet ws)
        {
            var matches = new List<Match>();
            var matchesExcel = new List<MatchExcel>();

            //first player
            for (int j = 0; j < players.Count; j++)
            {
                string p1 = players[j];

                for (int k = 0; k < players.Count; k++)
                {
                    string p2 = players[k];

                    //check if player is not in dictionary already (as key or value)
                    if (p1 != p2 && !matches.Any(dm => (dm.Player1 == p1 && dm.Player2 == p2) || (dm.Player1 == p2 && dm.Player2 == p1)))
                    {
                        matches.Add(new Match() { Player1 = p1, Player2 = p2});
                    }
                }
            }

            int rowCounter = 2;
            ws[$"C1"].Value = "Player 1";
            ws[$"D1"].Value = "Player 2";
            ws[$"E1"].Value = "Gew legs P1";
            ws[$"F1"].Value = "Gew legs P2";
            ws[$"G1"].Value = "Punten over P1";
            ws[$"H1"].Value = "Punten over P2";

            // Write this to excel so I can go to bed
            foreach (var m in matches)
            {
                var matchExcel = new MatchExcel()
                {
                    Participant1 = m.Player1,
                    Cell1Column = "C",
                    Cell1Row = rowCounter,
                    Participant2 = m.Player2,
                    Cell2Column = "D",
                    Cell2Row = rowCounter,
                };

                matchesExcel.Add(matchExcel);

                ws[$"C{rowCounter}"].Value = m.Player1;
                ws[$"D{rowCounter}"].Value = m.Player2;

                rowCounter++;
            }

            return matchesExcel;
        }
    }
}
