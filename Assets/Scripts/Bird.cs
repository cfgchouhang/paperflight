using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
   
    public GameObject flight;
    public int time;

    private bool hasCatched;
    private Vector3 vec, offset;
    private float deltatime;


	// Use this for initialization
	void Start () {
        hasCatched = false;
        vec = transform.position;
        deltatime = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if(hasCatched) {
            vec.x = vec.x - 30f * Time.deltaTime;
            vec.y = vec.y + 1.5f * Mathf.Sin(0.1f*vec.x);
            transform.position = vec;
            flight.transform.position = transform.position + offset;

            deltatime += Time.deltaTime;
            if(deltatime > time) {
                hasCatched = false;
                flight.BroadcastMessage("SetCatched", false);
                deltatime = 0f;
            }
        }
	}

    void OnTriggerEnter(Collider other) {
        other.gameObject.BroadcastMessage("SetCatched", true);
        if(other.CompareTag("Player")) {
            print("catch flight");
            offset = flight.transform.position - transform.position;
            hasCatched = true;
        }
    }
}
