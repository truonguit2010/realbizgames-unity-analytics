using System.Collections;

namespace RealbizGames.Analysis
{
    public class DialogEndDTO
    {
        public DialogEndDTO(string dialogName, float timeBoundSeconds)
        {
            dialog_name = dialogName;
            time_bound_seconds = timeBoundSeconds;
        }

        public string dialog_name { get; set; }

        public float time_bound_seconds { get; set; }
    }
}