using System.Collections;

public class UserPropertyServiveImpl : IUserPropertyServive
{
    private IAnalysisRepository firebaseAnalysisRepository = new FirebaseAnalysisRepository();

    public bool Music
    {
        set
        {
            firebaseAnalysisRepository.SetUserProperty("Music", value);
        }
    }
    public bool Sound
    {
        set
        {
            firebaseAnalysisRepository.SetUserProperty("Sound", value);
        }
    }
    public bool Vibration 
    {
        set
        {
            firebaseAnalysisRepository.SetUserProperty("Vibration", value);
        }
    }

    public string ThemeName 
    {
        set
        {
            firebaseAnalysisRepository.SetUserProperty("ThemeName", value);
        }
    }
}
