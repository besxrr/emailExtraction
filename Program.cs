using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace extractionTWO
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> domains = new Dictionary<string, int>();
            
            string text = File.ReadAllText(@"C:\Training\extractionTask\extractionTask\sample.txt");
            
            const string Pattern =
                @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";

            Regex emailPattern = new Regex(Pattern);
            
            MatchCollection emailMatches = emailPattern.Matches(text);

            foreach (Match emailMatch in emailMatches)
            {
                if (domains.ContainsKey(emailMatch.Groups[4].Value))
                {
                    domains[emailMatch.Groups[4].Value]++;
                }
                else
                {
                    domains.Add(emailMatch.Groups[4].Value, 1); 
                }

                // Console.WriteLine("{0}", emailMatch.Value);
            }

            int top10 = 0;
            foreach (var x in domains.OrderByDescending(key => key.Value))
            {
                Console.WriteLine($"The amount of {x.Key} is {x.Value} ");
                top10 = top10 + 1;
                if (top10 == 10)
                {
                    break;
                }
            }
            {
                Console.WriteLine("Enter in the minimum frequency number you want: ");
                var minfreq = Convert.ToInt32(Console.ReadLine());

                foreach (var y in domains)
                {
                    if (y.Value > minfreq)
                    {
                        Console.WriteLine($"The amount of {y.Key} is {y.Value} ");
                    }
                }
                {
                    
                }    



            }
        }
    };
}