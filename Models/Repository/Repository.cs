using Microsoft.EntityFrameworkCore;
using Online_Ticket_App.Models.IRepository;
using Online_Ticket_App.Utility;
using System.Linq.Expressions;

namespace Online_Ticket_App.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            dbSet = _applicationDbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet?.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }
        public void Update(T entity)
        {
            dbSet?.Update(entity);
        }
    }
}
