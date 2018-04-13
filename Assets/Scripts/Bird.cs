using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    
    public int time;

    private bool hasCatched;
    private Vector3 vec, offset;
    private float deltatime;
    private Transform beak;
    private GameObject flight;

	// Use this for initialization
	void Start () {
        hasCatched = false;
        vec = transform.position;
        deltatime = 0f;
        beak = transform.GetChild(0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(hasCatched) {
            vec.x = vec.x - 30f * Time.deltaTime;
            vec.y = vec.y + 1.5f * Mathf.Sin(0.1f*vec.x);
            transform.position = vec;
            flight.transform.position = transform.position + offset;

            deltatime += Time.deltaTime;
            if(deltatime > time) {
                hasCatched = false;
                flight.GetComponent<FlightController>().SetCatched(false);
                deltatime = 0f;
                vec.x += 100;
                transform.position = vec;
            }
            print("bird " + transform.position);
            print(beak.transform.position+" "+flight.transform.position);
        }
	}

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            vec = transform.position;
            flight = other.gameObject;
            flight.GetComponent<FlightController>().SetCatched(true);
            flight.transform.position = new Vector3(beak.position.x-0.2f, beak.position.y-2.34f, flight.transform.position.z);
            offset = flight.transform.position - transform.position;
            hasCatched = true;
        }
    }
}
