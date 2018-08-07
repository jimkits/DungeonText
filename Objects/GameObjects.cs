using System;
using System.Collections.Generic;
using DungeonText.Objects.Items;
using DungeonText.Objects.Rooms;
using DungeonText.Text;

namespace DungeonText.Objects
{
    public class GameObjects : IDisposable
    {
        public GameObjects()
        {
            InstantiateGameObjects();
        }
        
        public Player Player { get; set; }
        public CommandOutput CommandOutput { get; set; }
        public Response Response { get; set; }
        public List<Item> Items { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Item> AllItems { get; set; }
        
        public void Dispose()
        {
            InstantiateGameObjects();
        }

        private void InstantiateGameObjects()
        {
            Player = new Player();
            CommandOutput = new CommandOutput();
            Response = new Response();
            
            Items = new List<Item>
            {
                new Potion(),
                new RustySword(),
            };
            
            Rooms = new List<Room>
            {
                new Entrance(),
                new First(),
            };
            
            AllItems = new List<Item>
            {
                new Potion(),
                new RustySword(),
            };
        }
    }
}