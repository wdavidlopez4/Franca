using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Domain
{
    public interface IRepository
    {
        public Task Commit();

        public Task Save<T>(T obj) where T : Entity;

        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity;

        public Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : Entity;

        public Task<List<T>> GetAll<T>() where T : Entity;

        public Task<List<T>> GetAll<T>(string nested) where T : Entity;

        public Task<List<T>> GetAll<T>(string nested, Expression<Func<T, bool>> expression) where T : Entity;

        public void Update<T>(T obj) where T : Entity;

        public Task Save<T>(List<T> obj) where T : Entity;
    }
}
