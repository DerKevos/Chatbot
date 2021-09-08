using System;
using System.Collections.Generic;

namespace Chatbot
{
    class Program
    {
        static void Main()
        {
            var myDict = CreateDictionary();
            //Erste ausgabe vom Chatbot
            Console.WriteLine("Guten Tag");

            //Setzt den wert "wurdeByeEingeben" standardmäßig auf false
            bool wurdeByeEingegeben = false;
            do
            {
                Console.WriteLine("Wie kann ich ihnen Helfen?");
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
                    //Ein Boolean der Standartmäßig false zurück gibt
                    //Zweck ist ob eine Eingabe für den Wert da war
                    bool isAnswerAlraedyGiven;
                    isAnswerAlraedyGiven = GivePrepartAnswerIfPossible(benutzereingabe, myDict);

                    //Wenn noch keine Aussage ausgeben wurde
                    if (!isAnswerAlraedyGiven)
                    {
                        //Gibt eine Standardaussage aus
                        Console.WriteLine("Erro 404");
                    }
                } //end if 
                else
                {
                    //Wenn  werd eingegeben worden ist, ist die Variable true 
                    wurdeByeEingegeben = true;
                }
                //Wenn bye eingegeben worden ist  wird die Schleife unterbrochen und das Programm ist Beendet
            } while (!wurdeByeEingegeben);
        }

        /// <summary>
        /// Versucht eine vorgespeicherte Antwort für die Benutzereingabe herauszugeben 
        /// </summary>
        /// <param name="benutzereingabe"></param>
        /// <param name="myDict">Gefühltes Dictionary mit Schlüsselwörter und Ausgaben</param>
        /// <returns>Wurde eine Aussage gefunden?</returns>
        private static bool GivePrepartAnswerIfPossible(string benutzereingabe, Dictionary<string, string> myDict)
        {
            //Ein Boolean der Standartmäßig false zurück gibt
            //Zweck ist ob eine Eingabe für den Wert da war
            var isAnswerAlraedyGiven = false;
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
                        //Wenn eine passende Aussage getätigt worden ist 
                        //Wird sie auf true gesetzt
                        isAnswerAlraedyGiven = true;
                    }
                }
            }

            return isAnswerAlraedyGiven;
        }

        /// <summary>
        /// Eine vorgefertigte Liste von Key Value Pairs
        /// Key = Schlüsselwort
        /// Value = Botausgabe
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> CreateDictionary()
        {
            //Es ist ein Nachschlagewerk wo man Key Value Pair hinzufügen und Speicher kann.
            var myDict = new Dictionary<string, string>
            {
                {"Festplatte", "Garantie"},
                {"Internet", "Nicht mein Problem :)"},
                {"Monitor", "Schon mal neugestartet"},
            };
            return myDict;
        }
    }
}