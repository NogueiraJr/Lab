using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public interface ICalculadorInss
	{
		/// <summary>
		/// Deve retornar o deconto do INSS aplicado ao salário, na determinada data.
		/// </summary>
		decimal CalcularDesconto(DateTime data, decimal salario);
    }

    public class clsInss : ICalculadorInss {
        public decimal CalcularDesconto(DateTime data, decimal salario) {
            decimal[,] tbl = getTable();

            var r = 0M;
            for (int x = 0; x < tbl.GetLength(0); x++) {
                if (tbl[x, 0] == data.Year) {
                    if (salario >= tbl[x, 1] && salario <= tbl[x, 2]) {
                        r = salario * (tbl[x, 3] / 100);
                        if (r > 0) return r;
                    }
                } else r = tbl[x, 4];
            } return r;
        }

        /// <summary>
        /// Gets the table.
        /// </summary>
        /// <returns>Return the table static or dinamic for External Database.</returns>
        private static decimal[,] getTable() {
            return new decimal[,] { /* sempre o teto do ano sub-sequente */
                                  { 2011,0000000M,1106.90M,08.00M,000.00M }
                                , { 2011,1106.91M,1844.83M,09.00M,000.00M }
                                , { 2011,1844.84M,3689.66M,11.00M,500.00M }

                                , { 2012,0000000M,1000.00M,07.00M,000.00M }
                                , { 2012,1000.01M,1500.00M,08.00M,000.00M }
                                , { 2012,1500.01M,3000.00M,09.00M,000.00M }
                                , { 2012,3000.01M,4000.00M,11.00M,405.86M }
            };
        }
    }
}
