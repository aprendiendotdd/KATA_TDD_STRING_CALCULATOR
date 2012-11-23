using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        private List<char> Delimitadores = new List<char> {',' , '\n' };

        public int Add(string values)
        {
            if (String.IsNullOrEmpty(values))
                return 0;

            values = DelimitadorParse(values);

            List<int> numeros = ListaNumeros(values);

            if (numeros.Where(x => x < 0).Select(x => x).Count() > 0) {
                throw new ArgumentException("numeros negativos no permitidos");
            }

            return numeros.Sum();
        }

        private List<int> ListaNumeros(string values)
        {
            List<int> numeros =
                values.Split(Delimitadores.ToArray()).Select(n => Int32.Parse(n)).ToList<int>();

            return numeros;
        }

        private string DelimitadorParse(string values)
        {
            Regex expresion = new Regex(
                "^//(.)\n(.*)", RegexOptions.Singleline
                );
            var matches = expresion.Match(values);

            if (matches.Success)
            {
                Delimitadores.Add(matches.Groups[1].Value[0]);
                values = matches.Groups[2].Value;
            }
            return values;
        }
    }
}
