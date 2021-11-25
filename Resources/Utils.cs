using System;
using System.Linq;

namespace PagoEfectivoApi.Resources
{
    public static class Utils
    {
        public static string GetLetters(string value)
        {
            var randon = new Random();
            int pos = randon.Next(value.Length);
            return value.Substring(pos).Substring(0,2);
        }
         public static int GenerateRandoNumbers()
        {

            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 7));

            return seed;
        }
    }
}