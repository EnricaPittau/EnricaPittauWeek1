using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnricaPittauWeek1.Entities;

namespace EnricaPittauWeek1.Interfaces
{
    public interface IRepositoryTecnologici : IRepository<Tecnologici>
    {
        Tecnologici GetByMarca(string marca);
    }
}
