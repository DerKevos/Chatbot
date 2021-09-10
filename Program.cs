using System;
using System.Collections.Generic;

namespace Chatbot
{
    class Program
    {
        static void Main()
        {
            var myDict = CreateDictionary();
            //Erste Ausgabe vom Chatbot
            Console.WriteLine("Guten Tag");

            //Setzt den Wert "wurdeByeEingeben" standardmäßig auf false
            bool wurdeByeEingegeben = false;
            do
            {
                Console.WriteLine("Wie kann ich Ihnen helfen?");
                //Deklariere einen String
                string benutzereingabe;
                //Wiederholt die Schleife, solange keine Eingabe getätigt wird
                do
                {
                    //Liest die Eingabe und speichert diese
                    benutzereingabe = Console.ReadLine();
                    //Kontrolliert auf Inhalt
                } while (benutzereingabe == "");

                //Wenn Eingabe NICHT "bye" ist, geht der Code weiter
                if (benutzereingabe != "bye")
                {
                    //Ein Boolean, der standardmäßig false zurück gibt
                    //Zweck ist, ob eine Eingabe für den Wert da war
                    bool isAnswerAlraedyGiven;
                    isAnswerAlraedyGiven = GivePreparedAnswerIfPossible(benutzereingabe, myDict);

                    //Wenn noch keine Aussage ausgeben wurde
                    if (!isAnswerAlraedyGiven)
                    {
                        //Gibt eine Standardausgabe aus
                        Console.WriteLine("Erro 404");
                    }
                } //end if 
                else
                {
                    //Wenn "Bye" eingegeben worden ist, ist die Variable true 
                    wurdeByeEingegeben = true;
                }
                //Wenn "Bye" eingegeben worden ist,  wird die Schleife unterbrochen und das Programm ist beendet
            } while (!wurdeByeEingegeben);
        }

        /// <summary>
        /// Versucht eine vorgespeicherte Antwort für die Benutzereingabe herauszugeben 
        /// </summary>
        /// <param name="benutzereingabe"></param>
        /// <param name="myDict">gefülltes Dictionary mit Schlüsselwörtern und Ausgaben</param>
        /// <returns>Wurde eine Aussgabe gefunden?</returns>
        private static bool GivePreparedAnswerIfPossible(string benutzereingabe, Dictionary<string, string> myDict)
        {
            //Ein Boolean, der Standartmäßig false zurück gibt
            //um zu überprüfen, ob eine Eingabe für den Wert da war
            var isAnswerAlraedyGiven = false;
            //Speichert mehrere Strings mit deren Inhalt
            //Die Strings sind die Benutzereingabe, die aufgespaltet werden 
            string[] wordarray = benutzereingabe.Split(' ');
            //Wiederholt etwas für jedes Wort im Array
            foreach (string word in wordarray)
            {
                //für jedes Key Value Paar im Dictionary wiederholt etwas 
                foreach (var dictEntrie in myDict)
                {
                    //Gleicht aktuelles Wort mit aktuellem Schlüssel ab 
                    //Wenn der Schlüssel und das Word identisch sind, passiert etwas
                    //Das ToUpper hilft bei unterschiedlicher Groß- und Kleinschreibung
                    if (dictEntrie.Key.ToUpper() == word.ToUpper())
                    {
                        //Schreibt den Wert des Schlüssels in die Konsole
                        Console.WriteLine(dictEntrie.Value);
                        //wird auf true gesetzt, weil eine passende Ausgabe getätigt wurde
                        isAnswerAlraedyGiven = true;
                    }
                }
            }

            return isAnswerAlraedyGiven;
        }

        /// <summary>
        /// Eine vorgefertigte Liste von Key-Value-Pairs
        /// Key = Schlüsselwort
        /// Value = Botausgabe
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> CreateDictionary()
        {
            //Es ist ein Nachschlagewerk wo man Key-Value-Pair hinzufügen und speichern kann.
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