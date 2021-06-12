using UnityEngine;

namespace RealbizGames.Analysis
{
    [DisallowMultipleComponent]
    public class SceneAnalysisBehavior : MonoBehaviour
    {
        [SerializeField]
        private string _sceneName;

        public string SceneName {
            get {
                if (string.IsNullOrEmpty(_sceneName)) {
                    _sceneName = this.name;
                }
                return _sceneName;
            }
        }

        private float _timeBoundSeconds = 0;

        private void OnEnable() {
            sceneStart();
        }

        private void OnDisable() {
            sceneEnd();
        }

        void Update()
        {
            _timeBoundSeconds += Time.deltaTime;
        }

        private void sceneStart() {
            _timeBoundSeconds = 0;

            RealbizGames.Analysis.SceneStartDTO dto = new RealbizGames.Analysis.SceneStartDTO(SceneName);
            RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Scene_Start(dto);
        }

        private void sceneEnd() {
            RealbizGames.Analysis.SceneEndDTO dto = new RealbizGames.Analysis.SceneEndDTO(SceneName, _timeBoundSeconds);
            RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Scene_End(dto);
        }
        
    }

}