using ShopApi.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopApiDbContext _context;

        public GenericRepository(ShopApiDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }


        public async Task<T> Get(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }


        public async Task<IReadOnlyList<T>> GetAll()
        {
           return await _context.Set<T>().AsNoTracking().ToListAsync();
        }


        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            
        }



        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }


    }
}
