﻿using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAgenciaEF : IRepositorioAgencia
    {

        private DemoContext Contexto { get; set; }

        public RepositorioAgenciaEF(DemoContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Agencia item)
        {
            Agencia? agenciaTemp = FindByName(item.Nombre);
            if (agenciaTemp == null)
            {
                Contexto.Agencias.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new AgenciaException("Agencia ya existente");
            }
        }

        public void Delete(int id)
        {
            Agencia? agencia = FindById(id) 
                ?? throw new AgenciaException("No se ha encontrado la agencia");
            Contexto.Agencias.Remove(agencia);
            Contexto.SaveChanges();
        }

        public IEnumerable<Agencia> FindAll()
        {
            return Contexto.Agencias;
        }

        public Agencia? FindById(int id)
        {
            return Contexto.Agencias
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }

        public void Update(Agencia item)
        {
            Agencia encontrarAgencia = FindById(item.Id) 
                ?? throw new AgenciaException("No se encontro agencia a actualizar");
            Contexto.Agencias.Update(item);
            Contexto.SaveChanges();
        }

        public Agencia? FindByName(string nombre)
        {
            return Contexto.Agencias
                    .Where(c => c.Nombre == nombre)
                    .SingleOrDefault();
        }
    }
}