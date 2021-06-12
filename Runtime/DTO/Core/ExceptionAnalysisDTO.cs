using System.Collections;

namespace RealbizGames.Analysis
{
    public class ExceptionAnalysisDTO
    {
        public ExceptionAnalysisDTO(int errorCode, string errorMessage)
        {
            error_code = errorCode;
            error_message = errorMessage;
        }

        public int error_code { get; set; }

        public string error_message { get; set; }
    }
}