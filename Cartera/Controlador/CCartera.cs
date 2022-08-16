using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CCartera
    {
        public int crearCartera() 
        {
            return MCartera.crearCartera();
        }

        public DataTable UltimoRegistro()
        {
            return MCartera.UltimoRegistro();

        }
        public DataTable ListarCartera()
        {
            return MCartera.ListarCartera();
        }
        public DataTable ListarVistaCartera()
        {
            return MCartera.ListarVistaCartera();
        }        
        public  DataTable ListarCarteraProyecto(int proyectoid)
        {
            return MCartera.ListarCarteraProyecto(proyectoid);
        }
        public DataTable CarteraCliente(string cedula)
        {
            return MCartera.CarteraCliente(cedula);
        }
        public DataTable BuscarCartera(string cedula)
        {
            return MCartera.BuscarCartera(cedula);
        }
        public int ActulizarValorRecaudado(int carteraid)
        {
            return MCartera.ActulizarValorRecaudado(carteraid);
        }
        public int ActulizarValorRecaudado2(int carteraid, int productoid)
        {
            return MCartera.ActulizarValorRecaudado2(carteraid, productoid);
        }
        public int ActulizarSaldo(int carteraid)
        {
            return MCartera.ActulizarSaldo(carteraid);
        }
        public DataTable ActulizarValorTotal(int clienteid, int carteraid)
        {
            return MCartera.ActulizarValorTotal(clienteid, carteraid);
        }
        public DataTable BuscarFechaspagos(int productoid)
        {
            var result = MCartera.BuscarFechaspagos(productoid);
            return result;
        }
        public int ActulizarEstadoCartera(string carteraid, string estado, int cuotas, int meses , int pagas, int mora)
        {
            return MCartera.ActulizarEstados(carteraid, estado, cuotas, meses, pagas, mora);
        }
        public int ActivarEstadoCartera(string carteraid, double total)
        {
            return MCartera.ActivarEstadoCartera(carteraid, total);
        }
        
        public DataTable TotalesCartera()
        {
            return MCartera.TotalesCartera();
        }
        public DataTable Disoluciones(string FechaInicio, string FechaFin)
        {
            return MCartera.Disoluciones( FechaInicio, FechaFin);
        }
        public DataTable TotalDisoluciones(string FechaInicio, string FechaFin)
        {
            return MCartera.TotalDisoluciones(FechaInicio, FechaFin);
        }
        public DataTable DisolucionesTipo(string FechaInicio, string FechaFin, string tipo)
        {
            return MCartera.DisolucionesTipo(FechaInicio, FechaFin, tipo);
        }
        public DataTable TotalDisolucionesTipo(string FechaInicio, string FechaFin, string tipo)
        {
            return MCartera.TotalDisolucionesTipo(FechaInicio, FechaFin, tipo);
        }
        public DataTable DisolucionesProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return MCartera.DisolucionesProyecto(FechaInicio, FechaFin, proyecto);
        }
        public DataTable TotalDisolucionesProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return MCartera.TotalDisolucionesProyecto(FechaInicio, FechaFin, proyecto);
        }
        public DataTable DisolucionesProyectoTipo(string FechaInicio, string FechaFin, string proyecto, string tipo)
        {
            return MCartera.DisolucionesProyectoTipo(FechaInicio, FechaFin, proyecto, tipo);
        }
        public DataTable TotalDisolucionesProyectoTipo(string FechaInicio, string FechaFin, string proyecto, string tipo)
        {
            return MCartera.TotalDisolucionesProyectoTipo(FechaInicio, FechaFin, proyecto, tipo);
        }
    }
}
