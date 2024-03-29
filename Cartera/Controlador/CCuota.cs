﻿using System;
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
        public int CrearCuota(int cuota, double valor, string Tipo, string fecha, string Estado, int financiacion)
        {
            return Modelo.MCuota.crearcuota(cuota, valor, Tipo, fecha, Estado, financiacion);
        }
        public int InactivarCuota(int cuota, string Estado, int financiacion, string tipo)
        {
            return Modelo.MCuota.InactivarCuota(cuota, Estado, financiacion,  tipo);
        }
        public int ModificarCuota(int idcuota, int cuota, double valor, string tipo, string fecha,  string Estado, double aporte)
        {
            return Modelo.MCuota.ModificarCuota(idcuota, cuota, valor, tipo, fecha, Estado,aporte);
        }
        public DataTable ConsultarCuotaAPagar(int productoid, int cuota, string tipo)
        {
            return MCuota.ConsultarCuotaAPagar(productoid, cuota, tipo);
        }
        public int ActulziarCuotaRegistroPago(int cuota, double aportes, string Estado, int financiacion, string tipo)
        {
            return Modelo.MCuota.ActulziarCuotaRegistroPago(cuota, aportes, Estado, financiacion, tipo);
        }
        public DataTable NumCuotasPagadas( int financiacion)
        {
            return MCuota.NumCuotasPagadas(financiacion);
        }
        public DataTable CuotasPagas(int financiacion)
        {
            return MCuota.CuotasPagas(financiacion);
        }
        public DataTable CuotasPorPagar(int producto)
        {
             return MCuota.CuotasPorPagar(producto);
        }
        public int EliminarCuotas(int financiacion)
        {
            return MCuota.EliminarCuotas(financiacion);
        }
        public int EliminarCuota(int cuota)
        {
            return MCuota.EliminarCuota(cuota);
        }
        public DataTable ListarCuotas(int financiacion, string filtro, string estado)
        {
            return MCuota.ListarCuotas(financiacion, filtro, estado);
        }
        //valor pagado cuota y estado
        public DataTable BalanceCuota(int cuota, int id_Producto, string tipo)
        {
            return MCuota.BalanceCuota(cuota, id_Producto, tipo);
        }
        //valor pagado cuota y estado nuevo metodo
        public DataTable ValoryAporteCuota(int cuota, int id_Producto, string tipo)
        {
            return MCuota.ValoryAporteCuota(cuota, id_Producto, tipo);
        }
        //valida cuotas en mora
        public int ValidarEstadoCuotas(string Fecha, string actulizado)
        {
            return MCuota.ValidarEstadoCuotas(Fecha, actulizado);
        }
        public DataTable ListarCuotasInteres(int financiacion)
        {
            return MCuota.ListarCuotasInteres(financiacion);
        }
        public DataTable ListarCuotasInteres2(int financiacion)
        {
            return MCuota.ListarCuotasInteres2(financiacion);
        }
        public DataTable ListarCuotasActivarDelect(int financiacion)
        {
            return MCuota.ListarCuotasActivarDelect(financiacion);
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
        public DataTable UltimoInicio()
        {
            return MCuota.UltimoInicio();
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
