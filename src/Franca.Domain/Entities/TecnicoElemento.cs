using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Domain.Entities
{
    public class TecnicoElemento : Entity
    {
        public Tecnico Tecnico { get; private set; }

        public Elemento Elemento { get; private set; }

        public Guid TecnicoId { get; private set; }

        public Guid ElementoId { get; private set; }

        private TecnicoElemento():base()
        {

        }

        private TecnicoElemento(Guid tecnicoId, Guid elementoId): base()
        {
            this.TecnicoId = tecnicoId;
            this.ElementoId = elementoId;
        }

        public static TecnicoElemento Bulid(Guid tecnicoId, Guid elementoId)
        {
            return new TecnicoElemento(tecnicoId, elementoId);
        }
    }
}
