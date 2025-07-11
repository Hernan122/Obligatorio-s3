﻿using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.EntidadesNegocio
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Agencia : IEquatable<Agencia>
    {
        public int Id { get; set; }
        public int UbPos { get; set; }
        public UbicacionAgencia Ubicacion { get; set; }
        public string Nombre { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        private Agencia() { }

        public Agencia (int ubPos, int ubicacionLatitud, int ubicacionLongitud, string nombre, int usuarioId)
        {
            UbPos = ubPos;
            Ubicacion = new UbicacionAgencia(ubicacionLatitud, ubicacionLongitud);
            Nombre = nombre;
            UsuarioId = usuarioId;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new AgenciaException("Nombre invalido");
            }
        }

        public bool Equals(Agencia? other)
        {
            return Id == other.Id || Nombre == other.Nombre;
        }
    }
}