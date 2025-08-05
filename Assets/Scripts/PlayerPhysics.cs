using System;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.Serialization;
using Math = System.Math;

[RequireComponent(typeof(Rigidbody))]
public class PlayerPhysics : MonoBehaviour{
    private Rigidbody _rb;
    [SerializeField] private float forwardForcePerFrame;
    [SerializeField] private float forwardVelocityBound;
    [FormerlySerializedAs("sidewaysForce")]
    [Space]
    [SerializeField] private float sidewaysImpulse;
    [SerializeField] private float sidewaysVelocityBound;
    [Space]
    [SerializeField] private float cancelStrafeStep;
    [SerializeField] private float cancelStrafeStepDivisor;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }
    
    private void ApplyForwardMomentum() {
        _rb.AddForce(Vector3.forward * forwardForcePerFrame);
        _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, _rb.linearVelocity.y, Math.Clamp(_rb.linearVelocity.z, 0f, forwardVelocityBound));
    }

    // sign > 0: right
    // sign < 0: left
    public void ApplySidewaysMomentum(int sign) {
        sign *= 1; // normalization
        if (sign == 0)
            throw new ArithmeticException("Sideways momentum applied with sign 0.");
        
        _rb.AddForce(sign * sidewaysImpulse * Vector3.right, ForceMode.Impulse);

        float currentVelocityX = _rb.linearVelocity.x;
        float currentVelocityY = _rb.linearVelocity.y;
        float currentVelocityZ = _rb.linearVelocity.z;
        
        // clamp x velocity between:
        // cvX > 0: [0, sidewaysVelocityBound]
        // cvX < 0: [-sidewaysVelocityBound, 0]
        _rb.linearVelocity = currentVelocityX > 0f
            ? new Vector3(Math.Clamp(currentVelocityX, 0f, sidewaysVelocityBound), currentVelocityY, currentVelocityZ)
            : new Vector3(Math.Clamp(currentVelocityX, -sidewaysVelocityBound, 0f), currentVelocityY, currentVelocityZ);
    }

    public void CancelStrafe() {
        float currentVelocityX = _rb.linearVelocity.x;
        float currentVelocityY = _rb.linearVelocity.y;
        float currentVelocityZ = _rb.linearVelocity.z;
        
        _rb.linearVelocity = currentVelocityX > 0f
            ? new Vector3(Math.Clamp(currentVelocityX - cancelStrafeStep / cancelStrafeStepDivisor, 0f, sidewaysVelocityBound), currentVelocityY, currentVelocityZ)
            : new Vector3(Math.Clamp(currentVelocityX + cancelStrafeStep / cancelStrafeStepDivisor, -sidewaysVelocityBound, 0f), currentVelocityY, currentVelocityZ);
    }
    
    public bool IsStrafingRight(float velocityThreshold = 0f) => _rb.linearVelocity.x > velocityThreshold;

    public bool IsStrafingLeft(float velocityThreshold = 0f) => _rb.linearVelocity.x < -velocityThreshold;
    
    private void FixedUpdate() {
        ApplyForwardMomentum();
    }

    private void Update() {
        
    }
}
