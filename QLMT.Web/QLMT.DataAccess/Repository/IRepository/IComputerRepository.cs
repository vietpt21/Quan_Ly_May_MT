﻿using QLMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.DataAccess.Repository.IRepository
{
    public interface IComputerRepository : IRepository<Computer>
    {
        void Update(Computer obj);
       
    }
}
