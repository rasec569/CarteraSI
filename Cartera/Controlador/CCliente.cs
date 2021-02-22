using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;
using System.Data;


namespace Cartera.Controlador
{
    interface CCliente
        {
            DataTable cargarClientes();

            DataTable cargarClientes(string nombre);

            int crearCliente(int cedula,string nombre,string apellido, int telefono,string direccion,string correo,int idCartera);

            int actualizarCliente(int Cliente_id,int cedula,string nombre,string apellido, int telefono,string direccion,string correo,int idCartera);     

        }
}
