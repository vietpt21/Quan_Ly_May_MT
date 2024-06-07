using QLMT.DataAccess.Data;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.DataAccess.Repository
{
    public class NetworkRangeRepository : Repository<NetworkRange>, INetworkRangeRepository
    {
        private ApplicationDbContext _db;
        public NetworkRangeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(NetworkRange obj)
        {
            _db.NetworkRanges.Update(obj);
        }
    }
}
