namespace DungeonText.TestHelpers
{
    public class CleanText
    {
        public static string Run(string text)
        {
            return text.Replace("--","").Replace("\n", "").Replace("\r", "");
        }
    }
}
