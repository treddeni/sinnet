using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinnet
{
    class Parser
    {
        public static List<Match> Parse(string filePath)
        {
            var reader = new StreamReader(File.OpenRead(filePath));

            List<Match> matches = new List<Match>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                string date = values[0];
                string players = values[1];
                string score = values[2];

                if (score.Contains("Ret") || score.Contains("Def") || score.Contains("Wd") || score.Contains("Wo") || score.Contains("inj"))
                {
                    continue;
                }

                //parse players
                string[] separator = { "d." };
                var playersNames = players.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                string winner = playersNames[0].Trim();
                string loser = playersNames[1].Trim();

                if (winner.StartsWith("("))
                {
                    string[] sep = { ") " };
                    var name = winner.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    winner = name[1];
                }

                if (loser.StartsWith("("))
                {
                    string[] sep = { ") " };
                    var name = loser.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    loser = name[1];
                }

                //parse score
                string[] separators = { "-", ";" };
                var scores = score.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (scores.Length < 2)
                {
                    continue;
                }

                matches.Add(new Match(winner, loser, scores));
            }

            return matches;
        }

        public static List<string> ParseApplicants(string filePath)
        {
            var reader = new StreamReader(File.OpenRead(filePath));
            List<string> applicants = new List<string>();
            string applicant;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (!line.Contains("back to top"))
                {
                    string[] names = line.Trim().Substring(1, line.Length - 2).Split(',');
                    applicant = names[1].Trim() + " " + names[0].Trim();
                    applicants.Add(applicant);
                }
            }

            return applicants;
        }
    }
}
