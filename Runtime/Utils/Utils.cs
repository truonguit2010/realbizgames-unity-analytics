using System.Collections.Generic;

namespace RealbizGames.Analysis
{
    public class Utils
    {
        /// <summary>
        /// Convert Dictionary<string, object> into Dictionary<string, string>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ConvertDictionary(Dictionary<string, object> parameters) {
            Dictionary<string, string> stringDict = new Dictionary<string, string>();

            foreach (var pair in parameters)
            {
                stringDict[pair.Key] = pair.Value.ToString();
            }

            return stringDict;
        }
    }
}

