using System;
using System.Collections.Generic;

namespace TraductorConsole
{
    class Program
    {
        static List<string> palabras = new List<string>(100);
        static List<string> words = new List<string>(100);
        static void Main(string[] args)
        {
            int opcion;
            bool flag = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Escoja una opcion");
                menu();

                opcion = Convert.ToInt32(Console.ReadLine() );

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese palabra y traducción");
                        Console.WriteLine("Ejemplo:   Hola:Hi ");
                        string texto = Console.ReadLine();
                        CrearDiccionario(texto);
                        break;

                    case 2:
                        Console.WriteLine("Ingrese la palabra en ingles a buscar:");
                        string word = Console.ReadLine();
                        Traducir(word);
                        break;

                    case 3:
                        flag = true;
                        break;

                    default:
                        Console.WriteLine("----- ERROR #3 -----");
                        Console.WriteLine("Menu inexistente");
                        Console.WriteLine("Se deseó ingresar a una opcion que no existe");
                        break;
                }

            } while (flag == false);
        }

        public static void menu()
        {
            Console.WriteLine("1. Agregar Diccionaro");
            Console.WriteLine("2. Buscar palabra");
            Console.WriteLine("3. Salir");
            Console.WriteLine("");
        }
        public static void CrearDiccionario(string texto)
        {
            string espanol = "";
            string Ingles = "";
            bool flag = false;

            if (texto.Contains(":") == false)
            {
                Console.WriteLine("---- ERROR #1----");
                Console.WriteLine("No se encontró una separación entre las palabras");
                Console.WriteLine("Hace falta indicar ':' ");
                Console.WriteLine("");
            }

            foreach (char c in texto)
            {

                if (c == ':')
                {
                    flag = true;
                    continue;
                }

                if (flag == true)
                {
                    espanol += c;
                    continue;
                }
                Ingles += c;
            }

            palabras.Add(espanol);
            words.Add(Ingles);
        }

        public static void Traducir(string palabra)
        {
            string traduccion = "";
            int index = -1;
            foreach(string traducir in words)
            {
                index++;
                if (palabra == traducir)
                {
                    traduccion = palabras.ToArray()[index];
                    continue;
                }
            }

            if (traduccion.Equals(""))
            {
                Console.WriteLine("---- ERROR #2----");
                Console.WriteLine("No se encontro ninguna palabra traducida de acuerdo a la busqueda ");
                Console.WriteLine("Se recomienda ingresar primero la palabra al diccionario ");
                Console.WriteLine("");
                return;
            }
            Console.WriteLine(palabra + " = " + traduccion);
        }
    }
}
