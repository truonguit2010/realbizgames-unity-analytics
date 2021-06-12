using System.Collections;

namespace RealbizGames.Analysis
{
    public class ButtonAnalysisDTO : IInteractableNode
    {
        public ButtonAnalysisDTO(string buttonName)
        {
            button_name = buttonName;
        }

        public string button_name { get; set; }

    }
}