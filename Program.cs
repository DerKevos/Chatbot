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
                        Console.WriteLine("Ich habe Ihre Anfrage leider nicht verstanden. " +
                                          "Bitte versuchen Sie Ihr Anliegen anders zu formulieren " +
                                          "oder wenden Sie sich an unsere Supporthotline.");
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
                {
                    "Festplatte",
                    "Probleme mit der Festplatte gehen meistens mit dem Speicherplatz einher, daher sollte man darauf achten, ungenutzte Daten zu bereinigen oder auf unseren virtuellen Laufwerken zu speichern."
                },
                {
                    "Internet",
                    "Die meisten internetbedingten Probleme können durch einen Routerneustart gelöst werden. Kappen sie dafür den Router für ca. 1 Minute vom Strom und versuchen Sie es danach erneut."
                },
                {
                    "Passwort",
                    "Um ihr Passwort zurückzusetzten müssen sich sich per E-Mail mit ihrer Mitarbeiter-ID bei unserer Support-Mail gambit-support@outlook.com melden."
                },
                {
                    "Monitor",
                    "Sollte der Monitor kein Bild anzeigen, kann es helfen, die Kabel einmal neu zu verbinden. Sollte dies nicht erfolgreich sein, melden Sie sich bitte telefonisch oder per Mail unter gambit-support@outlook.com"
                },
                {
                    "Bildschirm",
                    "Sollte der Bildschirm kein Bild anzeigen, kann es helfen die Kabel einmal neu zu verbinden. Sollte dies nicht erfolgreich sein, melden Sie sich bitte telefonisch oder per Mail unter gambit-support@outlook.com"
                },
                { "Tastatur", "Bitte versuchen die Peripherie einmal neu anzuschließen." },
                { "Englisch", "Die Anzeigesprache können sie in den Systemeinstellungen ändern." },
                { "Akku", "Einen neuen Akku können sie selbstständig in dem Bestellportal bestellen." },
                {
                    "Azubi",
                    "Um einen neuen Azubi mit Hardware auszustatten, melden Sie sich bitte bei unserem Kollegen. Herr Mustermann Tel. 0123 456 789"
                },
                {
                    "Handy",
                    "Ein neues Firmenhandy, sowie eine Vertragserweiterung oder zusätzliche Hardware können Sie über ihren Vorgesetzten beantragen."
                },
                {
                    "Kaputt",
                    "Sollte Hardware aus Eigenverschuldung beschädigt werden, muss der Ersatz oder die Reparatur über den Vorgesetzten beantragt werden. In anderen Fällen müssen Sie die Hardware zu uns bringen, damit wir die Garantie einlösen können."
                },
                {
                    "Postfach",
                    "Ein neues Postfach können Sie in Outlook unter den Kontoeinstellungen hinzufügen. Sollten Sie dabei Hilfe benötigen melden Sie sich bitte telefonisch oder per Mail unter gambit-support@outlook.com"
                },
                {
                    "wiederherstellen",
                    "Um eine Datei wiederherstellen zu können, müssen Sie uns per Mail den Dateipfad und die gewünschte Wiederherstellungszeit nennen. Die Mailadresse dafür lautet gambit-support@outlook.com"
                },
                {
                    "restore",
                    "Um eine Datei wiederherstellen zu können, müssen Sie uns per Mail den Dateipfad und die gewünschte Wiederherstellungszeit nennen. Die Mailadresse dafür lautet gambit-support@outlook.com"
                },
                { "WLAN", "Das WLAN passwort kann unter folgender Adresse gefunden werden: https://wlan.gambit.de" },
                {
                    "sichern",
                    "Um ihre Daten zu sichern im Falle eines Rechnerwechseln o.Ä. können sie unsere Firmeninterne Software EasySync benutzen. Diese überträgt ihre Daten auf unsere virtuellen Laufwerke."
                },
                {
                    "Headset",
                    "Um ein für Sie passendes Headset auszuwählen, bitten wir Sie sich telefonisch zu melden. Tel. 0123 456 789"
                },
                {
                    "langsam",
                    "In diesem Fall kann es helfen, den Rechner einmal über den Neustart-Button im Menu neuzustarten. Sollten danach weitere Probleme auftreten, melden sie sich bitte per Mail oder telefonisch bei uns."
                },
                {
                    "Virus",
                    "Sollten sie vermuten, sich einen Virus auf ihren Rechner geholt zu haben, müssen Sie schnellstmöglich die Nutzung des Geräts einstellen und es bei uns vor Ort vorbeibringen. Melden Sie sich auch bitte umgehend bei uns damit wir sichergehen können, dass unser Betrieb keine Schäden davonträgt! Tel. 0123 456 789"
                },
                {
                    "fragwürdige",
                    "Sollten Sie auf einen Link in einer fragwürdigen Mail geklickt haben stellen Sie bitte umgehend die Nutzung des Gerätes ein und melden sich bei uns per Telefon! Tel. 0123 456 789."
                },
                {
                    "Software",
                    "Neue Software sollten Sie niemals selber installieren, sondern unser firmeninternes Softwarecenter nutzen. Wenn gewünschte Software nicht vorhanden ist, melden Sie dies bitte bei uns, damit wir das prüfen können."
                },
                {
                    "Excel",
                    "Excel kann wie alle anderen Office-Programme von allen Mitarbeiter genutzt werden. Sollten Sie Schwierigkeiten haben eine Excel-Datei zu öffnen, stellen Sie bitte sicher, dass die Datei noch an der Stelle liegt, an der Sie diese abgespeichert haben."
                },
                {
                    "Word",
                    "Word kann wie alle anderen Office-Programme von allen Mitarbeiter genutzt werden. Sollten Sie Schwierigkeiten haben eine Word-Datei zu öffnen, stellen Sie bitte sicher, dass die Datei noch an der Stelle liegt, an der Sie diese abgespeichert haben."
                },
                {
                    "PowerPoint",
                    "PowerPoint kann wie alle anderen Office-Programme von allen Mitarbeiter genutzt werden. Sollten Sie Schwierigkeiten haben eine PowerPoint-Datei zu öffnen, stellen Sie bitte sicher, dass die Datei noch an der Stelle liegt, an der Sie diese abgespeichert haben."
                },
                {
                    "Office",
                    "Sollte Sie Probleme mit einer Office Anwendung haben (Outlook, Excel, PowerPoint, Word, etc.) führen Sie bitte im Softwarecenter die Office-Reparatur durch."
                },
            };
            return myDict;
        }
    }
}