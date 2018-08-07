using System;
using System.Collections.Generic;
using DungeonText.Objects.Items;

namespace DungeonText.Objects.Rooms
{
    public class Room
    {   
        public string Name { get; set; }
        public string Description { get; set; }
        protected List<Item> Items { get; set; }
        public List<string> Secrets { get; set; }
        public List<string> Monsters { get; set; }
        
        public string North { get; set; }
        public string East { get; set; }
        public string South { get; set; }
        public string West { get; set; }

        public void AddItem<T>() where T : Item
        {
            Items.Add((T) Activator.CreateInstance(typeof(T)));
        }

        public void AddItem<T>(T item) where T : Item
        {
            Items.Add(item);
        }

        public void RemoveItem<T>(T item) where T : Item
        {
            Items.RemoveAll(x => x.Name == item.Name);
        }

        public void RemoveAllItems()
        {
            for (var count = 0; count < Items.Count; count++)
            {
                Items.RemoveAll(x => x.Name == Items[count].Name);
            }
        }

        public List<Item> GetItems()
        {
            return Items;
        }
    }
}