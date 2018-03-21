using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public int blockNumber;

    // generated block's x will be: x of previous object + xBase * random[xMinF, xMaxF]
    public float xMinF, xMaxF, xBase;

    public bool isFirstBG;
    public static int yHigh = 20, yMid = 0, yLow = -20;

    private Transform background;
    private GameObject[] blocks = null;
    private float xStart;
    private float[][] patterns = new float[][] {
        new float[]{yHigh, yHigh, yMid, yMid, yLow},
        new float[]{yMid, yHigh, yMid, yLow, yMid},
        new float[]{yLow, yMid, yLow, yMid, yHigh},
        new float[]{yLow, yMid, yHigh, yMid, yLow}
    };

	// Use this for initialization
	void Start () {
        background = transform.parent;
        if(!isFirstBG) {
            UpdateBlocksPosition();
        }
	}
	
	void UpdateBlocksPosition() {
        int yp = Random.Range(0, patterns.Length), yi = 0;
        print("pattern: " + yp);

        if(blocks == null) {
            Generate();
        }

        xStart = background.position.x - background.gameObject.GetComponent<Collider>().bounds.size.x / 2;
        foreach(GameObject block in blocks) {
            block.transform.position = new Vector3(
                xStart + xBase * Random.Range(xMinF, xMaxF),
                patterns[yp][yi] //+ Random.Range(-10, 10)
            );
            xStart = block.transform.position.x;
            yi++;
        }
	}

    void Generate() {
        blocks = new GameObject[blockNumber];
        for(int i = 0; i < blocks.Length; i++) {
            blocks[i] = (GameObject)Instantiate(Resources.Load("Block"));
        }
    }
}
