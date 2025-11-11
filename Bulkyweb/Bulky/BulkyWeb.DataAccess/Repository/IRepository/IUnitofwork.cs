using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.DataAccess.Repository.IRepository
{
    public interface IUnitofwork
    {
        ICategoryRepository category { get; }
        IProductRepository product { get; }
        void Save();
    }
}
