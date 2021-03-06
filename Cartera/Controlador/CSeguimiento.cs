﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CSeguimiento
    {
        MSeguimiento seguimiento = new MSeguimiento();
        public DataTable CargarSeguimiento(string idproducto)
        {
            return seguimiento.CargarSeguimiento(idproducto);
        }

        public int GuardarSeguimiento(string comentario, string fecha, string idproducto)
        {
            return seguimiento.GuardarSeguimiento(comentario, fecha, idproducto);
        }
        public int EliminarSeguimiento(int Id_Seguimiento)
        {
            return seguimiento.EliminarSeguimiento(Id_Seguimiento);
        }
        public int ActualizarSeguimiento(int Id_Seguimiento, string comentario, string fecha)
        {
            return seguimiento.ActualizarSeguimiento(Id_Seguimiento, comentario, fecha);
        }
    }
}
