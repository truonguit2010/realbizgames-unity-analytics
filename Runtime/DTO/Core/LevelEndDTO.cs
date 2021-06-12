using System.Collections;

namespace RealbizGames.Analysis
{
    /// <summary>
    /// level_end	when a user completes a level in the game	level_name, success
    /// </summary>
    public class LevelEndDTO
    {
        public LevelEndDTO(string levelName, bool success, float timeBoundSeconds)
        {
            level_name = levelName;
            this.success = success;
            time_bound_seconds = timeBoundSeconds;
        }

        public string level_name { get; set; }

        public bool success { get; set; } 

        public float time_bound_seconds { get; set; }
    }
}
