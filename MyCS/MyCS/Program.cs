using System;

namespace MisTareas
{
    public class Contador
    {

        public void Cuentame(string texto)
        {
            if (texto == null)
            {
                Console.WriteLine("\nNo se acepta texto NUL!");
                return;
            }

            texto.ToLower();
            char[] todo = texto.ToCharArray();
            char[] vocales = "aeiou".ToCharArray();
            char[] consonantes = "bcdfghjlmnpqrstvzxy".ToCharArray();

            int t, v = 0, c = 0;
            t = todo.Length;

            foreach (char item in todo)
            {
                string elem = item.ToString();
                if (elem.IndexOfAny(vocales) > -1) v++;
                else if (elem.IndexOfAny(consonantes) > -1) c++;
            }

            Console.WriteLine("\nLetras (letters): {0}", v + c);
            Console.WriteLine("Espacios (spaces): {0}", t - v - c);
            Console.WriteLine("Vocales (vowels): {0}", v);
            Console.WriteLine("Consonantes (consonants): {0}", c);
        }
    }

    class MiTarea
    {

        static void Main()
        {
            string ejemplo = "Brasil decirme que se siente";
            Contador obj = new Contador();
            obj.Cuentame(ejemplo);
            Console.Write("Hit to end...");
            Console.ReadLine();
        }
    }
}

