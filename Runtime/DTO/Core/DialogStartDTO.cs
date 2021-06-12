using System.Collections;

namespace RealbizGames.Analysis
{
    public class DialogStartDTO
    {
        public DialogStartDTO(string dialogName)
        {
            this.dialog_name = dialogName;
        }

        public string dialog_name { get; set; }
    }
}
