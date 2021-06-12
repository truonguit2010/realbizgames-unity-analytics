using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnalysisRepository 
{
    void track(string eventName, Dictionary<string, object> data);

    void SetUserProperty(string key, object value);
}
