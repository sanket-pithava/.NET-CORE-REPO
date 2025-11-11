using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using BulkyWeb.DataAccess.Repository.IRepository;
using BulkyWeb.Models;

namespace BulkyWeb.DataAccess.Repository
{
    public class CategoryRepository : Repository<Catogery>,ICategoryRepository
    {
        private ApplicationDBContext _Db;
        public CategoryRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _Db = dBContext;
        }

        public void Update(Catogery obj)
        {
            _Db.catogeries.Update(obj);
        }
    }
}
