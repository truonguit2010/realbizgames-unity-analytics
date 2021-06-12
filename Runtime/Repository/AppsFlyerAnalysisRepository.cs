using System.Collections.Generic;

/// <summary>
/// https://www.appsflyer.com/product/mobile-app-analytics/
/// </summary>
public class AppsFlyerAnalysisRepository : IAnalysisRepository
{
    public void SetUserProperty(string key, object value)
    {
        
    }

    public void track(string eventName, Dictionary<string, object> data)
    {
        #if USING_ANALYSIS_APPSFLYER
        Dictionary<string, string> valuatedData = RealbizGames.Analysis.Utils.ConvertDictionary(data);
        AppsFlyerSDK.AppsFlyer.sendEvent(eventName, valuatedData);
        #endif
    }
}
