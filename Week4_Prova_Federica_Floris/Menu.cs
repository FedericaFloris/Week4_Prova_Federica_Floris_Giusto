using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Prova_Federica_Floris
{
    public static class Menu
    {
        public static void Start()
        {
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("1.Inserisci nuova spesa");
            Console.WriteLine("2.Approva spesa esistente");
            Console.WriteLine("3.Cancella spesa esistente");
            Console.WriteLine("4.Mostra Elenco spese approvate");
            Console.WriteLine("5.Mostra Elenco spese di uno specifico utente");
            Console.WriteLine("6.Mostra Elenco spese di una categoria");


            Console.WriteLine("\n 0.Exit");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta. ");
            while (!(int.TryParse(Console.ReadLine(), out scelta)))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta");
            }
            return scelta;
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1: //Inserisci nuova spesa
                        
                   
                    AdoNetDisconnected.AggiungiSpesa();

                    break;
                case 2:
                    //Approva spesa esistente
                    AdoNetConnected.ElencoTutteSpese();
                    AdoNetDisconnected.AggiornaSpesa();
                    break;
                case 3:
                    //Cancella spesa esistente
                    AdoNetConnected.ElencoTutteSpese();

                    AdoNetConnected.DeleteSpesa();
                    break;
                case 4:
                    //Mostra Elenco spese approvate
                    AdoNetConnected.ElencoSpeseApprovate();
                    break;
                case 5:
                    
                    AdoNetConnected.ElencoSpeseUtente();
                    break;
                case 6:
                    AdoNetConnected.TotSpeseXCategoria();
                    break;
                default:
                    Console.WriteLine("Scelta Errata, inserisci quella giusta");
                    break;
            }
            return true;
        }

    
        

    }
}
