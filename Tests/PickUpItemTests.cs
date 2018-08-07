using DungeonText.Objects;
using DungeonText.Objects.Items;
using Xunit;

namespace DungeonText.Tests
{
    public class when_i_pickup_an_item_without_specifying_the_item
    {
        [Fact]
        public void then_i_pick_up_nothing()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "You try to pickup an item but it's not really there";
                
                gameObjects.Player.GetCurrentRoom().RemoveAllItems();
                
                //execute
                var commandOutput = Command.Get(gameObjects, "pickup");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);
                Assert.Empty(gameObjects.Player.GetInventoryItems());
                Assert.Empty(gameObjects.Player.GetCurrentRoom().GetItems());
            }
        }
    }
    
    public class when_i_pickup_an_item_specifying_the_item
    {
        [Fact]
        public void then_i_pick_up_the_item_and_is_no_longer_in_the_room()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "You pick up potion";

                gameObjects.Player.GetCurrentRoom().RemoveAllItems();
                gameObjects.Player.GetCurrentRoom().AddItem(new Potion());
                gameObjects.Player.GetCurrentRoom().AddItem(new RustySword());
                
                //execute
                var commandOutput = Command.Get(gameObjects, "pickup potion");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);

                Assert.True(gameObjects.Player.GetInventoryItems().Exists(x => x.Name == new Potion().Name));
                Assert.False(gameObjects.Player.GetCurrentRoom().GetItems().Exists(x => x.Name == new Potion().Name));

                Assert.False(gameObjects.Player.GetInventoryItems().Exists(x => x.Name == new RustySword().Name));
                Assert.True(gameObjects.Player.GetCurrentRoom().GetItems().Exists(x => x.Name == new RustySword().Name));
            }
        }
    }
}