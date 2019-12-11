using UnityEngine;

public class GrowToSize : MonoBehaviour
{
    private float scale = 0;
    
    // Start is called before the first frame update
    void Start() {
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        while (scale < 1)
        {
            Debug.Log("yo");
            transform.localScale = new Vector3(scale, scale, scale);
            scale += Time.deltaTime;
        }
    }
}
