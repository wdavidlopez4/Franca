using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Domain.Entities
{
    public class Tecnico : Entity
    {
        public string Name { get; private set; }

        public double Salary { get; private set; }

        public Sucursal Sucursal { get; private set; }

        public Guid SucursalId { get; private set; }

        public int ElementosCount { get; private set; }

        public List<TecnicoElemento> Elementos { get; private set; }


        /// <summary>
        /// for ef
        /// </summary>
        private Tecnico(): base()
        {

        }

        private Tecnico(string name, double salary, Guid sucursalId) :base()
        {
            Validation(name);

            this.Name = name;
            this.Salary = salary;
            this.SucursalId = sucursalId;
            this.ElementosCount = 0;
        }

        public static Tecnico Build(string name, double salary, Guid sucursalId)
        {
            return new Tecnico(name, salary, sucursalId);
        }

        private static void Validation(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
        }

        public void ChangeMainAttributes(string name, double salary)
        {
            Validation(name);

            this.Name = name;
            this.Salary = salary;
        }

        public void AddElementosCount(int count)
        {
            this.ElementosCount += count;
        }
    }
}
