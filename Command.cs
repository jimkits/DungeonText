using System.Collections.Generic;
using DungeonText.Helpers;
using DungeonText.Objects;
using DungeonText.Objects.Enums;
using DungeonText.Objects.Items;
using DungeonText.Text;

namespace DungeonText
{
    public static class Command
    {   
        public static CommandOutput Get(GameObjects pageObjects, string text)
        {
            var commandOutput = new CommandOutput();
            
            var command = GetCommand(text);
            var item = GetItem(pageObjects.AllItems, command, text);
            
            switch (Translate.Command(command))
            {
                case Commands.Intro:
                    commandOutput.ContinueAdventure = true;
                    
                    commandOutput.Output = Response.GetIntro();
                    break;
                case Commands.Help:
                    commandOutput.ContinueAdventure = true;
                    
                    commandOutput.Output = Response.GetHelp();
                    break;
                case Commands.Quit:
                    commandOutput.ContinueAdventure = false;
                    
                    commandOutput.Output = Response.GetQuit();
                    break;
                case Commands.Status:
                    commandOutput.ContinueAdventure = true;

                    var currentRoom = pageObjects.Player.GetCurrentRoom();
                    commandOutput.Output = Response.GetStatusRoom(currentRoom.Name, currentRoom.Description);

                    var equippedWeapon = pageObjects.Player.GetEquippedWeapon();
                    if (equippedWeapon == null)
                    {
                        commandOutput.Output += Response.GetStatusNothingEquipped();
                    }
                    else
                    {
                        commandOutput.Output += Response.GetStatusEquipped(equippedWeapon.Name);
                    }

                    var inventory = pageObjects.Player.GetInventoryItems();
                    if (inventory.Count < 1)
                    {
                        commandOutput.Output += Response.GetStatusEmptyInventory();
                    }
                    else
                    {
                        commandOutput.Output += Response.GetStatusInventory(inventory);
                    }

                    break;
                case Commands.Search:
                    commandOutput.ContinueAdventure = true;

                    var itemList = pageObjects.Player.GetCurrentRoom().GetItems();
                    if (itemList.Count < 1)
                    {
                        commandOutput.Output = Response.GetSearchNoItems();
                    }
                    else
                    {
                        commandOutput.Output = Response.GetSearch(itemList);
                    }
                    break;
                case Commands.Pickup:
                    commandOutput.ContinueAdventure = true;
                    
                    itemList = pageObjects.Player.GetCurrentRoom().GetItems();
                    
                    if (item != null && itemList.Count > 0 && itemList.Exists(x => x.Name == item.Name))
                    {
                        pageObjects.Player.PickupItem(item);
                        pageObjects.Player.GetCurrentRoom().RemoveItem(item);
                        
                        commandOutput.Output = Response.GetPickup(item.Name);
                    }
                    else
                    {
                        commandOutput.Output = Response.GetPickupNoSpecifyItem();
                    }
                    break;
                case Commands.Drop:
                    commandOutput.ContinueAdventure = true;
                    
                    itemList = pageObjects.Player.GetInventoryItems();
                    
                    if (item != null && itemList.Count > 0 && itemList.Exists(x => x.Name == item.Name))
                    {
                        pageObjects.Player.DropItem(item);
                        pageObjects.Player.GetCurrentRoom().AddItem(item);
                        
                        commandOutput.Output = Response.GetDrop(item.Name);
                    }
                    else
                    {
                        commandOutput.Output = Response.GetDropNoSpecifyItem();
                    }
                    break;
                case Commands.Equip:
                    commandOutput.ContinueAdventure = true;
                    if (item == null)
                    {
                        commandOutput.Output = Response.GetEquipNoSpecifyItem();
                    }
                    else
                    {
                        //if (pageObjects.Player.Inventory.Count > 0 && pageObjects.Player.Inventory.Contains(items))
                        //{   
                        //}
                        //else
                        //{
                        //    commandOutput.Output = Response.GetEquipCannotEquip();
                        //}
                    }
                    break;
                default:
                    commandOutput.ContinueAdventure = true;
                    commandOutput.Output = Response.GetDefault();
                    break;
            }

            return commandOutput;
        }
        
        private static string GetCommand(string text)
        {
            if (text.Contains(" "))
            {
                return text.Split(' ')[0];
            }

            return text;
        }

        private static Item GetItem(List<Item> allItems, string command, string text)
        {
            var item = text.Replace($"{command}", "").TrimStart();

            foreach (var itemInList in allItems)
            {
                if (itemInList.Name.ToLower() == item.ToLower())
                {
                    return itemInList;
                }
            }

            return null;
        }
    }
}