using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5__S8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Paso 1: Crear una cola (Queue) que almacenará los nombres de los clientes
            Queue<string> colaClientes = new Queue<string>();

            // Paso 2: Pedir al usuario que ingrese los nombres de los clientes
            // El proceso termina cuando el usuario escribe "fin"
            Console.WriteLine("Ingrese los nombres de los clientes (solo letras, escriba 'fin' para terminar):");

            while (true)
            {
                string input = Console.ReadLine();  // Leer la entrada del usuario

                if (input.ToLower() == "fin")  // Si escribe "fin", se termina el registro
                {
                    break;  // Sale del bucle
                }

                if (IsValidName(input))  // Verificar si el nombre solo contiene letras
                {
                    colaClientes.Enqueue(input);  // Agregar el nombre a la cola
                }
                else
                {
                    // Mostrar mensaje de error si el nombre contiene algo diferente a letras
                    Console.WriteLine("Error: Solo se aceptan letras (sin números, espacios ni símbolos). Intente de nuevo.");
                }
            }

            // Paso 3: Mostrar el contenido actual de la cola
            Console.WriteLine("\nEstado actual de la cola:");
            if (colaClientes.Count > 0)
            {
                // Recorrer y mostrar cada cliente en la cola
                foreach (var cliente in colaClientes)
                {
                    Console.WriteLine("- " + cliente);
                }
            }
            else
            {
                Console.WriteLine("La cola está vacía.");
            }

            // Paso 4: Atender al primer cliente (el primero en entrar es el primero en salir)
            if (colaClientes.Count > 0)
            {
                string primerCliente = colaClientes.Dequeue();  // Quitar y obtener el primer cliente
                Console.WriteLine("\nAtendiendo al primer cliente: " + primerCliente);

                // Paso 5: Mostrar la cola después de atender al primer cliente
                Console.WriteLine("\nCola después de atender al cliente:");
                if (colaClientes.Count > 0)
                {
                    foreach (var cliente in colaClientes)
                    {
                        Console.WriteLine("- " + cliente);
                    }
                }
                else
                {
                    Console.WriteLine("La cola está vacía después de atender.");
                }
            }
            else
            {
                Console.WriteLine("\nNo hay clientes en la cola para atender.");
            }

            // Paso 6: Mostrar si la cola está vacía o cuántos clientes quedan
            if (colaClientes.Count == 0)
            {
                Console.WriteLine("\nLa cola está vacía.");
            }
            else
            {
                Console.WriteLine("\nLa cola no está vacía. Hay " + colaClientes.Count + " cliente(s) restante(s).");
            }
        }

        // Método que verifica si un nombre contiene solo letras
        static bool IsValidName(string name)
        {
            foreach (char c in name)  // Revisar cada carácter del texto
            {
                if (!char.IsLetter(c))  // Si el carácter no es una letra
                {
                    return false;  // Retorna falso
                }
            }
            return true;  // Si todos los caracteres son letras, retorna verdadero
        }
    }
}
