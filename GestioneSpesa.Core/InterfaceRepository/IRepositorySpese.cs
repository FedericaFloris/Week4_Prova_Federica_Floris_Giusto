using GestioneSpesa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpesa.Core.InterfaceRepository
{
    public interface IRepositorySpese : IRepository<IRepositorySpese>
    {
        Spesa GetById(int id);
    }
}
