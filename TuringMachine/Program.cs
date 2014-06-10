using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace TuringMachine
{


    class Program
    {
        static string input;
        static public List<char> l1 = new List<char>();
        static public List<char> l2 = new List<char>();
        static public List<char> l3 = new List<char>();

        static void Main(string[] args)
        {
            LeMaquina();
        }


        static void LeMaquina()
        {
            l1.Clear();
            l2.Clear();
            l3.Clear();
            bool validated = false;

            while (validated == false)
            {

                Console.WriteLine("Input a string that only has X and Y please: ");
                input = Console.ReadLine();
                //input.ToCharArray();
                validated = ValidateString(input);
            }

            int cut = input.IndexOf("YYYY");

            if (cut == -1)
            {
                Console.WriteLine("No hay suficientes YYYY. BLEH.\n\n\n");
                LeMaquina();
            }
            else
            {
                l1 = input.Substring(0,cut).ToList();
                l2 = input.Substring((cut + 4)).ToList();
            }

            if (l1.Count == l2.Count)
                Console.WriteLine("L1 y L2 tienen la misma cantidad de valores, se puede continuar.");
            else
            {
                Console.WriteLine("L1 y L2 no tienen la misma cantidad de valores. BLEH.\n\n\n");
                LeMaquina();
            }

            for (int i = 0; i < l1.Count; i++)
            {
                if (l1[i] == l2[i])
                    l3.Add(l1[i]);
                else if (l1[i] == 'X' && l2[i] == 'Y')
                    if (l3.Count - 1 != -1) { l3.RemoveAt(l3.Count - 1); }
                else if (l1[i] == 'Y' && l2[i] == 'X')
                {
                    if (l3[l3.Capacity] == 'Y')
                        l3[l3.Capacity] = 'X';
                    else
                        l3[l3.Capacity] = 'Y';
                }
            }

            Console.WriteLine("Fase Final");
            PrintLists();
            Console.WriteLine("\n\n\n");
            LeMaquina();
        }

        static void PrintLists()
        {
            Console.Write("List 1= ");
            foreach (char s in l1)
                Console.Write(s);
            Console.Write("\nList 2= ");
            foreach (char s in l2)
                Console.Write(s);
            Console.Write("\nList 3= ");
            foreach (char s in l3)
                Console.Write(s);
            Console.ReadLine();
        }

        static bool ValidateString(string input)
        {

            input.ToCharArray();
            foreach (char c in input)
            {
                if (c != 'Y' && c != 'X')
                {
                    Console.WriteLine("Only type X or Y");
                    return false;
                }
            }
            return true;
        }
    }
}
