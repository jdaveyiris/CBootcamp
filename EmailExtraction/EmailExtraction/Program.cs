using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace EmailExtraction
{
    class Program
    {
        static void Main()
        {
            /*
             try
            {          
                using (var sr = new StreamReader(@"C:\Users\Jim.Davey\Work\CBootcamp\CBootcamp\EmailExtraction\textsample.txt"))
                {                
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            */

            Dictionary<string, int> emailCounter = new Dictionary<string, int>();
            // need to add each individual email address as keys
            // need to assign the count value for each address as the values

            // if statement to check if @softwire.com exists add to count , if not create new entry 

            string path = @"C:\Users\Jim.Davey\Work\CBootcamp\CBootcamp\EmailExtraction\textsample.txt";

            string text = File.ReadAllText(path);

            
            //Regex rx = new Regex(@"[a-zA-Z\w\d\S.'_%+-]+@[a-zA-Z\w\d\S.'_%+-]+");
            Regex rx = new Regex(@"@[\w.'%+-]+\b");
            //[\w.'%+-]+@[\w.'%+-]+
            //[\w.'%+-]+@softwire.com\b
            MatchCollection matches = rx.Matches(text);

            Console.WriteLine("{0} matches found", matches.Count);
            Console.WriteLine(matches.ToString());
            Console.ReadLine();
            

            
            foreach(Match match in matches)
            {
                if (emailCounter.ContainsKey(match.Value))
                {
                    emailCounter[match.Value] = emailCounter[match.Value]+1;
                }
                else
                {
                    emailCounter.Add(match.Value, 1);
                }
            }

            Console.WriteLine(emailCounter["@corndel.com"]);
            
            /*
            int matchCount = 0;
            for (int i = 0; i <= text.Length -13; i++)
            {
                if (text.Substring(i, 13) == "@softwire.com")
                {
                    matchCount++;
                }
            }
            Console.WriteLine(matchCount);
            Console.ReadLine();
          */




        }       
        
    }
}
