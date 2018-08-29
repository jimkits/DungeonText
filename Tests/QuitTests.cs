using DungeonText.Objects;
using DungeonText.TestHelpers;
using Xunit;

namespace DungeonText.Tests
{
    public class when_i_type_quit
    {
        [Fact]
        public void i_get_the_help_text()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "You feel your sanity returning to you. You quickly " +
                                      "find your way out of the cave and get back to your life as a farmer.";
                
                var commandOutput = Command.Get(gameObjects, "quit");

                //assert
                Assert.Equal(expectedMessage, CleanText.Run(commandOutput.Output));
            }
        }
    }
}