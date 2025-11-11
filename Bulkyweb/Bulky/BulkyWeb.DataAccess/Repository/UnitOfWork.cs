using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using BulkyWeb.DataAccess.Repository.IRepository;

namespace BulkyWeb.DataAccess.Repository
{
    public class UnitOfWork : IUnitofwork
    {
        private ApplicationDBContext _Db;
        public ICategoryRepository category { get; private set; }

        public IProductRepository product { get; private set; }

        public UnitOfWork(ApplicationDBContext applicationDB)
        {
            _Db = applicationDB;
            category = new CategoryRepository(_Db);
            product = new ProductRepository(_Db);
        }
        public void Save()
        {
            _Db.SaveChanges();
        }
    }
}
