using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CCuota
    {
        public int CrearCuota(int cuota, int valor, string Tipo, string fecha, string Estado, int financiacion)
        {
            return Modelo.MCuota.crearcuota(cuota, valor, Tipo, fecha, Estado, financiacion);
        }
        public int ActulziarCuota(int cuota, string Estado, int financiacion, string tipo)
        {
            return Modelo.MCuota.actualizarcuota(cuota, Estado, financiacion,  tipo);
        }
        public DataTable CuotasPagadas( int financiacion)
        {
            return MCuota.CuotasPagadas(financiacion);
        }
        public int EliminarCuotas(int financiacion)
        {
            return MCuota.EliminarCuotas(financiacion);
        }
        public DataTable ListarCuotas(int financiacion)
        {
            return MCuota.ListarCuotas(financiacion);
        }
        public DataTable ListarCuotasInteres(int financiacion)
        {
            return MCuota.ListarCuotasInteres(financiacion);
        }
        public DataTable ListarCuotasActulizar(int financiacion, string fecha)
        {
            return MCuota.ListarCuotasActulizar(financiacion, fecha);
        }
        public DataTable reportProyeccion(string FechaInicio, string FechaFin)
        {
            return MCuota.reportProyeccion(FechaInicio, FechaFin);
        }
        public DataTable reportProyeccionTipo(string FechaInicio, string FechaFin, string tipo)
        {
            return MCuota.reportProyeccionTipo(FechaInicio, FechaFin, tipo);
        }
        public DataTable reportProyeccionProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return MCuota.reportProyeccionProyecto(FechaInicio, FechaFin, proyecto);
        }
        public DataTable reportProyeccionProyectoTipo(string FechaInicio, string FechaFin, string proyecto, string tipo)
        {
            return MCuota.reportProyeccionProyectoTipo(FechaInicio, FechaFin, proyecto, tipo);
        }
        public DataTable PagosProgramados(int financiacion, string fecha)
        {
            return MCuota.PagosProgramados(financiacion, fecha);
        }
        public int UltimaActuliacionEstadosCuota(string user, string fecha)
        {
            return MCuota.UltimaActuliacionEstadosCuota(user, fecha);
        }
        public DataTable ValidarActulizacion(string user)
        {
            return MCuota.ValidarActulizacion(user);
        }
        public DataTable ProyeccionMes(string FechaInicio, string FechaFin)
        {
            return MCuota.ProyeccionMes(FechaInicio, FechaFin);
        }
        public DataTable ProyeccionMesProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return MCuota.ProyeccionMesProyecto(FechaInicio, FechaFin, proyecto);
        }
    }
}
