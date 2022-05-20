using GestioneSpesa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpesa.Core.BusinessLayer
{
    public interface IBussinessLayer
    {
        Esito AggiungiSpesa(Spesa nuovaSpesa);

        Esito ModificaApprovatoSpesa(int idSpesaModificare, bool approvatoaAggiornare);

        Esito CancellaSpesa(int idSpesaCancella);

        List<Spesa> GetAllSpesa();
        List<Spesa> GetSpesaByApprovato();
        List<Spesa> GetSpesaByUtente(string utente);

    }
}
