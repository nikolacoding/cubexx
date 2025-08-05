using UnityEngine;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private Vector3 cameraRotation;

    private PlayerPhysics _playerPhysics;
    private void Start() {
        _playerPhysics = GetComponent<PlayerPhysics>();
    }
    private void Update() {
        playerCamera.transform.position = transform.position + cameraOffset;
        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);

        if (Input.GetKey(KeyCode.A)) 
            _playerPhysics.ApplySidewaysMomentum(-1);

        if (Input.GetKey(KeyCode.D)) 
            _playerPhysics.ApplySidewaysMomentum(1);

        if (Input.GetKey(KeyCode.Space)) {
            _playerPhysics.CancelStrafe();
        }
    }
}
