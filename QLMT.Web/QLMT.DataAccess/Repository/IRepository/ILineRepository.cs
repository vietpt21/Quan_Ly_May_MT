using QLMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.DataAccess.Repository.IRepository
{
    public interface ILineRepository : IRepository<Line>
    {
        void Update(Line obj);
    }
}
