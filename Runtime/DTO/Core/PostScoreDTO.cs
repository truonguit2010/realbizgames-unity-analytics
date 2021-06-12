using System.Collections;

namespace RealbizGames.Analysis
{
    /// <summary>
    /// post_score	when a player posts his or her score	level, character, score
    /// </summary>
    public class PostScoreDTO
    {
        public PostScoreDTO(string levelName, int score)
        {
            level_name = levelName;
            this.score = score;
        }

        public string level_name { get; set; }

        public int score { get; set; } 
    }
}
