﻿using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);


        //updatein async versiyonu yok
        void Update(T entity);

        void Delete(T entity);

        void RemoveRange(IEnumerable<T> entities);

        



    }
}
