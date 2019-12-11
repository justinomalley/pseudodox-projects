using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugSpawner : MonoBehaviour {

    public GameObject mug;

    // Next update in second
    // Next update in second
    private int nextUpdate = 1;
     
    // Update is called once per frame
    void Update(){
     
        // If the next update is reached
        if (Time.time >= nextUpdate) {
            Debug.Log(Time.time+">="+nextUpdate);
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            Instantiate(mug, transform);
        }
     
    }
}
