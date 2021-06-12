using System.Collections.Generic;

public class FirebaseAnalysisRepository : IAnalysisRepository
{
    public void SetUserProperty(string key, object value)
    {
        #if USING_ANALYSIS_FIREBASE
        Firebase.Analytics.FirebaseAnalytics.SetUserProperty(key, value.ToString());
        #endif
    }

    public void track(string eventName, Dictionary<string, object> data)
    {
        #if USING_ANALYSIS_FIREBASE
        List<Firebase.Analytics.Parameter> firebaseParameters = new List<Firebase.Analytics.Parameter>();
        foreach (var pair in data)
        {
            if (pair.Value is long)
            {
                firebaseParameters.Add(new Firebase.Analytics.Parameter(pair.Key, (long)pair.Value));
            }
            else if (pair.Value is double)
            {
                firebaseParameters.Add(new Firebase.Analytics.Parameter(pair.Key, (double)pair.Value));
            }
            else
            {
                firebaseParameters.Add(new Firebase.Analytics.Parameter(pair.Key, pair.Value.ToString()));
            }
        }

        Firebase.Analytics.FirebaseAnalytics.LogEvent(eventName, firebaseParameters.ToArray());
        #endif
    }

}
