namespace UserApp.Data.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T Find(int Id);

        IQueryable<T> Search(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        void Update(T entity);

        void Update(int Id);

        T Delete(int Id);

        T Delete(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}