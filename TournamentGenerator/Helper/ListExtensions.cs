using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentGenerator.Models;

namespace TournamentGenerator.Helper
{
    public static class ListExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public static class SeedHelper
    {
        public static List<Participant> SeedOrderList(List<Participant> pList)
        {
            //Get seeded players and order them
            var seededPlayers = pList.Where(p => p.Seed > 0).OrderBy(p => p.Seed).ToList();
            //Remove seeded players from original list
            pList.RemoveAll(p => p.Seed > 0);
            pList.InsertRange(0, seededPlayers);
            return pList;
        }
    }
}
