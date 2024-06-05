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
    public class LocationManagementRepository : Repository<LocationManagement>, ILocationManagementRepository
    {
        private ApplicationDbContext _db;
        public LocationManagementRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(LocationManagement obj)
        {
            _db.LocationManagements.Update(obj);
        }
    }
}
