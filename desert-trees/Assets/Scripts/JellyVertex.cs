using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyVertex {
    
    public int verticeIndex;
    public Vector3 initialPos;
    public Vector3 currPos;

    public Vector3 currVelocity;

    public JellyVertex(int _verticeIndex, Vector3 _initialPos, Vector3 _currPos, Vector3 _currVelocity) {
        verticeIndex = _verticeIndex;
        initialPos = _initialPos;
        currPos = _currPos;
        currVelocity = _currVelocity;
    }

    public Vector3 GetCurrentDisplacement() {
        return currPos - initialPos;
    }

    public void UpdateVelocity(float _bounceSpeed) {
        currVelocity -= (GetCurrentDisplacement() * _bounceSpeed * Time.deltaTime);
    }

    public void Settle(float _stiffness) {
        currVelocity *= 1f - _stiffness * Time.deltaTime;
    }

    public void ApplyPressureToVertex(Transform _transform, Vector3 _position, float _pressure) {
        Vector3 distanceVerticePoint = currPos - _transform.InverseTransformPoint(_position);
        float adaptedPressure = _pressure / (1f + distanceVerticePoint.sqrMagnitude);
        float velocity = adaptedPressure * Time.deltaTime;
        currVelocity += distanceVerticePoint.normalized * velocity;
    }
}
