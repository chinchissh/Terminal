using System;
using System.Collections.Generic;

namespace Terminal
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                SimpleTerminal terminal = new SimpleTerminal();
                terminal.ProcessInput(input);
                terminal.PrintResult();
            }
        }
    }
}
