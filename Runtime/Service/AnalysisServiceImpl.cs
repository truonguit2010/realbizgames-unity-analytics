using System.Collections.Generic;
using RealbizGames.Analysis;
using UnityEngine;

public class AnalysisServiceImpl : IAnalysisService
{
    const string TAG = "AnalysisServiceImpl";

    private static IAnalysisService _defaultService = new AnalysisServiceImpl();

    public static IAnalysisService DefaultService {
        get {
            return _defaultService;
        }
    }

    private IAnalysisRepository firebase = new FirebaseAnalysisRepository();
    private IAnalysisRepository facebook = new FacebookAnalysisRepository();
    private IAnalysisRepository unity = new UnityAnalysisRepository();
    private IAnalysisRepository appsflyer = new AppsFlyerAnalysisRepository();


    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------
    private string convertCoreEventName(RealbizGames.Analysis.CoreEventName coreEventName) {
        return coreEventName.ToString().ToLower();
    }

    public void internalTrack(string eventName, object data, bool forceLowerCase = true)
    {
        Dictionary<string, object> parameters = AnalysisObjectConvertor.ToDictionary_string_object(data, forceLowerCase: forceLowerCase);

        if (forceLowerCase) {
            eventName = eventName.ToLower();
        }
#if UNITY_EDITOR
        string logParam = dictionaryToString(parameters);
        Debug.LogFormat("{0} - doTrackingImplement {1}: \n{2}", TAG, eventName, logParam);
#endif

        firebase.track(eventName, parameters);
        facebook.track(eventName, parameters);
        unity.track(eventName, parameters);
        appsflyer.track(eventName, parameters);
    }

    private string dictionaryToString(Dictionary<string, object> parameters)
    {
        string logParam = "";
        foreach (KeyValuePair<string, object> kvp in parameters)
        {
            logParam += string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value) + "\n";
        }

        if (string.IsNullOrEmpty(logParam))
        {
            logParam = "empty params";
        }

        return logParam;
    }
    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------

    public void Dialog_End(DialogEndDTO dto)
    {
        internalTrack(CoreEventName.Dialog_End.ToString(), dto);
    }

    public void Dialog_Start(DialogStartDTO dto)
    {
        internalTrack(CoreEventName.Dialog_Start.ToString(), dto);
    }

    public void Level_End(LevelEndDTO dto)
    {
        internalTrack(CoreEventName.Level_End.ToString(), dto);
    }

    public void Level_Start(LevelStartDTO dto)
    {
        internalTrack(CoreEventName.Level_Start.ToString(), dto);
    }

    public void PostScore(PostScoreDTO dto)
    {
        internalTrack(CoreEventName.Post_Score.ToString(), dto);
    }

    public void Scene_End(SceneEndDTO dto)
    {
        internalTrack(CoreEventName.Scene_End.ToString(), dto);
    }

    public void Scene_Start(SceneStartDTO dto)
    {
        internalTrack(CoreEventName.Scene_Start.ToString(), dto);
    }

    public void SelectTheme(SellectThemeDTO dto)
    {
        internalTrack(CoreEventName.Select_Theme.ToString(), dto);
    }

    public void track(string eventName, object data)
    {
        internalTrack(eventName, data, forceLowerCase: false);
    }

    public void Tutorial_Begin(TutorialBeginDTO dto)
    {
        internalTrack(CoreEventName.Tutorial_Begin.ToString(), dto);
    }

    public void Tutorial_Complete(TutorialCompleteDTO dto)
    {
        internalTrack(CoreEventName.Tutorial_Complete.ToString(), dto);
    }

    public void Button_Click(ButtonAnalysisDTO dto)
    {
        internalTrack(CoreEventName.Button_Click.ToString(), dto);
    }

    public void TrackException(ExceptionAnalysisDTO dto)
    {
        internalTrack(CoreEventName.Track_Exception.ToString(), dto);
    }
}
