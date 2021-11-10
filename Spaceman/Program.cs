using System;
using System.Globalization;

namespace Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.Greet();

            // Do while loop
            while (g.DidLose() == false && g.DidWin() == false)
            {
                g.Display();
                g.Ask();
            }

            if (g.DidWin() == true)
            {
                Console.WriteLine("");
                Console.WriteLine("Congratulations you won the game!");
                Console.WriteLine($"Your codeword was {g.codeWord}!");
            } else if (g.DidWin() == false)
            {
                Console.WriteLine("");
                Console.WriteLine("You lost.");
                Console.WriteLine("Better luck next time.");
            }
        }
    }
}
