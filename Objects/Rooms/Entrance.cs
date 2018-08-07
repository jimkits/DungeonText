using System;
using System.Collections.Generic;
using DungeonText.Objects.Items;

namespace DungeonText.Objects.Rooms
{
    public class Entrance : Room
    {
        public Entrance()
        {
            Name = "Entrance";
            Description = $"This is the entrance of the cave.{Environment.NewLine}" +
                          $"You entered from the door to the south. There is an entrance to the north";
            Items = new List<Item>
            {
                new RustySword(),
            };
            Secrets = new List<string>();
            Monsters = new List<string>();
            
            North = null;
            East = null;
            South = null;
            West = null;
        }
    }
}