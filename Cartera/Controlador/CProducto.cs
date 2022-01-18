using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartera.Modelo;

namespace Cartera.Controlador
{
    class CProducto{

        public DataTable cargarProductos()
        {
           return MProducto.cargarProductos();
        }
        public DataTable CantTipoProductos()
        {
            return MProducto.CantTipoProductos();
        }
        public DataTable CantProductosProyecto()
        {
            return MProducto.CantProductosProyecto();
        }
        public DataTable CantTipoProductosProyecto(string proyecto)
        {
            return MProducto.CantTipoProductosProyecto(proyecto);
        }
        public DataTable CantTipoVentaProductos()
        {
            return MProducto.CantTipoVentaProductos();
        }
        public DataTable CantTipoVentaProductosProyecto(string proyecto)
        {
            return MProducto.CantTipoVentaProductosProyecto(proyecto);
        }
        public DataTable cargarProductosProyecto(int proyectoid)
        {
            return MProducto.cargarProductosProyecto(proyectoid);
        }
        public DataTable cargarProductosDetalleProyecto(int proyectoid, int tipoid)
        {
            return MProducto.cargarProductosDetalleProyecto(proyectoid, tipoid);
        }
        public DataTable cargarTodoProductosDetalleProyecto(int proyectoid)
        {
            return MProducto.cargarTodoProductosDetalleProyecto(proyectoid);
        }
        public DataTable BuscarProductos(string Nombre_Producto)
        {
            return MProducto.BuscarProductos(Nombre_Producto);
        }
        public DataTable ultimoProducto()
        {
            return MProducto.ultimoProducto();
        }
        public DataTable cargarProductosCliente(int IdCliente)
        {
            return MProducto.cargarProductosCliente(IdCliente);
        }

        public int crearProducto(string Nombre_Producto, string Numero_contrato, string Forma_Pago, int Valor_Neto, int Valor_Total, string Fecha_Venta, string Observaciones, int Fk_Id_Proyecto, int Fk_Id_Tipo_Producto)
        {
            return MProducto.crearProducto(Nombre_Producto, Numero_contrato, Forma_Pago, Valor_Neto, Valor_Total, Fecha_Venta, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto);
        }     
        public int actualizarProducto(int id_Producto, string Nombre_Producto, string Numero_contrato, string Forma_Pago,int Valor_Neto, int Valor_Total, string Fecha_Venta, string Observaciones, int Fk_Id_Proyecto, int Fk_Id_Tipo_Producto)
        {
            return MProducto.actualizarProducto(id_Producto,  Nombre_Producto, Numero_contrato, Forma_Pago, Valor_Neto, Valor_Total, Fecha_Venta, Observaciones, Fk_Id_Proyecto, Fk_Id_Tipo_Producto);
        }
        public int actualizarValorProducto(int id_Producto, int Valor_Producto)
        {
            return MProducto.actualizarValorProducto(id_Producto, Valor_Producto);
        }
        public DataTable ReportVentas(string FechaInicio, string FechaFin)
        {
            return MProducto.ReportVentas(FechaInicio, FechaFin);
        }
        public DataTable ReportVentasTipo(string FechaInicio, string FechaFin, string tipo)
        {
            return MProducto.ReportVentasTipo(FechaInicio, FechaFin, tipo);
        }
        public DataTable ReportVentasProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return MProducto.ReportVentasProyecto(FechaInicio, FechaFin, proyecto);
        }
        public DataTable ReportVentasProyectoTipo(string FechaInicio, string FechaFin, string proyecto, string tipo)
        {
            return MProducto.ReportVentasProyectoTipo(FechaInicio, FechaFin, proyecto, tipo);
        }
        public DataTable ValorReportVentas(string FechaInicio, string FechaFin)
        {
            return MProducto.ValorReportVentas(FechaInicio, FechaFin);
        }
        public DataTable ValorReportVentasTipo(string FechaInicio, string FechaFin, string tipo)
        {
            return MProducto.ValorReportVentasTipo(FechaInicio, FechaFin, tipo);
        }
        public DataTable ValorReportVentasProyecto(string FechaInicio, string FechaFin, string proyecto)
        {
            return MProducto.ValorReportVentasProyecto(FechaInicio, FechaFin, proyecto);
        }
        public DataTable ValorReportVentasProyectoTipo(string FechaInicio, string FechaFin, string proyecto, string tipo)
        {
            return MProducto.ValorReportVentasProyectoTipo(FechaInicio, FechaFin, proyecto, tipo);
        }
        public DataTable ValorReportProducto()
        {
            return MProducto.ValorReportProducto();
        }
        public DataTable ClienteProducto(int IdProducto)
        {
            return MProducto.ClienteProducto(IdProducto);
        }
    }
}
