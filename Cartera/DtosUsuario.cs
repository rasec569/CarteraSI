using Cartera.Controlador;
using Cartera.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartera
{
    internal class DtosUsuario
    {
        static public string NombreUser;

        static public string IdUser;



        static public DataTable amortizacionFinanciacion(int Financiacion)
        {
            CFinanciacion financiacion = new CFinanciacion();
            CRefinanciacion refinanciacion = new CRefinanciacion();
            CCuota cuota = new CCuota();
            decimal Valor_Total = 0;
            decimal PagadoInicialFecha = 0;
            DateTime FechaCuota;
            // consulta la financiación actual y las almacena en variables
            DataTable Dtfinanciacion = financiacion.Financiacion(Financiacion);
            decimal Valor_Neto = int.Parse(Dtfinanciacion.Rows[0]["Valor_Neto"].ToString());
            decimal Valor_Sin = int.Parse(Dtfinanciacion.Rows[0]["Valor_Sin_interes"].ToString());
            decimal Valor_Interes = int.Parse(Dtfinanciacion.Rows[0]["Valor_Interes"].ToString());
            decimal Valor_Cuota_Con_Interes = decimal.Parse(Dtfinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());
            string IdRefinancioacion= Dtfinanciacion.Rows[0]["Id_Refinanciacion"].ToString();
            //lista las cuotas de la financiacion filtrando las que no pertenescan una refinanciacion           
            DataTable DtCuotas = cuota.ListarCuotas(Financiacion, "Refinanciación", "");   
            // obtengo al fecha acual
            DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //tabla temporal de resultados
            DataTable DtResult = new DataTable();
            DtResult.Columns.Add("interesfecha", typeof(string));
            DtResult.Columns.Add("deudafecha", typeof(string));
            DtResult.Columns.Add("capitalfecha", typeof(string));
            DtResult.Columns.Add("aportesfecha", typeof(string));
            DtResult.Columns.Add("saldofecha", typeof(string));

            decimal deudafecha = 0;
            decimal interespagadofecha = 0;
            decimal interesmorafecha = 0;
            decimal capitalpagadofecha = 0;
            decimal aportadofecha = 0;
            decimal aportesfecha = 0;
            if (IdRefinancioacion == "")
            {
                DataTable DtCuotasInteres = new DataTable();
                DtCuotasInteres = cuota.ListarCuotasInteres2(Financiacion);
                //recorremos la tabla y sumamos las cuotas pagadas de separacion e iniciales
                for (int i = 0; i < DtCuotas.Rows.Count; i++)
                {
                    if (DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Inicial" || DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Separación")
                    {
                        PagadoInicialFecha += decimal.Parse(DtCuotas.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture);
                    }
                }
                //agrego las tres columnas para la tabla de amortizacion
                DtCuotasInteres.Columns.Add("Capital", typeof(string));
                DtCuotasInteres.Columns.Add("Interes", typeof(string));
                DtCuotasInteres.Columns.Add("Saldo", typeof(string));         

                decimal saldo = Valor_Neto - Valor_Sin;
                decimal interes = saldo * (decimal)Valor_Interes / 100;
                decimal capital = Convert.ToDecimal(DtCuotasInteres.Rows[0]["Valor"].ToString().Replace(",", ""), CultureInfo.InvariantCulture) - interes;
                
                for (int i = 0; i < DtCuotasInteres.Rows.Count; i++)
                {
                    //obtiene la fecha de pago de la cuota i
                     FechaCuota = DateTime.ParseExact(DtCuotasInteres.Rows[i]["Fecha Pago"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    //
                    if (i != 0)
                    {
                        interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
                        capital = decimal.Parse(DtCuotasInteres.Rows[i]["Valor"].ToString().Replace(",", ""), CultureInfo.InvariantCulture) - interes;
                    }
                    if (FechaCuota <= actual)
                    {

                        if (DtCuotasInteres.Rows[i]["Estado"].ToString() == "Pagada")
                        {
                            string ensayo = DtCuotasInteres.Rows[i]["Estado"].ToString();
                            interespagadofecha += interes;
                            capitalpagadofecha += capital;
                        }
                        else if (DtCuotasInteres.Rows[i]["Estado"].ToString() == "Mora")
                        {
                            if (decimal.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture) != 0)
                            {
                                capitalpagadofecha += decimal.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture);
                            }
                            interesmorafecha += interes;
                            deudafecha += (decimal)Valor_Cuota_Con_Interes;
                        }
                        aportadofecha = decimal.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture) - interes;
                    }
                    else
                    {
                        if (decimal.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture) != 0)
                        {
                            capitalpagadofecha += decimal.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture);
                        }
                    }
                    saldo = saldo - capital;
                    DtCuotasInteres.Rows[i]["Saldo"] = saldo.ToString("N2", CultureInfo.CurrentCulture);
                    DtCuotasInteres.Rows[i]["Interes"] = interes.ToString("N2", CultureInfo.CurrentCulture);
                    DtCuotasInteres.Rows[i]["Capital"] = capital.ToString("N2", CultureInfo.CurrentCulture);
                    aportesfecha += decimal.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture);
                }                
            }
            else
            {
                DataTable DtRefi = new DataTable();
                DtRefi = refinanciacion.RefinanciacionFinanciacion(Financiacion);
                IdRefinancioacion = DtRefi.Rows[0]["Id_Refinanciacion"].ToString();
                DataTable DtCuotasRefi = new DataTable();
                DtCuotasRefi = cuota.ListarCuotas(Financiacion, "", "Inactiva");
                //DtCuotasRefi.Columns["Valor"].SetOrdinal(5);
                DtCuotasRefi.Columns.Add("Capital", typeof(string));
                DtCuotasRefi.Columns.Add("Interes", typeof(string));
                DtCuotasRefi.Columns.Add("Saldo", typeof(string));
                Valor_Total = decimal.Parse(DtRefi.Rows[0]["Valor Financiación"].ToString());
                decimal ValCuota = decimal.Parse(DtRefi.Rows[0]["Valor Cuota"].ToString());
                decimal saldo = decimal.Parse(DtRefi.Rows[0]["Valor Total"].ToString());
                decimal TempInt = decimal.Parse(DtRefi.Rows[0]["Valor Interes"].ToString());
                decimal interes = saldo *(TempInt / 100); 
                decimal capital = ValCuota - interes;
                PagadoInicialFecha = Valor_Total - saldo;
                for (int i = 0; i < DtCuotasRefi.Rows.Count; i++)
                {
                    if (DtCuotasRefi.Rows[i]["Tipo"].ToString() == "Refinanciación")
                    {
                        if (i != 0)
                        {

                            interes = saldo * interes;
                            capital = ValCuota - interes;
                        }
                        DtCuotasRefi.Rows[i]["Saldo"] = saldo.ToString("N2", CultureInfo.CurrentCulture);
                        DtCuotasRefi.Rows[i]["Interes"] = interes.ToString("N2", CultureInfo.CurrentCulture);
                        DtCuotasRefi.Rows[i]["Capital"] = capital.ToString("N2", CultureInfo.CurrentCulture);

                        if (DtCuotasRefi.Rows[i]["Estado"].ToString() == "Pagada")
                        {
                            string ensayo = DtCuotasRefi.Rows[i]["Estado"].ToString();
                            interespagadofecha += interes;
                            capitalpagadofecha += capital;
                            saldo = saldo - capital;
                        }
                        else if (DtCuotasRefi.Rows[i]["Estado"].ToString() == "Mora")
                        {
                            if (decimal.Parse(DtCuotasRefi.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture) != 0)
                            {
                                capitalpagadofecha += decimal.Parse(DtCuotasRefi.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture);
                            }
                            interesmorafecha += interes;
                            deudafecha += (decimal)Valor_Cuota_Con_Interes;
                        }
                        aportadofecha = decimal.Parse(DtCuotasRefi.Rows[i]["Aportado"].ToString().Replace(",", ""), CultureInfo.InvariantCulture) - interes;
                        
                    }                    
                }
            }
            //prepara y llena el datable 
            DataRow row = DtResult.NewRow();
            row["interesfecha"] = interespagadofecha.ToString();
            row["deudafecha"] = deudafecha.ToString();
            row["capitalfecha"] = capitalpagadofecha.ToString();
            row["aportesfecha"] = aportesfecha.ToString();
            decimal neto = Valor_Neto;
            decimal inetermora = Math.Round(interesmorafecha, 2);
            decimal pagoinicial = PagadoInicialFecha;
            decimal capipagado = Math.Round(capitalpagadofecha, 2);
            if (IdRefinancioacion == "")
            {
                row["saldofecha"] = ((neto + inetermora) - (pagoinicial + capipagado)).ToString();
            }
            else
            {
                row["saldofecha"] = (Valor_Total - (pagoinicial + capipagado)).ToString();
            }

            DtResult.Rows.Add(row); ;
            return DtResult;
        }
    }
}
