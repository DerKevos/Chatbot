using System;
using System.Collections.Generic;

namespace Chatbot
{
    class Program
    {
        static void Main()

        { var myDict = new Dictionary<string, string>
            {
                { "Festplatte", "Garantie" },
                { "Internet", "Nicht mein Problem" }
            };
            Console.WriteLine("Guten Tag \nWie kann ich ihnen Helfen?");
            String benutzereingabe;
            do
            {
                benutzereingabe = Console.ReadLine();
            } while (benutzereingabe == "");

            if (benutzereingabe != "bye")
            {string[] wordarray = benutzereingabe.Split(' ');
                foreach (string word in wordarray)
                {
                    foreach (var dictEntrie in myDict)
                    {
                        if (dictEntrie.Key == word)
                        {Console.WriteLine(dictEntrie.Value);
                            
                        }
                        
                    }
                }
            }
        }
    }
}