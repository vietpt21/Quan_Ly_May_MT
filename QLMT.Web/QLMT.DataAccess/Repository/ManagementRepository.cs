using Microsoft.EntityFrameworkCore;
using QLMT.DataAccess.Data;
using QLMT.DataAccess.Repository.IRepository;
using QLMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.DataAccess.Repository
{
    public class ManagementRepository : Repository<Management>, IManagementRepository
    {
        private ApplicationDbContext _db;
        public ManagementRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<Management> GetManagementData()
        {
            var query = @"select * from InforPC";
            var result = _db.Managements.FromSqlRaw(query).ToList();
            return result;

        }

        public void Update(Management obj)
        {
            _db.Managements.Update(obj);
        }

    }
}
