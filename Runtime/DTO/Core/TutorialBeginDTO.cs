using System.Collections;

namespace RealbizGames.Analysis
{
    public class TutorialBeginDTO
    {
        public TutorialBeginDTO(string tutorial_name)
        {
            this.tutorial_name = tutorial_name;
        }

        public string tutorial_name { get; set; }
    }
}
