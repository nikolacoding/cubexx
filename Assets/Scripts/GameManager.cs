using UnityEngine;
using UnityEngine.SceneManagement;

public static class GlobalConstants {
    public enum SceneIndices {
        MAINMENU = 0,
        TUTORIAL = 1,
        LEVEL1 = 1
    }
}

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }

    public void LoadMainMenu() {
        // SceneManager.LoadScene((int)GlobalConstants.SceneIndices.MAINMENU);
    }
    
    public void LoadTutorial() {
        SceneManager.LoadScene((int)GlobalConstants.SceneIndices.TUTORIAL);
    }
}
