using System.Collections;

namespace RealbizGames.Analysis
{
    /// <summary>
    /// level_start	when a user starts a new level in the game	level_name
    /// </summary>
    public class LevelStartDTO
    {
        public LevelStartDTO(string levelName)
        {
            level_name = levelName;
        }

        public string level_name { get; set; }
    }
}