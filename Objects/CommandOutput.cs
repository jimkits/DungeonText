namespace DungeonText.Objects
{
    public class CommandOutput
    {
        public CommandOutput()
        {
            Output = "intro";
            ContinueAdventure = true;
        }
        
        public string Output { get; set; }
        public bool ContinueAdventure { get; set; }
    }
}