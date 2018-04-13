using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour {
    private GameObject gm;

	// Use this for initialization
	void Start () {
        gm = (GameObject)GameObject.Find("Game Controller");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        print("paper got");
        if(other.CompareTag("Player")) {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0.5f);
            gm.SendMessage("AddScore", 1);
        }
    }
}
