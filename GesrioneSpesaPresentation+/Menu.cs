using GestioneSpesa.Core.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesrioneSpesaPresentation_
{
    public static class Menu
    {
        private static readonly IBussinessLayer bl = new MainBusinessLayer(new RepositoryStudentiEF());

        internal static void Start()
        {
            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1: //Inserisci nuova spesa


                  

                    break;
                case 2:
                    //Approva spesa esistente
                    
                    break;
                case 3:
                    //Cancella spesa esistente
                    

                   
                    break;
                case 4:
                    //Mostra Elenco spese approvate
                    
                    break;
                case 5:

                  
                    break;
                case 6:
                    
                    break;
                default:
                    Console.WriteLine("Scelta Errata, inserisci quella giusta");
                    break;
            }
            return true;
        }
        private static int SchermoMenu()
        {
            Console.WriteLine("1.Inserisci nuova spesa");
            Console.WriteLine("2.Approva spesa esistente");
            Console.WriteLine("3.Cancella spesa esistente");
            Console.WriteLine("4.Mostra Elenco spese approvate");
            Console.WriteLine("5.Mostra Elenco spese di uno specifico utente");
            Console.WriteLine("6.Mostra Elenco spese di una categoria");
            Console.WriteLine("\n0. Exit");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta) /*&& scelta >=0 && scelta <= 1*/))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }

            return scelta;
        }
    }
}
