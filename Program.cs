using System;
using DungeonText.Objects;
using DungeonText.Objects.Rooms;

namespace DungeonText
{
    public static class Program
    {
        static void Main(string[] args)
        {
            using (var gameObject = new GameObjects())
            {
                var commandOutput = Command.Get(gameObject, "intro");
                Console.WriteLine(commandOutput.Output);
                Console.Write($"{Environment.NewLine}What will you do next? ");

                while (commandOutput.ContinueAdventure)
                {
                    commandOutput = Command.Get(gameObject, Console.ReadLine());

                    Console.WriteLine(commandOutput.Output);

                    Console.Write($"{Environment.NewLine}What will you do next? ");
                }
            }
        }
    }
}