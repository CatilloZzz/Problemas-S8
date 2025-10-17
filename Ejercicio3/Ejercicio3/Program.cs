using System;
using System.Collections.Generic;

class Program
{
    /// Método principal que controla la ejecución del programa.
    /// Maneja la interacción con el usuario y el flujo del verificador de paréntesis.
    static void Main()
    {
        // Mostrar título del programa
        Console.WriteLine("VERIFICADOR DE PARÉNTESIS\n");

        // Bucle infinito para permitir múltiples verificaciones sin reiniciar el programa
        while (true)
        {
            // Solicitar al usuario que ingrese una expresión 
            Console.Write("Expresión (enter para salir): ");
            string exp = Console.ReadLine();

            // Si el usuario presiona Enter sin texto, salir del bucle y terminar el programa
            if (string.IsNullOrEmpty(exp)) break;

            // Llamar a la función de verificación y obtener el resultado
            bool balanceado = VerificarParentesis(exp);

            // Mostrar el resultado usando operador ternario para elegir el mensaje apropiado
            Console.WriteLine(balanceado ? " Balanceado" : " No balanceado");
            Console.WriteLine();  // Línea en blanco para separar visualmente las iteraciones
        }
    }

    /// Verifica si los paréntesis en una expresión matemática están correctamente balanceados.
    /// Utiliza una pila (Stack) para realizar el seguimiento de los paréntesis de apertura.
    /// name="expresion">La expresión matemática a verificar
    /// True - si todos los paréntesis están balanceados (cada '(' tiene su ')' correspondiente)
    /// False - si hay paréntesis desbalanceados (faltan o sobran paréntesis)
    /// El algoritmo funciona así:
    /// 1. Para cada '(' encontrado: se apila (guarda en la pila)
    /// 2. Para cada ')' encontrado: se desapila (saca de la pila)
    /// 3. Si se intenta desapilar cuando la pila está vacía: la expresión no está balanceada
    /// 4. Al final, si la pila está vacía: la expresión está balanceada
    static bool VerificarParentesis(string expresion)
    {
        // Crear una pila para rastrear los paréntesis de apertura '('
        // Stack es LIFO (Last-In-First-Out): el último que entra es el primero que sale
        Stack<char> pila = new Stack<char>();

        // Recorrer cada carácter de la expresión uno por uno
        foreach (char c in expresion)
        {
            // Si encontramos un paréntesis de apertura '('
            if (c == '(')
            {
                // Apilarlo (agregarlo a la pila)
                // Esto representa que tenemos un paréntesis esperando su cierre
                pila.Push(c);
            }
            // Si encontramos un paréntesis de cierre ')'
            else if (c == ')')
            {
                // Verificar si la pila está vacía
                // Si está vacía, significa que encontramos un ')' sin su '(' correspondiente
                if (pila.Count == 0)
                    return false;  // Expresión no balanceada - cierre sin apertura

                // Desapilar (sacar el último '(' de la pila)
                // Esto representa que hemos cerrado correctamente un paréntesis
                pila.Pop();
            }

            // Nota: Los caracteres que no son '(' ni ')' son ignorados
            // Solo nos interesan los paréntesis para la verificación
        }

        // Al final del recorrido:
        // - Si la pila está VACÍA: todos los '(' encontraron su ')' → Balanceado
        // - Si la pila NO está vacía: quedaron '(' sin cerrar → No balanceado
        return pila.Count == 0;
    }

}
