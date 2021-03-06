﻿using System;
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
        public  DataTable ListarCarteraProyecto(int proyectoid)
        {
            return MCartera.ListarCarteraProyecto(proyectoid);
        }
        public DataTable CarteraCliente(string cedula)
        {
            return MCartera.CarteraCliente(cedula);
        }
        public int ActulizarValorRecaudado(int carteraid)
        {
            return MCartera.ActulizarValorRecaudado(carteraid);
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
        public int ActulizarEstados(string carteraid, string estado, int cuotas, int meses , int pagas, int mora)
        {
            return MCartera.ActulizarEstados(carteraid, estado, cuotas, meses, pagas, mora);
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
    }
}
