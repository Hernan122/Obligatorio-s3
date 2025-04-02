using Compartido.DTOs;
using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class AltaUsuario: IAltaUsuario
    {

        private IRepositorioUsuario RepoUsuario { get; set; }
            

        public AltaUsuario(IRepositorioUsuario RepoUsuario) 
        { 
            RepoUsuario = RepoUsuario;
        }
        public void Ejecutar(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Usuario usuario = UsuarioMapper.UsuarioFromUsuarioDTO(usuarioDTO);
            RepoUsuario.Add (usuario);
        }
    }
}
