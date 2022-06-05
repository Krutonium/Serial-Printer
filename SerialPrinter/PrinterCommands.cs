using System.IO.Ports;
using System.Text;

namespace SerialPrinter;

public class PrinterCommands
{


    private static SerialPort? _printer;

    public static void InitPrinter()
    {
        _printer = new SerialPort
        {
            BaudRate = 9600,
            PortName = PickPort(),
            Encoding = Encoding.ASCII
        };
        _printer.Open();
    }
    private static string PickPort()
    {
        int x = 0;
        Console.WriteLine("Please select the correct port");
        foreach (var port in SerialPort.GetPortNames())
        {
            Console.WriteLine($"{x}: {port}");
            x += 1;
        }

        var choice = -1;
        while (choice == -1)
        {
            var input = Console.ReadKey();
            Console.WriteLine();
            choice = isDigit(input);
        }

        return SerialPort.GetPortNames()[choice];
    }

    private static int isDigit(ConsoleKeyInfo key)
    {
        if (Char.IsDigit(key.KeyChar))
        {
            int input = int.Parse(key.KeyChar.ToString());
            return input;
        }
        Console.WriteLine("Invalid Input");
        return -1;
    }
    public static void PrintMessage(string message)
    {
        _printer?.WriteLine(message);
    }

    public static void CutPaper()
    {
        //Doesn't seem to work.
        _printer?.Write(new Byte[0xFF], 0, new Byte[0xFF].Length);
    }
}