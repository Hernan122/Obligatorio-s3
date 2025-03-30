using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;


namespace LogicaNegocio.EntidadesNegocio
{
    internal class Usuario


    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public Rol Rol { get; set; }

        public Usuario(int id, string nombreUsuario, string email, string contrasenia, Rol rol) { }
    }
}
