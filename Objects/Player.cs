using System;
using System.Collections.Generic;
using DungeonText.Objects.Items;
using DungeonText.Objects.Rooms;

namespace DungeonText.Objects
{
    public class Player
    {
        public Player()
        {
            MoveToRoom<Entrance>();
            Inventory = new List<Item>();
            Weapon = null;
        }

        private Room CurrentRoom { get; set; }
        private List<Item> Inventory { get; set; }
        private Item Weapon { get; set; }

        // WEAPON
        
        public void EquipWeapon<T>() where T: Item
        {
            Weapon = (T) Activator.CreateInstance(typeof(T));
        }

        public Item GetEquippedWeapon()
        {
            return Weapon;
        }

        // INVENTORY

        public List<Item> GetInventoryItems()
        {
            return Inventory;
        }
        
        public void PickupItem<T>(T item) where T : Item
        {
            Inventory.Add(item);
        }
        
        public void PickupItem<T>() where T: Item
        {
            Inventory.Add((T) Activator.CreateInstance(typeof(T)));
        }

        public void DropItem<T>(T item) where T: Item
        {
            Inventory.RemoveAll(x => x.Name == item.Name);
        }
        
        // ROOM

        public void MoveToRoom<T>() where T: Room
        {
            CurrentRoom = (T) Activator.CreateInstance(typeof(T));
        }

        public Room GetCurrentRoom()
        {
            return CurrentRoom;
        }
    }
}