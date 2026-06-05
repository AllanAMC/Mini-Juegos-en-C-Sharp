using System.Diagnostics.Metrics;
using System.Threading;

namespace MiniGames
{
    class Program
    {
        static void PuntosConsecutivos()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Console.Out.Flush();
                Thread.Sleep(900);
            }
            Console.WriteLine();
        }

        static string EvaluarNumero(int num, int numSecreto)
        {
            if (num > numSecreto)
            {
                return "MAS BAJO";
            }
            return "MAS ALTO";
        }

        static void Main(string[] args)

        {
            int max = 500;
            int min = 0;
            int numeroPC;
            bool ganoJugador = false;
            List<int> numerosPC = [];

            Random rnd = new Random();

            int numeroSecreto = rnd.Next(501);
            Console.WriteLine("======== BIENVENIDO AL JUEGO DE ADIVINA EL NUMERO VS PC (500) EN C# ========");
            Console.WriteLine("\nESTAS PREPARADO??     (PRESIONA CUALQUIER TECLA)");
            Console.ReadKey();
            Console.WriteLine("\nEL NUMERO HA SIDO ELEGIDO!");
            Console.Write("SORTEANDO TURNO");
            PuntosConsecutivos();
            int turno = rnd.Next(2);
            while (true)
            {
                if (turno == 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nTURNO DE JUGADOR!");
                        Console.Write("\n> ");
                        if (!int.TryParse(Console.ReadLine() ?? "", out int numeroJugador))
                        {
                            Console.WriteLine("ESO NO ES UN NUMERO.");
                            continue;
                        }
                        if (numeroJugador == numeroSecreto)
                        {
                            ganoJugador = true;
                        }
                        else { Console.WriteLine(EvaluarNumero(numeroJugador, numeroSecreto)); }
                        if (numeroJugador > numeroSecreto && numeroJugador <= 500 && numeroJugador >= 0)
                        {
                            max = numeroJugador - 1;
                        }
                        else if (numeroJugador < numeroSecreto && numeroJugador <= 500 && numeroJugador >= 0) { min = numeroJugador + 1; }
                        break;
                    }
                }

                if (!ganoJugador)
                {
                    Console.WriteLine("\n\nTURNO DE PC!");
                    Console.Write("\nPC ESTA ELIGIENDO");
                    PuntosConsecutivos();
                    numeroPC = rnd.Next(min, max+1);
                    Console.WriteLine(numeroPC);
                    if (numeroPC == numeroSecreto)
                    {
                        break;
                    } else { Console.WriteLine(EvaluarNumero(numeroPC, numeroSecreto)); }
                    if (numeroPC > numeroSecreto)
                    {
                        max = numeroPC - 1;
                    }
                    else { min = numeroPC + 1; }
                    turno = 0;
                    continue;
                }
                break;
            }

            if (ganoJugador)
            {
                Console.WriteLine($"===== FELICIDADES JUGADOR EL NUMERO ERA '{numeroSecreto}', GANASTE! =====");
            }
            else { Console.WriteLine($"==== LA PC HA GANADO EL NUMERO ERA '{numeroSecreto}' ======"); }
        }
}
}