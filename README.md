# I. Introduction

## 1. Goals
1. Centralize Analytics Logic.
2. Easy to hire developer to develop games, they don't care about 3rd-party Analytics SDKs.
3. Easy to us for Enable/Disable 3rd-party SDK. Just use [Script Define Symbols](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html)
4. Easy to add more 3rd-party SDK when we need more. Just implement in Reposotory-Layer. => We do not depend on Game Developer.

## 2. How does it works?
1. The Core of the Game use one easy API to record events and user's properties.
2. The Analysis Core send them (events + properties) to many 3rd-party that is desired.

![Overview Image](Images~/RealBizGames_Analysis.png)

## 3. How to achieve it?
- Using [Clean Architure](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

# II. Analysis

## 1. User Behavior Analysis

### 1.1 Definitions
1. Node: A node is an interactable component on the Game Scene. It can be a Button, an Image, a Lable, etc.
2. Edge: It is an ***Transition*** from a ***Node*** to ***Another Node***. An Edge will contains 3 parameters:

```
{
  "node": "The current node-name",
  "src": "The source that the user interact before",
  "time_bound": "miliseconds - the time moving between [src, node]"
}
```
### 1.2 Implementation
1. Add ***ButtonAnalysisBehaviour*** into your Button in the Game Scene
2. Or implment the below code in your custom function

```
private void onButtonClicked()
{
    RealbizGames.Analysis.ButtonAnalysisDTO dto = new RealbizGames.Analysis.ButtonAnalysisDTO(ButtonName);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Button_Click(dto);
}
```
## 2. Game Flow Analysis

### 2.1 Scene Flow Analysis
Please attack our script SceneAnalysisBehavior into target Scene or a Layer of the Scene for Auto-Tracking. Or manual implement below code if you want.

```
private void sceneStart() {
    _timeBoundSeconds = 0;

    RealbizGames.Analysis.SceneStartDTO dto = new RealbizGames.Analysis.SceneStartDTO(SceneName);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Scene_Start(dto);
}
```
And, when the scene-end, please call:
```
private void sceneEnd() {
    RealbizGames.Analysis.SceneEndDTO dto = new RealbizGames.Analysis.SceneEndDTO(SceneName, _timeBoundSeconds);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Scene_End(dto);
}
```
### 2.2 Dialog Flow Analysis
The same with "Scene Flow Analysis", You must to call 2 functions like it.
```
private void dialogStart() {
    _timeBoundSeconds = 0;

    RealbizGames.Analysis.DialogStartDTO dto = new RealbizGames.Analysis.DialogStartDTO(DialogName);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Dialog_Start(dto);
}
```
And when the dialog hide, We have to call:
```
private void dialogEnd() {
    RealbizGames.Analysis.DialogEndDTO dto = new RealbizGames.Analysis.DialogEndDTO(DialogName, _timeBoundSeconds);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Dialog_End(dto);
}
```
The variable ***_timeBoundSeconds***, it must be count in ***Update()*** function. Like the code below.
```
void Update()
{
    _timeBoundSeconds += Time.deltaTime;
}
```
### 2.3 Tutorial Flow Analysis
```
private void tutorialBegin() {
    _timeBoundSeconds = 0;

    RealbizGames.Analysis.TutorialBeginDTO dto = new RealbizGames.Analysis.TutorialBeginDTO(TutorialName);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Tutorial_Begin(dto);
}
```

```
private void tutorialComplete() {
    RealbizGames.Analysis.TutorialCompleteDTO dto = new RealbizGames.Analysis.TutorialCompleteDTO(TutorialName, _timeBoundSeconds);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Tutorial_Complete(dto);
}
```
### 2.4 Level Flow Analysis
```
private void levelStart() {
    _timeBoundSeconds = 0;

    RealbizGames.Analysis.LevelStartDTO dto = new RealbizGames.Analysis.LevelStartDTO(LevelName);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Level_Start(dto);
}
```

```
private void levelEnd() {
    RealbizGames.Analysis.LevelEndDTO dto = new RealbizGames.Analysis.LevelEndDTO(LevelName, success: true, _timeBoundSeconds);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.Level_End(dto);
}
```

```
private void postScore(string levelName, int score) {
    RealbizGames.Analysis.PostScoreDTO dto = new RealbizGames.Analysis.PostScoreDTO(levelName: levelName, score: score);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.PostScore(dto);
}
```
### 2.5 Content Analysis
```
private void selectTheme(string themeNam) {
    RealbizGames.Analysis.SellectThemeDTO dto = new RealbizGames.Analysis.SellectThemeDTO(themeName: themeNam);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.SelectTheme(dto);
}
```
### 2.6 Well-known Exception
```
private void TrackError(int errorCode, string errorMessage) {
    RealbizGames.Analysis.ExceptionAnalysisDTO dto = new RealbizGames.Analysis.ExceptionAnalysisDTO(errorCode, errorMessage);
    RealbizGames.Analysis.AnalysisInstance.Instance.AnalysisService.TrackException(dto);
}
```

# III. Support 3rd-party.
1. Firebase USING_ANALYSIS_FIREBASE
2. Facebook USING_ANALYSIS_FACEBOOK
3. Appslfyer USING_ANALYSIS_APPSFLYER
4. Unity USING_ANALYSIS_UNITY

For use all of them, please use: USING_ANALYSIS_FIREBASE;USING_ANALYSIS_FACEBOOK;USING_ANALYSIS_APPSFLYER;USING_ANALYSIS_UNITY

Apply Clean Architecture, design Scalable Analytics Tool Supplier.
