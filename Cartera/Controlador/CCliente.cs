using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;
using System.Data;
using Cartera.Modelo;


namespace Cartera.Controlador
{
    class CCliente
    {
        public DataTable cargarClientes()
        {
            return MCliente.cargarClientes();
        }

        public DataTable cargarClientes(string nombre) 
        {
            return MCliente.cargarClientes(nombre);
        }

        public int crearCliente(int cedula,string nombre,string apellido, int telefono ,string direccion,string correo,int idCartera)
        {
            return MCliente.crearCliente(cedula, nombre, apellido, telefono, direccion, correo, idCartera);
        }

        public int actualizarCliente(int Cliente_id,int cedula,string nombre,string apellido, int telefono,string direccion,string correo,int idCartera)
        {
            return MCliente.actualizarCliente(Cliente_id, cedula, nombre, apellido, telefono, direccion, correo, idCartera);

        }

        public DataTable ultimoCliente()
        {
            return MCliente.ultimoCliente();
        }
       

        

    }
}
