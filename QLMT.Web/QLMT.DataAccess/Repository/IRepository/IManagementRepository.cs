using QLMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.DataAccess.Repository.IRepository
{
    public interface IManagementRepository :IRepository<Management> 
    {
        
        public IEnumerable<Management> GetManagementData();
       
        void Update(Management obj);
       
        /*  Management GetManagementData(Expression<Func<Management, bool>> filter, string? includeProperties = null, bool tracked = true);*/
    }
}
