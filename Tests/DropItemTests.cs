using DungeonText.Objects;
using DungeonText.Objects.Items;
using Xunit;

namespace DungeonText.Tests
{
    public class when_i_drop_an_item_without_specifying_the_item
    {
        [Fact]
        public void then_i_drop_nothing()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "You open your hand and pretend to drop something";
                
                gameObjects.Player.GetCurrentRoom().RemoveAllItems();
                
                gameObjects.Player.PickupItem<Potion>();

                //execute
                var commandOutput = Command.Get(gameObjects, "drop");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);
                Assert.True(gameObjects.Player.GetInventoryItems().Exists(x => x.Name == new Potion().Name));
                Assert.False(gameObjects.Player.GetCurrentRoom().GetItems().Exists(x => x.Name == new Potion().Name));
            }
        }
    }
    
    public class when_i_drop_an_item_specifying_multiple_items
    {
        [Fact]
        public void then_i_fail_to_drop_the_items()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "You open your hand and pretend to drop something";

                gameObjects.Player.GetCurrentRoom().RemoveAllItems();
                
                gameObjects.Player.PickupItem<Potion>();
                gameObjects.Player.PickupItem<RustySword>();

                //execute
                var commandOutput = Command.Get(gameObjects, "drop potion rusty sword");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);
                Assert.True(gameObjects.Player.GetInventoryItems().Exists(x => x.Name == new Potion().Name));
                Assert.False(gameObjects.Player.GetCurrentRoom().GetItems().Exists(x => x.Name == new Potion().Name));
                
                Assert.True(gameObjects.Player.GetInventoryItems().Exists(x => x.Name == new RustySword().Name));
                Assert.False(gameObjects.Player.GetCurrentRoom().GetItems().Exists(x => x.Name == new RustySword().Name));
            }
        }
    }
    
    public class when_i_drop_an_item_specifying_the_item
    {
        [Fact]
        public void then_i_drop_the_item_and_is_no_longer_in_the_room()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "You drop the potion in the room";

                gameObjects.Player.GetCurrentRoom().RemoveAllItems();
                
                gameObjects.Player.PickupItem<Potion>();
                gameObjects.Player.PickupItem<RustySword>();

                //execute
                var commandOutput = Command.Get(gameObjects, "drop potion");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);
                Assert.False(gameObjects.Player.GetInventoryItems().Exists(x => x.Name == new Potion().Name));
                Assert.True(gameObjects.Player.GetCurrentRoom().GetItems().Exists(x => x.Name == new Potion().Name));
                
                Assert.True(gameObjects.Player.GetInventoryItems().Exists(x => x.Name == new RustySword().Name));
                Assert.False(gameObjects.Player.GetCurrentRoom().GetItems().Exists(x => x.Name == new RustySword().Name));
            }
        }
    }
}