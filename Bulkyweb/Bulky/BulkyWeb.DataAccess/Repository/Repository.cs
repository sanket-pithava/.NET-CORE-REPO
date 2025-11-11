
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using BulkyWeb.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _Db;
        internal DbSet<T> DbSet;
        public Repository(ApplicationDBContext Db)
        {
            _Db = Db;
            this.DbSet = _Db.Set<T>();
            //Db.categories = DbSet
            _Db.products.Include(u => u.catogery).Include(u=>u.CategoryId);
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);  
        }

        public T Get(Expression<Func<T, bool>> filter, string? includePropeties = null)
        {
            IQueryable<T> query = DbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includePropeties))
            {
                foreach (var item in includePropeties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePropeties);
                }
            }
            return  query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includePropeties = null)
        {
            IQueryable<T> query = DbSet;
            if(!string.IsNullOrEmpty(includePropeties))
            {
                foreach(var item in includePropeties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePropeties);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
           DbSet.RemoveRange(entity);
        }
    }
}
