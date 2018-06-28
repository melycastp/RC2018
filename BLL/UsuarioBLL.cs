using DAL;
using Entities;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBLL
    {
        public Usuario Create(Usuario usuario)
        {
            Usuario Result = null;
            using (var r = new Repositorio<Usuario>())
            {
                Usuario u = r.Retrieve(p => p.username == usuario.username);
                if (u == null)
                {
                    Result = r.Create(usuario);
                }
                else
                {
                    throw (
                        new Exception("El usuario ya existe.")
                    );
                }
            }

            return Result;
        }

        public Usuario RetrieveByIdUsuario(string idUsuario)
        {
            Usuario Result = null;

            using (var r = new Repositorio<Usuario>())
            {
                Result = r.Retrieve(p => p.idUsuario == idUsuario);
            }

            return Result;
        }

        public Usuario Authentication(string username, string password)
        {
            Usuario Result = null;

            using (var r = new Repositorio<Usuario>())
            {
                Result = r.Retrieve(p => p.username == username && p.password == password);
            }

            return Result;
        }

        public List<Usuario> RetrieveAll()
        {
            List<Usuario> Result;

            using (var r = new Repositorio<Usuario>())
            {
                Result = r.RetrieveAllOrder(p => p.nombreCompleto);
            }

            return Result;
        }

        public bool Update(Usuario usuario)
        {
            bool Result = false;
            using (var r = new Repositorio<Usuario>())
            {
                Usuario item = r.Retrieve(p => p.username == usuario.username && p.idUsuario != usuario.idUsuario);
                if (item == null)
                {
                    Result = r.Update(usuario);
                }
                else
                {
                    throw (
                        new Exception("El Usuario ya existe.")
                    );
                }
            }
            return Result;
        }

        public bool Delete(string idUsuario)
        {
            bool Result = false;
            var usuario = RetrieveByIdUsuario(idUsuario);
            if (usuario != null)
            {
                using (var r = new Repositorio<Usuario>())
                {
                    Result = r.Delete(usuario);
                }

            }
            else
            {
                throw (new Exception("El Usuario no existe"));
            }

            return Result;
        }
    }
}
