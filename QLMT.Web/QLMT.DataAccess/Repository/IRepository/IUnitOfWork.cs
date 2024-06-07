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
        ILocationManagementRepository LocationManagement { get; }
        IWareHouseRepository WareHouse { get; }
        IInventoryRepository Inventoty { get; }
        INetworkRangeRepository NetworkRange { get; }
        void Save();
    }
}
