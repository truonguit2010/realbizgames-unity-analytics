using System.Collections.Generic;

/// <summary>
/// https://docs.unity3d.com/Manual/UnityAnalytics.html
/// </summary>
public class UnityAnalysisRepository : IAnalysisRepository
{
    public void SetUserProperty(string key, object value)
    {
        
    }

    public void track(string eventName, Dictionary<string, object> data)
    {
        #if USING_ANALYSIS_UNITY
        UnityEngine.Analytics.Analytics.CustomEvent(eventName, eventData: data);
        #endif
    }
}
