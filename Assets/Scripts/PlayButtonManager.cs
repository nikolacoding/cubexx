using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonManager : MonoBehaviour {
    private MainMenuManager _mainMenuManager;

    private void Start() {
        _mainMenuManager = GetComponent<MainMenuManager>();
    }

    public void Level0ButtonOnPress() {
        _mainMenuManager.ButtonOnPress(() => {
            GameManager.Instance.LoadTutorial();
        });
    }
    
    public void Level1ButtonOnPress() {
        _mainMenuManager.ButtonOnPress(() => {
            
        });
    }
}
