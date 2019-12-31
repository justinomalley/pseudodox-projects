using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTripper : MonoBehaviour {

    private Transform head;  
    
    void Start() {
        head = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").transform;
    }
    
    void Update() {
        var distanceFromCenter = Vector3.Distance(head.position, Vector3.zero);
        Debug.Log(distanceFromCenter);
    }
}
