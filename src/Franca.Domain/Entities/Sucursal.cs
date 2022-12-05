using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Domain.Entities
{
    public class Sucursal : Entity
    {
        public string Name { get; private set; }

        public List<Tecnico> Tecnicos { get; private set; }


        /// <summary>
        /// for ef
        /// </summary>
        private Sucursal() : base()
        {

        }

        private Sucursal(string name) : base()
        {
            Validation(name);
            this.Name = name;
        }

        public static Sucursal Build(string name)
        {
            return new Sucursal(name);
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
