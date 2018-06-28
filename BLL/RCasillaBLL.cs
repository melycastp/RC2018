using DAL;
using Entities;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class RCasillaBLL
    {
        public RCasilla Create(RCasilla casilla)
        {
            RCasilla Result = null;
            using (var r = new Repositorio<RCasilla>())
            {
                RCasilla rc = r.Retrieve(p => p.idSeccion == casilla.idSeccion && p.tipoEleccion == casilla.tipoEleccion);
                if (rc == null)
                {
                    Result = r.Create(casilla);
                }
                else
                {
                    throw (
                        new Exception("La casilla ya ha sido registrada.")
                    );
                }
            }

            return Result;
        }

        public RCasilla RetrieveByIdRCasilla(string idRCasilla)
        {
            RCasilla Result = null;

            using (var r = new Repositorio<RCasilla>())
            {
                Result = r.Retrieve(p => p.idRegistroCasilla == idRCasilla);
            }

            if(Result != null)
            {
                using (var r = new Repositorio<Seccione>())
                {
                    var seccion = r.Retrieve(p => p.idSeccion == Result.idSeccion);
                    Result.Seccione = seccion;
                }
            }

            return Result;
        }

        public RCasilla VerificarExistente(string idSeccion, string tipo)
        {
            RCasilla Result = null;

            using (var r = new Repositorio<RCasilla>())
            {
                Result = r.Retrieve(p => p.idSeccion == idSeccion && p.tipoEleccion == tipo);
            }

            if(Result != null)
            {
                using (var r = new Repositorio<Seccione>())
                {
                    var seccion = r.Retrieve(p => p.idSeccion == Result.idSeccion);
                    Result.Seccione = seccion;
                }
            }

            return Result;
        }

        public List<RCasilla> RetrieveAll()
        {
            List<RCasilla> Result;

            using (var r = new Repositorio<RCasilla>())
            {
                Result = r.RetrieveAllOrder(p => p.Seccione.seccion);
            }

            return Result;
        }

        public bool Update(RCasilla casilla)
        {
            bool Result = false;
            using (var r = new Repositorio<RCasilla>())
            {
                RCasilla item = r.Retrieve(p => p.idSeccion == casilla.idSeccion && p.tipoEleccion == casilla.tipoEleccion && p.idRegistroCasilla != casilla.idRegistroCasilla);
                if (item == null)
                {
                    Result = r.Update(casilla);
                }
                else
                {
                    throw (
                        new Exception("El registro ya existe.")
                    );
                }
            }
            return Result;
        }

        public bool Delete(string idRCasilla)
        {
            bool Result = false;
            var registro = RetrieveByIdRCasilla(idRCasilla);
            if (registro != null)
            {
                using (var r = new Repositorio<RCasilla>())
                {
                    Result = r.Delete(registro);
                }

            }
            else
            {
                throw (new Exception("El Registro no existe"));
            }

            return Result;
        }
    }
}
