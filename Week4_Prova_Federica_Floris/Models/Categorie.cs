using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Prova_Federica_Floris.Models
{
    public class Categorie  //volevo metterla al singolare ma non mi prendeva il campo categoria
    {
        public int Id { get; set; }
        public string Categoria { get; set; }

        public ICollection<Spesa> Spese { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Categoria}";
        }
    }
}
