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
    public class ScreenRepository : Repository<Screen>, IScreenRepository
    {
        private ApplicationDbContext _db;
        public ScreenRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Screen obj)
        {
            _db.Screens.Update(obj);
        }
    }
}
