using System;
using DungeonText.Objects;
using DungeonText.Objects.Enums;

namespace DungeonText.Helpers
{
    public class Translate
    {
        public static Commands Command(string text)
        {
            switch (text.ToLower())
            {
                case "intro":
                    return Commands.Intro;
                case "help":
                    return Commands.Help;
                case "quit":
                    return Commands.Quit;
                case "status":
                    return Commands.Status;
                case "search":
                    return Commands.Search;
                case "pickup":
                    return Commands.Pickup;
                case "drop":
                    return Commands.Drop;
                default:
                    return Commands.Gibberish;
            }
        }
    }
}