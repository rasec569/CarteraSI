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

        public int RegistrarPago(string Porcentaje,string Numero_Cuota,string Fecha_Pago, string Referencia_Pago,string Valor_Pagado,string Descuento,string Valor_Descuento,string Fk_Id_Producto)
        {
            return MPago.RegistrarPago(Porcentaje, Numero_Cuota, Fecha_Pago, Referencia_Pago, Valor_Pagado, Descuento, Valor_Descuento, Fk_Id_Producto);
        }
        public DataTable SumarValorRecaudado(string productoid)
        {
            return MPago.SumarValorRecaudado(productoid);
        }
        public DataTable ListarPagosCliente(string productoid)
        {
            return MPago.ListarPagosCliente(productoid);
        }
        public DataTable Tota_Recaudado_Producto(string productoid)
        {
            return MPago.Tota_Recaudado_Producto(productoid);
        }
    }
}
