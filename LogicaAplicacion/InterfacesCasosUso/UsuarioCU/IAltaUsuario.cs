using Compartido.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.UsuarioCU
{
    public interface IAltaUsuario
    {
        void Ejecutar (UsuarioDTO usuarioDTO);
    }
}
