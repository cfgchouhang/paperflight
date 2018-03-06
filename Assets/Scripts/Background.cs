using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {
    
    private Vector3 offset;

    void Start() {
        offset = new Vector3(gameObject.GetComponent<Collider>().bounds.size.x * 2, 0);
    }

    void OnBecameInvisible() {
        transform.position += offset;
    }
}
