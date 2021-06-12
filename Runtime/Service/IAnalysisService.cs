using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://xuanthulab.net/su-dung-attribute-annotation-trong-lap-trinh-c-csharp.html
/// 
/// https://support.google.com/firebase/answer/9267565?hl=en
/// </summary>
public interface IAnalysisService
{
    void track(string eventName, object data);

    void Level_Start(RealbizGames.Analysis.LevelStartDTO dto);
    void Level_End(RealbizGames.Analysis.LevelEndDTO dto);
    // void Level_Up();
    void PostScore(RealbizGames.Analysis.PostScoreDTO dto);
    void SelectTheme(RealbizGames.Analysis.SellectThemeDTO dto);
    void Tutorial_Begin(RealbizGames.Analysis.TutorialBeginDTO dto);
    void Tutorial_Complete(RealbizGames.Analysis.TutorialCompleteDTO dto);
    // void Achievement_Unlock();
    // void VirtualCurrency_Earn();
    // void VirtualCurrency_Spend();

    void Scene_Start(RealbizGames.Analysis.SceneStartDTO dto);
    void Scene_End(RealbizGames.Analysis.SceneEndDTO dto);

    void Dialog_Start(RealbizGames.Analysis.DialogStartDTO dto);
    void Dialog_End(RealbizGames.Analysis.DialogEndDTO dto);

    void Button_Click(RealbizGames.Analysis.ButtonAnalysisDTO dto);

    void TrackException(RealbizGames.Analysis.ExceptionAnalysisDTO dto);

//     earn_virtual_currency	when a user has earned virtual currency (coins, gems, tokens, etc.)	virtual_currency_name, value
// join_group	when a user joins a group. Allows you to track the popularity of various clans or user groups	group_id
// level_end	when a user completes a level in the game	level_name, success
// level_start	when a user starts a new level in the game	level_name
// level_up	when a player levels-up in the game	character, level
// post_score	when a player posts his or her score	level, character, score
// select_content	when a user has selected content	content_type, item_id
// spend_virtual_currency	when a user has spent virtual currency (coins, gems, tokens, etc.)	item_name, virtual_currency_name, value
// tutorial_begin	when a user begins a tutorial	No parameters
// tutorial_complete	when a user completes a tutorial	No parameters
// unlock_achievement	when a player unlocks an achievement	achievement_id
}
