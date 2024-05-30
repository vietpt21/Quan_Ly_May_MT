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
    public class ComputerRepository : Repository<Computer>, IComputerRepository
    {
        private ApplicationDbContext _db;
        public ComputerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Computer obj)
        {
            _db.Computers.Update(obj);
        }
    }
}
