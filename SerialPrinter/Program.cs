using System;
using System.IO.Ports;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace SerialPrinter // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrinterCommands.InitPrinter();
            Console.WriteLine("Type things!");
            while (true)
            {
                PrinterCommands.PrintMessage(Console.ReadLine());
                PrinterCommands.CutPaper();
            }
        }
    }
}