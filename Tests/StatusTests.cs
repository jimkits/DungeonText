using DungeonText.Objects;
using DungeonText.Objects.Items;
using Xunit;

namespace DungeonText.Tests
{
    public class when_i_have_a_weapon_and_item_and_i_get_the_status
    {
        [Fact]
        public void i_get_the_location_weapon_and_inventory_items()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "--\nYou are in the Entrance\nThis is the entrance of the cave.\n" +
                                      "You entered from the door to the south. There is an entrance to the north" +
                                      "\nYou have a rusty sword equipped\nYou carry in your inventory:potion";
                
                gameObjects.Player.EquipWeapon<RustySword>();
                gameObjects.Player.PickupItem<Potion>();
                
                //execute
                var commandOutput = Command.Get(gameObjects, "status");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);
            }
        }
    }
    
    public class when_i_have_no_weapon_and_no_item_and_i_get_the_status
    {
        [Fact]
        public void i_get_the_location_weapon_and_inventory_items()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "--\nYou are in the Entrance\nThis is the entrance of the cave.\n" +
                                      "You entered from the door to the south. There is an entrance to the north" +
                                      "\nYou have no weapon equipped\nYou have nothing in your inventory";
                
                //execute
                var commandOutput = Command.Get(gameObjects, "status");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);
            }
        }
    }
}