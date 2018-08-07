using System;
using System.Collections.Generic;
using DungeonText.Objects.Items;

namespace DungeonText.Text
{
    public class Response
    {
        public static string GetIntro()
        {
            return "You are a young farmer from a poor family. One day as you walk in the " +
                   "forest you find the entrance to a cave. Excited, and clearly without " +
                   "thinking, you decide to enter the cave";
        }

        public static string GetHelp()
        {
            return $"--{Environment.NewLine}Commands: search, status, pickup <item>, drop <item>, help, quit";
        }

        public static string GetQuit()
        {
            return $"--{Environment.NewLine}" +
                   "You feel your sanity returning to you. You quickly " +
                   "find your way out of the cave and get back to your life as a farmer.";
        }
        
        public static string GetStatusRoom(string name, string description)
        {
            return $"--{Environment.NewLine}You are in the {name}" +
                   $"{Environment.NewLine}{description}";
        }

        public static string GetStatusEquipped(string weapon)
        {
            return $"{Environment.NewLine}You have a {weapon} equipped";
        }

        public static string GetStatusNothingEquipped()
        {
            return $"{Environment.NewLine}You have no weapon equipped";
        }

        public static string GetStatusInventory(List<Item> inventory)
        {
            var message = $"{Environment.NewLine}You carry in your inventory:";

            for (var count = 0; count < inventory.Count; count++)
            {
                if (count == 0)
                {
                    message += $"{inventory[count].Name}";
                }
                else if (count == inventory.Count)
                {
                    message += $" and {inventory[count].Name}";
                }
                else
                {
                    message += $", {inventory[count].Name}";
                }
            }

            return message;
        }

        public static string GetStatusEmptyInventory()
        {
            return $"{Environment.NewLine}You have nothing in your inventory";
        }

        public static string GetSearch(List<Item> items)
        {
            var numberOfLocationItems = items.Count;
            
            var message = $"--{Environment.NewLine}After searching the room you find:";
            
            for (var count=0; count < numberOfLocationItems; count++)
            {
                if (count == 0)
                {
                    message += $"{items[count].Name}";
                }
                else if (count == numberOfLocationItems)
                {
                    message += $" and {items[count].Name}";
                }
                else
                {
                    message += $", {items[count].Name}";
                }
            }
                    
            return message;
        }

        public static string GetSearchNoItems()
        {
            return "After searching the room you find nothing";
        }

        public static string GetPickupNoSpecifyItem()
        {
            return "You try to pickup an item but it's not really there";
        }

        public static string GetPickup(string item)
        {
            return $"You pick up {item}";
        }

        public static string GetDropNoSpecifyItem()
        {
            return "You open your hand and pretend to drop something";
        }

        public static string GetDrop(string item)
        {
            return $"You drop the {item} in the room";
        }

        public static string GetEquipNoSpecifyItem()
        {
            return "You cannot equip nothing";
        }

        public static string GetEquipCannotEquip()
        {
            return "This item cannot be equipped";
        }

        public static string GetDefault()
        {
            return $"--{Environment.NewLine}" +
                   "Your sanity slowly slips away as you spout gibberish. Try another command";
        }
    }
}