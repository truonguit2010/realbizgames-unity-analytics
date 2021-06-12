using UnityEngine;
using UnityEngine.UI;

namespace RealbizGames.Analysis
{
    [RequireComponent(typeof(Button))]
    [DisallowMultipleComponent]
    public class ButtonAnalysisBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private string _buttonName;

        public string ButtonName {
            get {
                if (string.IsNullOrEmpty(_buttonName) || string.IsNullOrWhiteSpace(_buttonName)) {
                    _buttonName = GetHierarchyPath(this.transform);
                }
                return _buttonName;
            }
        }

        public Button MyButton
        {
            get
            {
                if (_button == null)
                {
                    _button = GetComponent<Button>();
                }
                return _button;
            }
        }

        void Start()
        {
            MyButton.onClick.AddListener(onButtonClicked);
        }

        private void onButtonClicked()
        {
            RealbizGames.Analysis.ButtonAnalysisDTO dto = new RealbizGames.Analysis.ButtonAnalysisDTO(ButtonName);
            RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Button_Click(dto);
        }

        public string GetHierarchyPath(Transform self)
        {
            string path = self.gameObject.name;
            Transform p = self.parent;
            while (p != null)
            {
                path = p.name + "/" + path;
                p = p.parent;
            }
            return path;
        }

    }
}
