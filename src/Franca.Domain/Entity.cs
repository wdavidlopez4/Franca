using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public bool IsDeleted { get; protected set; }

        protected Entity()
        {
            this.Id = Guid.NewGuid();
            this.IsDeleted = false;
        }

        public void Remove()
        {
            this.IsDeleted = true;
        }
    }
}
