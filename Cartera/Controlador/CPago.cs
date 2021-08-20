using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;
using System.Data;

namespace Cartera.Controlador
{
    class CPago
    {
        public DataTable ConsultarUltimaCuota(int productoid)
        {
            return MPago.ConsultarUltimaCuota(productoid);
        }
        public DataTable ConsultarCuotas(int productoid, string tipo)
        {
            return MPago.ConsultarCuotas(productoid, tipo);
        }

        public int RegistrarPago(string Porcentaje,string Numero_Cuota,string Fecha_Pago,string Concepto, string Entidad, string Referencia_Pago,string Valor_Pagado,string Descuento,string Valor_Descuento,string Fk_Id_Producto)
        {
            return MPago.RegistrarPago(Porcentaje, Numero_Cuota, Fecha_Pago, Concepto, Entidad, Referencia_Pago, Valor_Pagado, Descuento, Valor_Descuento, Fk_Id_Producto);
        }
        public int ActulizarPago(int idpago, string Porcentaje, string Numero_Cuota, string Fecha_Pago, string Concepto, string Entidad, string Referencia_Pago, string Valor_Pagado, string Descuento, string Valor_Descuento)
        {
            return MPago.ActulizarPago(idpago, Porcentaje, Numero_Cuota, Fecha_Pago, Concepto, Entidad, Referencia_Pago, Valor_Pagado, Descuento, Valor_Descuento);
        }
        public int EliminarPago(int idpago)
        {
            return MPago.EliminarPago(idpago);
        }
        public DataTable SumarValorRecaudado(string productoid)
        {
            return MPago.SumarValorRecaudado(productoid);
        }
        public DataTable ListarPagosCliente(string productoid)
        {
            return MPago.ListarPagosCliente(productoid);
        }
        public DataTable ReportesPagosCliente(string productoid)
        {
            return MPago.ReportesPagosCliente(productoid);
        }
        public DataTable Tota_Recaudado_Producto(string productoid)
        {
            return MPago.Tota_Recaudado_Producto(productoid);
        }
        public DataTable reportPagos(string FechaInicio, string FechaFin)
        {
            return MPago.reportPagos(FechaInicio, FechaFin);
        }
        public DataTable reportPagosProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return MPago.reportPagosProyecto(FechaInicio, FechaFin, proyecto);
        }
        public DataTable ValorReportPagos(string FechaInicio, string FechaFin)
        {
            return MPago.ValorReportPagos(FechaInicio, FechaFin);
        }
        public DataTable ValorReportPagosProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return MPago.ValorReportPagosProyecto(FechaInicio, FechaFin, proyecto);
        }

        public DataTable PagosMes(string FechaInicio, string FechaFin)
        {
            return MPago.PagosMes(FechaInicio, FechaFin);
        }
        public DataTable PagosMesProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return MPago.PagosMesProyecto(FechaInicio, FechaFin, proyecto);
        }
    }
}
