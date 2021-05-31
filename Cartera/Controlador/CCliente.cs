using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;
using System.Data;


namespace Cartera.Controlador
{
    class CCliente
    {
        public DataTable cargarClientes()
        {
            return MCliente.cargarClientes();
        }
        public DataTable cargarClientesProyecto(int proyectoid)
        {
            return MCliente.cargarClientesProyecto(proyectoid);
        }

        public DataTable cargarClientes(string nombre) 
        {
            return MCliente.cargarClientes(nombre);
        }
        public DataTable BuscarClientesCedula(string cedula)
        {
            return MCliente.BuscarClientesCedula(cedula);
        }

        public int crearCliente(string cedula,string nombre,string apellido, string telefono ,string direccion,string correo,int idCartera)
        {
            return MCliente.crearCliente(cedula, nombre, apellido, telefono, direccion, correo, idCartera);
        }

        public int actualizarCliente(string Cliente_id, string cedula,string nombre,string apellido, string telefono,string direccion,string correo,int idCartera)
        {
            return MCliente.actualizarCliente(Cliente_id, cedula, nombre, apellido, telefono, direccion, correo, idCartera);

        }

        public DataTable ultimoCliente()
        {
            return MCliente.ultimoCliente();
        }
       

        

    }
}
