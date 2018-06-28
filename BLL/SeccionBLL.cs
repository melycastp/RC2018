using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class SeccionBLL
    {
        public Seccione Create(Seccione seccion)
        {
            Seccione Result = null;
            using (var r = new Repositorio<Seccione>())
            {
                Seccione s = r.Retrieve(p => p.seccion == seccion.seccion && p.casilla == seccion.casilla);
                if (s == null)
                {
                    Result = r.Create(seccion);
                }
                else
                {
                    throw (
                        new Exception("La sección ya existe.")
                    );
                }
            }

            return Result;
        }

        public Seccione RetrieveByIdSeccion(string idSeccion)
        {
            Seccione Result = null;

            using (var r = new Repositorio<Seccione>())
            {
                Result = r.Retrieve(p => p.idSeccion == idSeccion);
            }

            return Result;
        }

        public Seccione RetrieveBySeccionCasilla(int seccion, string casilla)
        {
            Seccione Result;

            using (var r = new Repositorio<Seccione>())
            {
                Result = r.Retrieve(p => p.seccion == seccion && p.casilla == casilla);
            }

            return Result;
        }

        public int RetrieveListaNominalById(string idSeccion)
        {
            int Result = 0;

            try
            {
                using (var r = new Repositorio<Seccione>())
                {
                    Result = r.Retrieve(p => p.idSeccion == idSeccion).listaNominal;
                }
            }
            catch
            {
                Result = 0;
            }

            return Result;
        }

        public List<Seccione> RetrieveBySeccion(int seccion)
        {
            List<Seccione> Result;

            using (var r = new Repositorio<Seccione>())
            {
                Result = r.FilterOrder(p => p.seccion == seccion, p => p.casilla);
            }

            return Result;
        }

        public List<int> RetrieveSeccions()
        {
            List<int> Result;

            using (var r = new Repositorio<Seccione>())
            {
                Result = r.RetrieveAllOrder(p => p.seccion).Select(p => p.seccion).Distinct().ToList();
            }

            return Result;
        }

        public List<Seccione> RetrieveAll()
        {
            List<Seccione> Result;

            using (var r = new Repositorio<Seccione>())
            {
                Result = r.RetrieveAllOrder(p => p.seccion);
            }

            return Result;
        }

        public bool Update(Seccione seccione)
        {
            bool Result = false;
            using (var r = new Repositorio<Seccione>())
            {
                Seccione item = r.Retrieve(p => p.seccion == seccione.seccion && p.casilla == seccione.casilla && p.idSeccion != seccione.idSeccion);
                if (item == null)
                {
                    Result = r.Update(seccione);
                }
                else
                {
                    throw (
                        new Exception("La Sección ya existe.")
                    );
                }
            }
            return Result;
        }

        public bool Delete(string idSeccion)
        {
            bool Result = false;
            var seccion = RetrieveByIdSeccion(idSeccion);
            if (seccion != null)
            {
                using (var r = new Repositorio<Seccione>())
                {
                    Result = r.Delete(seccion);
                }

            }
            else
            {
                throw (new Exception("La sección no existe"));
            }

            return Result;
        }
    }
}
