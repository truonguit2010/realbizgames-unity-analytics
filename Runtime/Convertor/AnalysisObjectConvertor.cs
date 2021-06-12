using System.Reflection;
using System.Collections.Generic;

public class AnalysisObjectConvertor
{
    const string NULL_TOKEN = "(null)";
    public static Dictionary<string, string> ToDictionary_string_string(object obj, bool forceLowerCase = true)
    {

        Dictionary<string, string> valuatedDict = new Dictionary<string, string>();

        PropertyInfo[] _PropertyInfos = obj.GetType().GetProperties();
        foreach (var info in _PropertyInfos)
        {
            string name = info.Name;
            if (forceLowerCase)
            {
                name = name.ToLower();
            }
            var value = info.GetValue(obj, null) ?? NULL_TOKEN;
            string valueAsString = value.ToString();

            if (NULL_TOKEN.Equals(valueAsString))
            {
                valuatedDict[name] = null;
            }
            else
            {
                valuatedDict[name] = valueAsString;
            }
        }

        return valuatedDict;
    }

    public static Dictionary<string, object> ToDictionary_string_object(object obj, bool forceLowerCase = true)
    {
        if (obj == null)
        {
            return new Dictionary<string, object>();
        }
        else
        {
            Dictionary<string, object> valuatedDict = new Dictionary<string, object>();
            // BindingFlags.Public | BindingFlags.Instance
            // https://stackoverflow.com/questions/245055/how-do-you-get-the-all-properties-of-a-class-and-its-base-classes-up-the-hierar
            PropertyInfo[] _PropertyInfos = obj.GetType().GetProperties();
            foreach (var info in _PropertyInfos)
            {
                string name = info.Name;
                if (forceLowerCase)
                {
                    name = name.ToLower();
                }
                var value = info.GetValue(obj, null) ?? NULL_TOKEN;
                string valueAsString = value.ToString();

                if (NULL_TOKEN.Equals(valueAsString))
                {
                    valuatedDict[name] = null;
                }
                else
                {
                    valuatedDict[name] = value;
                }
            }

            return valuatedDict;
        }
    }
}
