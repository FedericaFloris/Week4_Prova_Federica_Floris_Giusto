using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Prova_Federica_Floris.Models
{
    public class Spesa
    {
        public int Id { get; set; }
        public DateTime DataSpesa { get; set; }
        public string Descrizione { get; set; }
        public string Utente { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; } = false;

        //FK
        public int CategoriaId { get; set; }
        //Navigation property
        public Categorie Categorie { get; set; }


        public override string ToString()
        {
            return $"{Id} - {DataSpesa} - {CategoriaId} - {Descrizione} - {Utente} - {Importo} - {Approvato}";
        }
    }
}
