namespace Finanzas
{
    using System;
    /// <summary>
    /// Clase que proporciona métodos para cálculos financieros básicos.
    /// </summary>
    public class FinanceCalculator
    {
        /// <summary>
        /// Calcula el interés simple.
        /// </summary>
        /// <param name="capital">Monto inicial.</param>
        /// <param name="tasaInteres">Tasa de interés anual en porcentaje.</param>
        /// <param name="tiempo">Tiempo en años.</param>
        /// <returns>El interés simple calculado.</returns>
        public static double CalcularInteresSimple(double capital, double tasaInteres, double tiempo)
        {
            return capital * (tasaInteres / 100) * tiempo;
        }
        /// <summary>
        /// Calcula el monto final después de aplicar interés compuesto.
        /// </summary>
        /// <param name="capital">Monto inicial.</param>
        /// <param name="tasaInteres">Tasa de interés anual en porcentaje.</param>
        /// <param name="tiempo">Tiempo en años.</param>
        /// <returns>El monto final calculado.</returns>
        public static double CalcularInteresCompuesto(double capital, double tasaInteres, double tiempo)
        {
           return capital * Math.Pow((1 + tasaInteres / 100), tiempo); 
        }
        /// <summary>
        /// Calcula una mensualidad en base a un préstamo utilizando interés simple.
        /// </summary>
        /// <param name="monto">Monto total del préstamo.</param>
        /// <param name="interes">Interés total.</param>
        /// <param name="meses">Número de meses.</param>
        /// <returns>El monto mensual a pagar.</returns>
        public static double CalcularMensualidad(double monto, double interes, int meses)
        {
          return (monto + interes) / meses;  
        }
    }
}