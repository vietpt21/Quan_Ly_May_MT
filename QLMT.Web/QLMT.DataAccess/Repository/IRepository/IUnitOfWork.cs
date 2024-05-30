using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ILineRepository Line { get; }
        IUnitRepository Unit { get; }
        IComputerRepository Computer { get; }
        IScreenRepository Screen { get; }
        void Save();
    }
}
