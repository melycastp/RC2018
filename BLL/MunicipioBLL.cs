using DAL;
using Entities;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class MunicipioBLL
    {
        public Municipio Create(Municipio municipio)
        {
            Municipio Result = null;
            using (var r = new Repositorio<Municipio>())
            {
                Municipio m = r.Retrieve(p => p.nombre == municipio.nombre);
                if (m == null)
                {
                    Result = r.Create(municipio);
                }
                else
                {
                    throw (
                        new Exception("El municipio ya existe.")
                    );
                }
            }

            return Result;
        }

        public Municipio RetrieveByIdMunicipio(int idMunicipio)
        {
            Municipio Result = null;

            using (var r = new Repositorio<Municipio>())
            {
                Result = r.Retrieve(p => p.idMunicipio == idMunicipio);
            }

            return Result;
        }

        public Municipio RetrieveByName(string name)
        {
            Municipio Result = null;

            using (var r = new Repositorio<Municipio>())
            {
                Result = r.Retrieve(p => p.nombre == name);
            }

            return Result;
        }

        public List<Municipio> RetrieveAll()
        {
            List<Municipio> Result;

            using (var r = new Repositorio<Municipio>())
            {
                Result = r.RetrieveAllOrder(p => p.nombre);
            }

            return Result;
        }

        public bool Update(Municipio municipio)
        {
            bool Result = false;
            using (var r = new Repositorio<Municipio>())
            {
                Municipio item = r.Retrieve(p => p.nombre == municipio.nombre && p.idMunicipio != municipio.idMunicipio);
                if (item == null)
                {
                    Result = r.Update(municipio);
                }
                else
                {
                    throw (
                        new Exception("El Municipio ya existe.")
                    );
                }
            }
            return Result;
        }

        public bool Delete(int idMunicipio)
        {
            bool Result = false;
            var municipio = RetrieveByIdMunicipio(idMunicipio);
            if (municipio != null)
            {
                using (var r = new Repositorio<Municipio>())
                {
                    Result = r.Delete(municipio);
                }

            }
            else
            {
                throw (new Exception("El Municipio no existe"));
            }

            return Result;
        }
    }
}
