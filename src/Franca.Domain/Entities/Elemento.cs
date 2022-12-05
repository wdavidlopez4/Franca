using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Domain.Entities
{
    public class Elemento : Entity
    {
        public string Name { get; private set; }

        public List<TecnicoElemento> Tecnico { get; private set; }


        /// <summary>
        /// for ef
        /// </summary>
        private Elemento() : base()
        {

        }

        private Elemento(string name) : base()
        {
            Validation(name);
            this.Name = name;
        }

        public static Elemento Build(string name)
        {
            return new Elemento(name);
        }

        private static void Validation(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
        }

        public void ChangeMainAttributes(string name)
        {
            Validation(name);
            this.Name = name;
        }
    }
}
