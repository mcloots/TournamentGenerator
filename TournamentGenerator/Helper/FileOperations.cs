using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentGenerator.Models;

namespace TournamentGenerator.Helper
{
    public static class FileOperations
    {
        public static List<Participant> GetParticipants()
        {
            List<Participant> participants = new List<Participant>();
            List<string> data;
            Participant participant;
            try
            {
                using (StreamReader reader = new StreamReader("DB/DB.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        data = reader.ReadLine().Split(';').ToList();
                            participant = new Participant() { FirstName = data[0], LastName = data[1] };
                        if (data.Count > 2)
                        {
                            participant.Seed = int.Parse(data[2]);
                        }
                            if (!participants.Contains(participant))
                            {
                            participants.Add(participant);
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return participants;
        }
    }
}
