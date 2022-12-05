using Franca.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Infrastructure.Persistences
{
    public class Repository : IRepository
    {
        private readonly FrancaContext context;

        public Repository(FrancaContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            return context
                .Set<T>()
                .Where(x => x.IsDeleted == false)
                .Any(expression);
        }

        public async Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            return await context
                .Set<T>()
                .Where(x => x.IsDeleted == false)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAll<T>() where T : Entity
        {
            return await context
                .Set<T>()
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<List<T>> GetAll<T>(string nested) where T : Entity
        {
            return await context
                .Set<T>()
                .Where(x => x.IsDeleted == false)
                .Include(nested)
                .ToListAsync();
        }

        public async Task<List<T>> GetAll<T>(string nested, Expression<Func<T, bool>> expression) where T : Entity
        {
            return await context
                .Set<T>()
                .Where(expression)
                .Where(x => x.IsDeleted == false)
                .Include(nested)
                .ToListAsync();
        }

        public async Task Save<T>(T obj) where T : Entity
        {
            await this.context.AddAsync<T>(obj);
        }

        public async Task Save<T>(List<T> obj) where T : Entity
        {
            await context.Set<T>().AddRangeAsync(obj);
        }

        public void Update<T>(T obj) where T : Entity
        {
            try
            {
                context.Update<T>(obj);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}
