using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Laboratorio_2_Osorio_Nicolas_2D
{
    class Calculadora
    {
        public static double operar(double numero1, double numero2, string operador)
        {
            switch (operador)
            {
                case "+":
                    return numero1 + numero2;
                case "-":
                    return numero1 - numero2;
                case "*":
                    return numero1 * numero2;
                case "/":
                    if (numero2 == 0)
                    {
                        return 0;
                    }
                    else
                        return numero1 / numero2;
                default:
                    return 0;
            }
        }

        public static string validarOperador(string operador)
        {
            switch (operador)
            {
                case "+":
                    return "+";
                case "-":
                    return "-";
                case "*":
                    return "*";
                case "/":
                    return "/";
                default:
                    return "+";
    
             }
        }
    }
}