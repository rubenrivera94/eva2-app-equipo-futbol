using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Futbol_Negocio
{
    public class Equipo : IPersistente
    {
        // Propiedades
        public int EquipoId { get; set; }
        public string NombreEquipo { get; set; } = string.Empty;
        public int CantidadJugadores { get; set; }
        public string NombreDt { get; set; } = string.Empty;
        public string TipoEquipo { get; set; } = string.Empty;
        public string CapitanEquipo { get; set; } = string.Empty;
        public bool TieneSub21 { get; set; } = false;

        
        public bool Create()
        {
            try
            {
                CommonBC.ModeloEquipo.spEquipoSave(
                        this.NombreEquipo,
                        this.CantidadJugadores,
                        this.NombreDt,
                        this.TipoEquipo,
                        this.CapitanEquipo,
                        this.TieneSub21
                    );
                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Read(int equipoId)
        {
           try
            {
                Equipo_futbol_Data.vw_Equipos equipo = CommonBC.ModeloEquipo.vw_Equipos.First(e => e.EquipoId == equipoId);
                // Asignamos los valores obtenidos del equipo a las propiedades de la clase
                this.EquipoId = equipo.EquipoId;
                this.NombreEquipo = equipo.NombreEquipo;
                this.CantidadJugadores = equipo.CantidadJugadores;
                this.NombreDt = equipo.NombreDt;
                this.TipoEquipo = equipo.TipoEquipo;
                this.CapitanEquipo = equipo.CapitanEquipo;
                this.TieneSub21 = equipo.TieneSub21;

                return true;

            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                // Llamamos al procedimiento almacenado para actualizar el equipo
                CommonBC.ModeloEquipo.spEquipoUpdateById(
                    this.EquipoId,         // ID del equipo a actualizar
                    this.NombreEquipo,     // Nombre del equipo
                    this.CantidadJugadores, // Cantidad de jugadores
                    this.NombreDt,         // Nombre del director técnico (DT)
                    this.TipoEquipo,       // Tipo de equipo (Masculino o Femenino)
                    this.CapitanEquipo,    // Capitán del equipo
                    this.TieneSub21        // Indica si tiene jugadores Sub-21
                );

                // Guardamos los cambios en el contexto
                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Puedes agregar más lógica de manejo de errores si es necesario
                return false;
            }
        }

        public bool Delete(int equipoId)
        {
            try
            {
                // Llama al procedimiento almacenado para eliminar el equipo por su ID
                CommonBC.ModeloEquipo.spEquipoDeleteById(equipoId);
                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return false;
            }
        }

    }

}
