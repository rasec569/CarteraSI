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
        public DataTable ListarCuotas(int financiacion)
        {
            return MCuota.ListarCuotas(financiacion);
        }
        public DataTable reportProyeccion(string FechaInicio, string FechaFin)
        {
            return MCuota.reportProyeccion(FechaInicio, FechaFin);
        }
        public DataTable PagosProgramados(int financiacion, string fecha)
        {
            return MCuota.PagosProgramados(financiacion, fecha);
        }
    }
}
