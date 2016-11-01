using Bacterion.Translator.Interfaces;
using Bacterion.Translator.Translators;
using System;

namespace Bacterion.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            object value = "Hola Mundo!";
            object nucleotides = string.Empty;
            object binary;

            // Translate to Nucleotides
            ITranslator bynaryTranslator = new BinaryToNucleotides();
            nucleotides = bynaryTranslator.Translate(value);

            Console.WriteLine(nucleotides);

            // Translate to Binary
            ITranslator nucleotideTranslator = new NucleotidesToBinary();
            binary = nucleotideTranslator.Translate(nucleotides);

            Console.WriteLine(binary);
        }
    }
}
