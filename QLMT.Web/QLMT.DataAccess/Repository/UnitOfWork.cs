using QLMT.DataAccess.Data;
using QLMT.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Line = new LineRepository(_db);
            Unit = new UnitRepository(_db);
            Computer = new ComputerRepository(_db);
            Screen = new ScreenRepository(_db);
        }
        public ILineRepository Line { get; private set; }
        public IUnitRepository Unit { get; private set; }
        public IComputerRepository Computer { get; private set; }
        public IScreenRepository Screen { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
