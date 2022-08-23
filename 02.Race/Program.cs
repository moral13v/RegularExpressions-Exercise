using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();

            string pattern1 = @"[A-Z]|[a-z]";
            string pattern2 = @"[0-9]";

            List<string> participantNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection names = Regex.Matches(input, pattern1);
                MatchCollection distances = Regex.Matches(input, pattern2);

                string name = string.Join("", names);
                int distance = 0;

                foreach (Match item in distances)
                {
                    distance += int.Parse(item.Value);
                }

                if (!participants.ContainsKey(name) && participantNames.Contains(name))
                {
                    participants.Add(name, 0);
                }

                if (participants.ContainsKey(name))
                {
                    participants[name] += distance;
                }

                input = Console.ReadLine();
            }

            participants = participants.OrderByDescending(r => r.Value).ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"1st place: {participants.ElementAt(0).Key}");
            Console.WriteLine($"2nd place: {participants.ElementAt(1).Key}");
            Console.WriteLine($"3rd place: {participants.ElementAt(2).Key}");

        }
    }
}
