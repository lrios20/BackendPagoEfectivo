using System;
using System.Linq;
using System.Text.RegularExpressions;

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
          public static bool IsValidMail(string mail)
        {
            return Regex.IsMatch((mail ?? "").Trim(),
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase);
        }
    }
}