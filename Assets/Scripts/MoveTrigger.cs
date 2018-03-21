using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour {

    public GameObject nextBackground;
    public bool isFront;

    private GameObject parent;
    private Vector3 offset;

	void Start () {
        parent = transform.parent.gameObject;
        offset = new Vector3(parent.GetComponent<Collider>().bounds.size.x, 0);
        offset *= isFront ? 1 : -1;
	}

    void OnBecameVisible() {
        nextBackground.transform.position = parent.transform.position + offset;
    }
}
