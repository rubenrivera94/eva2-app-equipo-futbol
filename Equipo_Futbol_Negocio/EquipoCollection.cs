using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Futbol_Negocio
{
    public class EquipoCollection
    {
        // Método para leer todos los equipos desde la vista 'vw_Equipos'
        public List<Equipo> ReadAll()
        {
            var equipos = CommonBC.ModeloEquipo.vw_Equipos; // Acceso a la vista
            return ObtenerEquipos(equipos.ToList()); // Convierte a una lista de 'Equipo'
        }

        // Método privado para transformar datos de la vista en objetos 'Equipo'
        private List<Equipo> ObtenerEquipos(List<Equipo_futbol_Data.vw_Equipos> equiposData)
        {
            List<Equipo> equipoList = new List<Equipo>();

            // Itera sobre cada registro de la vista
            foreach (Equipo_futbol_Data.vw_Equipos equipo in equiposData)
            {
                Equipo e = new Equipo
                {
                    EquipoId = equipo.EquipoId,
                    NombreEquipo = equipo.NombreEquipo,
                    CantidadJugadores = equipo.CantidadJugadores,
                    NombreDt = equipo.NombreDt,
                    TipoEquipo = equipo.TipoEquipo,
                    CapitanEquipo = equipo.CapitanEquipo,
                    TieneSub21 = equipo.TieneSub21
                };

                // Agrega el equipo a la lista
                equipoList.Add(e);
            }
            return equipoList;
        }
    }
}
