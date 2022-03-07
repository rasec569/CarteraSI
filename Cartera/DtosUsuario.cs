using Cartera.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera
{
    internal class DtosUsuario
    {
        static public string NombreUser;

        static public string IdUser;
        
        

        static public DataTable amortizacionFinanciacion(int Financiacion)
        {
            CFinanciacion financiacion = new CFinanciacion();
            CCuota cuota = new CCuota();

            DataTable Dtfinanciacion = financiacion.Financiacion(Financiacion);
            int Valor_Neto = int.Parse(Dtfinanciacion.Rows[0]["Valor_Neto"].ToString());
            int Valor_Sin = int.Parse(Dtfinanciacion.Rows[0]["Valor_Sin_interes"].ToString());
            int Valor_Interes = int.Parse(Dtfinanciacion.Rows[0]["Valor_Interes"].ToString());
            int Valor_Cuota_Con_Interes = int.Parse(Dtfinanciacion.Rows[0]["Valor_Cuota_Con_Interes"].ToString());

            DataTable DtCuotas = cuota.ListarCuotas(Financiacion, "Refinanciación", "");
            decimal PagadoInicialFecha=0;
            for (int i = 0; i < DtCuotas.Rows.Count; i++)
            {
                if (DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Inicial" || DtCuotas.Rows[i]["Tipo"].ToString() == "Valor Separación")
                {
                    PagadoInicialFecha += decimal.Parse(DtCuotas.Rows[i]["Aportado"].ToString().Replace(",", ""));
                } 
            }

            DateTime actual = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DataTable DtCuotasInteres = new DataTable();
            DtCuotasInteres = cuota.ListarCuotasInteres2(Financiacion);
            DtCuotasInteres.Columns.Add("Capital", typeof(string));
            DtCuotasInteres.Columns.Add("Interes", typeof(string));
            DtCuotasInteres.Columns.Add("Saldo", typeof(string));

            DataTable DtResult = new DataTable();
            DtResult.Columns.Add("interesfecha", typeof(string));
            DtResult.Columns.Add("deudafecha", typeof(string));
            DtResult.Columns.Add("capitalfecha", typeof(string));
            DtResult.Columns.Add("aportesfecha", typeof(string));
            DtResult.Columns.Add("saldofecha", typeof(string));


            decimal saldo = Valor_Neto - Valor_Sin;
            decimal interes = saldo * (decimal)Valor_Interes / 100;
            decimal capital = int.Parse(DtCuotasInteres.Rows[0]["Valor"].ToString().Replace(",", "")) - interes;
            decimal deudafecha = 0;
            decimal interespagadofecha = 0;
            decimal interesmorafecha = 0;
            decimal capitalpagadofecha = 0;
            decimal aportadofecha=0;
            decimal aportesfecha = 0;
            for (int i = 0; i < DtCuotasInteres.Rows.Count; i++)
            {
                DateTime date = DateTime.ParseExact(DtCuotasInteres.Rows[i]["Fecha Pago"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (i != 0)
                {

                    interes = saldo * (Convert.ToDecimal(Valor_Interes) / 100);
                    capital = int.Parse(DtCuotasInteres.Rows[i]["Valor"].ToString().Replace(",", "")) - interes;
                }
                if (date <= actual)
                {

                    if (DtCuotasInteres.Rows[i]["Estado"].ToString() == "Pagada")
                    {
                        string ensayo = DtCuotasInteres.Rows[i]["Estado"].ToString();
                        interespagadofecha += interes;
                        capitalpagadofecha += capital;
                    }
                    else if(DtCuotasInteres.Rows[i]["Estado"].ToString() == "Mora")
                    {
                            if (int.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", "")) != 0)
                            {
                                capitalpagadofecha += int.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", ""));
                            }
                            interesmorafecha += interes;
                            deudafecha += Valor_Cuota_Con_Interes;                        
                    }
                    aportadofecha= int.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", "")) - interes;
                }
                saldo = saldo - capital;
                DtCuotasInteres.Rows[i]["Saldo"] = saldo.ToString("N0", CultureInfo.CurrentCulture);
                DtCuotasInteres.Rows[i]["Interes"] = interes.ToString("N0", CultureInfo.CurrentCulture);
                DtCuotasInteres.Rows[i]["Capital"] = capital.ToString("N0", CultureInfo.CurrentCulture);
                aportesfecha += decimal.Parse(DtCuotasInteres.Rows[i]["Aportado"].ToString().Replace(",", ""));
            }
            DataRow row = DtResult.NewRow();
            row["interesfecha"] = interespagadofecha.ToString();
            row["deudafecha"] = deudafecha.ToString();
            row["capitalfecha"] = capitalpagadofecha.ToString();
            row["aportesfecha"] = aportesfecha.ToString();
            int neto = Valor_Neto;
            int inetermora = (int)Math.Round(interesmorafecha);
            int pagoinicial = (int)PagadoInicialFecha;
            int capipagado = (int)Math.Round(capitalpagadofecha);
            row["saldofecha"] = ((neto + inetermora) - (pagoinicial + capipagado)).ToString();
            DtResult.Rows.Add(row);
            return DtResult;
        }
    }
}
