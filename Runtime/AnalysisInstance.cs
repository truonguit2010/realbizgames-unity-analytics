using UnityEngine;

namespace RealbizGames.Analysis
{
    public class AnalysisInstance : IAnalysisService
    {
        public static readonly AnalysisInstance Instance = new AnalysisInstance();


        private IAnalysisService analysisService = new AnalysisServiceImpl();

        public IAnalysisService AnalysisService {
            get {
                return analysisService;
            }
        }

        private IUserPropertyServive _userProperty = new UserPropertyServiveImpl();

        public IUserPropertyServive UserProperty {
            get {
                return _userProperty;
            }
        }

        public void track(string eventName, object data = null)
        {
            analysisService.track(eventName, data);
        }

        public void Level_Start(LevelStartDTO dto)
        {
            analysisService.Level_Start(dto);
        }

        public void Level_End(LevelEndDTO dto)
        {
            analysisService.Level_End(dto);
        }

        public void PostScore(PostScoreDTO dto)
        {
            analysisService.PostScore(dto);
        }

        public void Tutorial_Begin(TutorialBeginDTO dto)
        {
            analysisService.Tutorial_Begin(dto);
        }

        public void Tutorial_Complete(TutorialCompleteDTO dto)
        {
            analysisService.Tutorial_Complete(dto);
        }

        public void SelectTheme(SellectThemeDTO dto)
        {
            analysisService.SelectTheme(dto);
        }

        public void Scene_Start(SceneStartDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public void Scene_End(SceneEndDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public void Dialog_Start(DialogStartDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public void Dialog_End(DialogEndDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public void Button_Click(ButtonAnalysisDTO dto)
        {
            analysisService.Button_Click(dto);
        }

        public void TrackException(ExceptionAnalysisDTO dto)
        {
            analysisService.TrackException(dto);
        }
    }

}
