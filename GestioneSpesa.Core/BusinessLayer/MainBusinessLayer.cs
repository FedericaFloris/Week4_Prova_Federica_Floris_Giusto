using GestioneSpesa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpesa.Core.BusinessLayer
{
    public class MainBusinessLayer : IBussinessLayer
    {
        private readonly IRepositorySpesa spesaRepo;
        
        public Esito AggiungiSpesa(Spesa nuovaSpesa)
        {
            throw new NotImplementedException();
        }

        public Esito CancellaSpesa(int idSpesaCancella)
        {
            throw new NotImplementedException();
        }

        public List<Spesa> GetAllSpesa()
        {
            throw new NotImplementedException();
        }

        public List<Spesa> GetSpesaByApprovato()
        {
            throw new NotImplementedException();
        }

        public List<Spesa> GetSpesaByUtente(string utente)
        {
            throw new NotImplementedException();
        }

        public Esito ModificaApprovatoSpesa(int idSpesaModificare, bool approvatoaAggiornare)
        {
            throw new NotImplementedException();
        }
    }
}
