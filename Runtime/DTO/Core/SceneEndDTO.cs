using System.Collections;

namespace RealbizGames.Analysis
{
    public class SceneEndDTO
    {
        public SceneEndDTO(string sceneName, float timeBoundSeconds)
        {
            scene_name = sceneName;
            time_bound_seconds = timeBoundSeconds;
        }

        public string scene_name { get; set; }

        public float time_bound_seconds { get; set; }
    }
}
