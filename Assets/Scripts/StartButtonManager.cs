using System;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    
    private MainMenuManager _mainMenuManager;

    private void Start() {
        _mainMenuManager = GetComponent<MainMenuManager>();
    }
    
    public void PlayButtonOnPress() {
        _mainMenuManager.ButtonOnPress(() => {
            _mainMenuManager.PlayComponentsSetState(true);
            _mainMenuManager.StartComponentsSetState(false);
        });
    }
    
    public void CustomizeButtonOnPress() {
        _mainMenuManager.ButtonOnPress(() => {
            print("Customize");
        });
    }
    
    public void InfoButtonOnPress() {
        _mainMenuManager.ButtonOnPress(() => {
            _mainMenuManager.StartComponentsSetState(false);
            _mainMenuManager.InfoComponentsSetState(true);
        });
    }
    
    public void QuitButtonOnPress() {
        _mainMenuManager.ButtonOnPress(() => {
            print("Quit");
        });
    }
    
    public void BackButtonOnPress() {
        _mainMenuManager.ButtonOnPress(() => {
            _mainMenuManager.PlayComponentsSetState(false);
            _mainMenuManager.InfoComponentsSetState(false);
            _mainMenuManager.StartComponentsSetState(true);
        });
    }
}
