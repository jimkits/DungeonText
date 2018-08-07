using DungeonText.Objects;
using DungeonText.Text;
using Xunit;

namespace DungeonText.Tests
{
    public class when_i_type_intro
    {
        [Fact]
        public void i_get_the_intro_text()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "You are a young farmer from a poor family. One day as you walk in the " +
                                      "forest you find the entrance to a cave. Excited, and clearly without " +
                                      "thinking, you decide to enter the cave";
                
                //execute
                var commandOutput = Command.Get(gameObjects, "intro");

                //assert
                Assert.Equal(expectedMessage, commandOutput.Output);
            }
        }
    }
}