using System.Collections;

namespace RealbizGames.Analysis
{
    public class SceneStartDTO
    {
        public SceneStartDTO(string sceneName)
        {
            scene_name = sceneName;
        }

        public string scene_name { get; set; }
    }
}
