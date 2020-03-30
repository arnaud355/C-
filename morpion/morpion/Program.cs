using System;

namespace morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();
            Console.WriteLine("Game Over");
        }
    }
}
