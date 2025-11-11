using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using BulkyWeb.DataAccess.Repository;
using BulkyWeb.DataAccess.Repository.IRepository;
using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDBContext _Db;
        public ProductRepository(ApplicationDBContext dBContext) : base(dBContext) 
        {
            _Db = dBContext;
        }
        public void Update(Product obj)
        {
            var objFromDb = _Db.products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Author = obj.Author;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageURL != null)
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }
            }
        }
    }
}
