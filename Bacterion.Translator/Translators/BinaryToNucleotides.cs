using Bacterion.Translator.Interfaces;
using BinaryFormatter;
using System;
using System.Text;

namespace Bacterion.Translator.Translators
{
    public class BinaryToNucleotides : ITranslator
    {
        public object Translate(object obj)
        {
            BinaryConverter binaryFormatter = new BinaryConverter();
            byte[] binary = binaryFormatter.Serialize(obj);
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            // Convert to Base-10
            foreach (byte b in binary)
            {
                sb.Append(Convert.ToString(b, 10));   
            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine("--------------");

            // Convert to Base-4
            foreach (char digit in sb.ToString().ToCharArray())
            {
                sb2.Append(GetBase4(int.Parse(digit.ToString())));
            }

            Console.WriteLine(sb2.ToString());

            return null;
        }

        private string GetBase4(int number)
        {
            string remainder = string.Empty;

            if (number >= 4)
            {
                remainder = (number % 4).ToString();

                remainder += GetBase4(number / 4);
            }
            else
            {
                remainder = number.ToString();
            }

            return remainder;
        }
    }
}
