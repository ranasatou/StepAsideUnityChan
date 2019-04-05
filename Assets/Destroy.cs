using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    // カメラの距離
    private GameObject Camera;
    
    // Use this for initialization
    void Start() {
        // カメラの位置（z座標）
        this.Camera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update() {
        
        if ( Camera.transform.position.z > this.transform.position.z) {
            Destroy(gameObject);
        }
    }
}