using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRipper : MonoBehaviour {
    public AnimationCurve curve;
    public float speed;

    // Update is called once per frame
    void Update() {
        var scale = transform.localScale;
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.PingPong(Time.time * speed, 360), transform.rotation.eulerAngles.z);
        //transform.localScale = new Vector3(Mathf.PingPong(Time.time, 2) + 1, scale.y, scale.z);;
    }
}
