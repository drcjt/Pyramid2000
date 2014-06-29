using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pyramid2000Engine;

namespace Pyramid2000.ConsoleApplication
{
    class Pyramid2000 : IPrinter
    {
        static void Main(string[] args)
        {
            Pyramid2000 pyramid2000 = new Pyramid2000();
            pyramid2000.PlayGame();
        }

        /// <summary>
        /// Need to move this logic into the Game class.
        /// Need to parameterise it based on the IPrinter and some way to provide player input but note this may be done via ui callbacks
        /// Maybe provide a delegate to the Game class that is invoked when input is to be processed.
        /// </summary>
        private void PlayGame()
        {
            Game game = new Game(this);

            game.StartGame();

            while (!game.GameOver)
            {
                var playerInput = Console.ReadLine();
                game.ProcessPlayerInput(playerInput);
            }
        }

        public void PrintLn(string text)
        {
            Console.WriteLine(text);
        }

        public void Print(string text)
        {
            Console.Write(text);
        }

        /*
         * Tried to force input to be shown in upper case but didn't work
         * 
        public string ReadUpperCaseLine()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                int ch = Console.In.Read();
                if (ch == -1) break;
                if (ch == '\r' || ch == '\n') 
                {
                    if (ch == '\r' && Console.In.Peek() == '\n') 
                        Console.In.Read();
                    return sb.ToString();
                }
                sb.Append((char)ch);
            }

            if (sb.Length > 0) return sb.ToString();
                return null;
        }
         */
    }
}
