using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MaestroApp.Maestro.Travel.Dto
{
    public class CargaViajeInput
    {
        public int Id { get; set; }        

        public Collection<AddContenedorInput> ContenedoresSelec { get; set; }

        public Collection<AddContenedorInput> ContenedoresDisponibles { get; set; }
    }
}
