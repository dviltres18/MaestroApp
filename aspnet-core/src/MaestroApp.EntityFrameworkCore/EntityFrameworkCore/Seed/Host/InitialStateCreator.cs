using MaestroApp.Maestro.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaestroApp.EntityFrameworkCore.Seed.Host
{
    public class InitialStateCreator
    {
        private readonly MaestroAppDbContext _context;

        public InitialStateCreator(MaestroAppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var estadoInicio = _context.Estados.FirstOrDefault(
                     e => e.Nombre == "Inicio");
            if (estadoInicio == null)
            {
                _context.Estados.Add(new Estado { Nombre = "Inicio" });
            }

            var estadoEnCamino = _context.Estados.FirstOrDefault(
                    e => e.Nombre == "En Camino");
            if (estadoEnCamino == null)
            {
                _context.Estados.Add(new Estado { Nombre = "En Camino" });
            }

            var estadoFin = _context.Estados.FirstOrDefault(
                    e => e.Nombre == "Fin");
            if (estadoFin == null)
            {
                _context.Estados.Add(new Estado { Nombre = "Fin" });
            }          

            var estadoDisponible = _context.Estados.FirstOrDefault(
                   e => e.Nombre == "Disponible");
            if (estadoDisponible == null)
            {
                _context.Estados.Add(new Estado { Nombre = "Disponible" });
            }

            var estadoCargado = _context.Estados.FirstOrDefault(
                    e => e.Nombre == "Cargado");
            if (estadoCargado == null)
            {
                _context.Estados.Add(new Estado { Nombre = "Cargado" });
            }

            var estadoViajando = _context.Estados.FirstOrDefault(
                   e => e.Nombre == "Viajando");
            if (estadoViajando == null)
            {
                _context.Estados.Add(new Estado { Nombre = "Viajando" });
            }
        }
    }
}
