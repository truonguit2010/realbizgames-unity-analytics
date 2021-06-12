using UnityEngine;

namespace RealbizGames.Analysis
{
    [DisallowMultipleComponent]
    public class DialogAnalysisBehaviour : MonoBehaviour
    {
        [SerializeField]
        private string _dialogName;

        public string DialogName {
            get {
                if (string.IsNullOrEmpty(_dialogName)) {
                    _dialogName = this.name;
                }
                return _dialogName;
            }
        }

        private float _timeBoundSeconds = 0;

        private void OnEnable() {
            dialogStart();
        }

        private void OnDisable() {
            dialogEnd();
        }

        void Update()
        {
            _timeBoundSeconds += Time.deltaTime;
        }

        private void dialogStart() {
            _timeBoundSeconds = 0;

            RealbizGames.Analysis.DialogStartDTO dto = new RealbizGames.Analysis.DialogStartDTO(DialogName);
            RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Dialog_Start(dto);
        }

        private void dialogEnd() {
            RealbizGames.Analysis.DialogEndDTO dto = new RealbizGames.Analysis.DialogEndDTO(DialogName, _timeBoundSeconds);
            RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Dialog_End(dto);
        }
    }
}
