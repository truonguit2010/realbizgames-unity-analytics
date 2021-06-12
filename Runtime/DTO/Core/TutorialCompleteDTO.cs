using System.Collections;

namespace RealbizGames.Analysis
{
    public class TutorialCompleteDTO
    {
        public TutorialCompleteDTO(string tutorial_name,int timeBoundSeconds)
        {
            this.tutorial_name = tutorial_name;
            time_bound_seconds = timeBoundSeconds;
        }

        public string tutorial_name { get; set; }

        /// <summary>
        /// From [start, end] the tutorial. Should calcuate it in Update()
        /// </summary>
        /// <value></value>
        public int time_bound_seconds { get; set; }
    }

}
