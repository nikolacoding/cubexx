using System;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour{
    [SerializeField] private GameObject playerObject;
    private Rigidbody _playerRigidbody;
    
    [SerializeField] private bool debugEnabled;
    [SerializeField] private TextMeshProUGUI debugText;

    void Start() {
        if (playerObject == null)
            throw new NullReferenceException("playerObject hasn't been defined in GameUIManager.");
        _playerRigidbody = playerObject.GetComponent<Rigidbody>();
    }
    
    private void UpdateDebug() {
        debugText.enabled = debugEnabled;
        debugText.text = $"Velocity:\n" +
                         $"x: {Math.Round(_playerRigidbody.linearVelocity.x, 2)}\n" +
                         $"y: {Math.Round(_playerRigidbody.linearVelocity.y, 2)}\n" +
                         $"z: {Math.Round(_playerRigidbody.linearVelocity.z, 2)}\n";
;    }
    
    private void Update() {
        UpdateDebug();
    }
}
