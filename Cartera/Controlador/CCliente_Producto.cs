﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CCliente_Producto
    {
        //MCliente_Producto mcp = new MCliente_Producto();
        public int InsertCliente_Producto(int id_Cliente, int Id_Producto) {
            return MCliente_Producto.InsertCliente_Producto(id_Cliente, Id_Producto);
        }
        public DataTable HistorialCliente (int Id_Cliente)
        {
            return MCliente_Producto.HistorialCliente(Id_Cliente);
        }
    }
}
