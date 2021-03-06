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

        public int RegistrarPago(string Porcentaje,int Numero_Cuota,string Fecha_Pago, string Referencia_Pago,int Valor_Pagado,string Descuento,int Valor_Descuento,int Fk_Id_Producto)
        {
            return MPago.RegistrarPago(Porcentaje, Numero_Cuota, Fecha_Pago, Referencia_Pago, Valor_Pagado, Descuento, Valor_Descuento, Fk_Id_Producto);
        }
    }
}
