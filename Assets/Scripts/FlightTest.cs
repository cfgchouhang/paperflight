using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightTest : MonoBehaviour {

    private Vector3 prev;
    public float setNum;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
    void Update () {
        prev = transform.position;
        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position = new Vector3(prev.x + setNum * Time.deltaTime, prev.y, prev.z);
        } else if(Input.GetKey(KeyCode.LeftArrow)) {
            transform.position = new Vector3(prev.x - setNum * Time.deltaTime, prev.y, prev.z);
        } else if(Input.GetKey(KeyCode.UpArrow)) {
            transform.position = new Vector3(prev.x, prev.y + setNum * Time.deltaTime, prev.z);
        } else if(Input.GetKey(KeyCode.DownArrow)) {
            transform.position = new Vector3(prev.x, prev.y - setNum * Time.deltaTime, prev.z);
        }
	}
}
