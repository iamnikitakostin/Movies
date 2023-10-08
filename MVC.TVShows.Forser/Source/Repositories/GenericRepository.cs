﻿using Microsoft.EntityFrameworkCore;
using MVC.TVShows.Forser.Data;

namespace MVC.TVShows.Forser.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TVShowContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(TVShowContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task Create(T entity) => await _context.AddAsync(entity);

        public async Task Delete(int id)
        {
            T existing = await _entities.FindAsync(id);
            _entities.Remove(existing);
        }

        public IEnumerable<T> GetAll() => _entities.ToList();

        public async Task<T> GetById(int id) => await _entities.FindAsync(id);

        public async Task Save() => await _context.SaveChangesAsync();

        public void Update(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}