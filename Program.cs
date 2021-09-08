using System;
using System.Collections.Generic;

namespace Chatbot
{
    class Program
    {
        static void Main()
        {
            //Es ist ein Nachschlagewerk wo man Key Value Pair hinzufügen und Speicher kann.
            var myDict = new Dictionary<string, string>
            {
                {"Festplatte", "Garantie"},
                {"Internet", "Nicht mein Problem :)"}
            };
            //Erste ausgabe vom Chatbot
            Console.WriteLine("Guten Tag \nWie kann ich ihnen Helfen?");
            //Deklariere einen Stringname
            string benutzereingabe;
            //Wiederholt die Schleife solange keine Eingabe getätigt wird
            do
            {
                //Liest die Eingabe und Speichert sie
                benutzereingabe = Console.ReadLine();
                //Kontrolliert auf Leer
            } while (benutzereingabe == "");

            //Wenn Eingabe NICHT "bye" ist geht der Code weiter
            if (benutzereingabe != "bye")
            {
                //Speichert mehrere Strings mit deren Inhalt
                //Die Strings sind die Benutzereingabe die Aufgespaltet werden 
                string[] wordarray = benutzereingabe.Split(' ');
                //Wiederholt etwas für jedes Wort im Arry
                foreach (string word in wordarray)
                {
                    //für jedes Key Value Paar im Dictionary wiederholt etwas 
                    foreach (var dictEntrie in myDict)
                    {
                        //Gleicht aktuelles Wort mit aktuellem Schlüssel ab 
                        //Wenn der Schlüssel und das Word Identisch sind, passiert etwas
                        if (dictEntrie.Key == word)
                        {
                            //Schreibt den Wert des Schlüssels in die Konsole
                            Console.WriteLine(dictEntrie.Value);
                        }
                    }
                }
            } //end if
        }
    }
}