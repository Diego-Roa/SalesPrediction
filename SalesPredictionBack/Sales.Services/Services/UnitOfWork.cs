using Microsoft.EntityFrameworkCore;
using Sales.Services.Repositories;

namespace Sales.Services.Services
{
    public class UnitOfWork
    {
        private readonly DbContext context;
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public GenericRepository<T> Crud<T>() where T : class
        {
            return new GenericRepository<T>(this.context);
        }


        public DbContext GetContext()
        {
            return context;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

    }
}
