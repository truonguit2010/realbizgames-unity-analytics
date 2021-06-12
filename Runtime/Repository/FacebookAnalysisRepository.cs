using System.Collections.Generic;

public class FacebookAnalysisRepository : IAnalysisRepository
{
    public void SetUserProperty(string key, object value)
    {
        
    }

    public void track(string eventName, Dictionary<string, object> data)
    {
        #if USING_ANALYSIS_FACEBOOK
        if (Facebook.Unity.FB.IsInitialized) {
            Facebook.Unity.FB.LogAppEvent(logEvent: eventName, valueToSum: 1f, parameters: data);
        }
        #endif
    }
}
