using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyWeb.Models;

namespace BulkyWeb.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Catogery>
    {
        void Update(Catogery obj);
    }
}
