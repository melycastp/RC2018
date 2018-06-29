using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EstadoCasillaRepository
    {
        private List<EstadoCasilla> estadoCasillas;

        public EstadoCasillaRepository()
        {
            estadoCasillas = new List<EstadoCasilla>{
                new EstadoCasilla { idEstado = "CR", descripcion = "Conteo Rápido" },
                new EstadoCasilla { idEstado = "T", descripcion = "Teléfonico/Contado" },
                new EstadoCasilla { idEstado = "A", descripcion = "Oficial/Acta"}
            };
        }

        public List<EstadoCasilla> RetrieveAllEstadosCasilla()
        {
            return estadoCasillas;
        }

        public List<EstadoCasilla> RetrieveAllEstadosCasillaCapturista()
        {
            estadoCasillas.RemoveAt(0);
            return estadoCasillas;
        }

        public EstadoCasilla RetrieveByidEstado(string id)
        {
            return estadoCasillas.Find(p => p.idEstado == id);
        }
    }
}
