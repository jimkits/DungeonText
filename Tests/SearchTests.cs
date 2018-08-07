using System.Collections.Generic;
using DungeonText.Objects;
using DungeonText.Objects.Items;
using Xunit;

namespace DungeonText.Tests
{
    public class when_the_room_has_no_item_and_i_search_the_room
    {
        [Fact]
        public void i_get_no_items_back()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "After searching the room you find nothing";

                gameObjects.Player.GetCurrentRoom().RemoveAllItems();
                    
                //execute
                var commandOutput = Command.Get(gameObjects, "search");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);
            }
        }
    }
    
    public class when_the_room_has_items_and_i_search_the_room
    {
        [Fact]
        public void i_get_the_items_back()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "--\nAfter searching the room you find:potion, rusty sword";

                gameObjects.Player.GetCurrentRoom().RemoveAllItems();
                gameObjects.Player.GetCurrentRoom().AddItem(new Potion());
                gameObjects.Player.GetCurrentRoom().AddItem(new RustySword());
                
                //execute
                var commandOutput = Command.Get(gameObjects, "search");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);
            }
        }
    }
}