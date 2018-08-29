using DungeonText.Objects;
using DungeonText.TestHelpers;
using DungeonText.Text;
using Xunit;

namespace DungeonText.Tests
{
    public class when_i_type_help
    {
        [Fact]
        public void i_get_the_help_text()
        {
            using (var gameObjects = new GameObjects())
            {
                //prepare
                var expectedMessage = "Commands: search, status, pickup <item>, drop <item>, help, quit";
                    
                //execute
                var commandOutput = Command.Get(gameObjects, "help");

                //assert
                Assert.Equal(expectedMessage, CleanText.Run(commandOutput.Output));
            }
        }
    }
}