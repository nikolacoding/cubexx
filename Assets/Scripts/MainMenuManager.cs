using System;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {
    public List<GameObject> startComponents;
    public List<GameObject> playComponents;
    public List<GameObject> customizeComponents;
    public List<GameObject> infoComponents;

    private void SetDefaultState() {
        SetState(startComponents, true);
        SetState(playComponents, false);
        SetState(customizeComponents, false);
        SetState(infoComponents, false);
    }

    private void Start() {
        SetDefaultState();
    }
    
    private void SetState(List<GameObject> componentList, bool state) {
        foreach (var item in componentList)
            item.SetActive(state);
    }

    public void StartComponentsSetState(bool state) => SetState(startComponents, state);

    public void PlayComponentsSetState(bool state) => SetState(playComponents, state);

    public void CustomizeComponentsSetState(bool state) => SetState(customizeComponents, state);
    
    public void InfoComponentsSetState(bool state) => SetState(infoComponents, state);

    public void ButtonOnPress(Action action) {
        AudioManager.Instance.PlayButtonPressSound();
        action();
    }
}
