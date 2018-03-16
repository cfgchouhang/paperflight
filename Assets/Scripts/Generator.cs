using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public int blockNumber;
    public float xMin, xMax;
    private Transform background;
    private float xStart;

    GameObject[] blocks;
	// Use this for initialization
	void Start () {
        background = transform.parent;
        xStart = background.position.x - background.gameObject.GetComponent<Collider>().bounds.size.x / 2;
        blocks = new GameObject[blockNumber];
        for(int i = 0; i < blocks.Length; i++) {
            blocks[i] = (GameObject)Instantiate(Resources.Load("Block"));
            blocks[i].transform.position = new Vector3(xStart + Random.Range(xMin, xMax), Random.Range(-40, 40), -3f);
            xStart = blocks[i].transform.position.x;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
