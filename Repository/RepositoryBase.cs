using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
namespace Repository
{
    public class RepositoryBase<T> where T : class
    {
        private readonly CandidateManagementContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(CandidateManagementContext context)
        {
            _context= context;
            _dbSet = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();

        }
        public void Delete(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
        public void Update(T item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
        }
        public T getById(object id)
        {
            return _dbSet.Find(id);
        }
    }
}
