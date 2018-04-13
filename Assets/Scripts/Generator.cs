using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public int blockNumber;

    // generated block's x will be: x of previous object + xBase * random[xMinF, xMaxF]
    public float xMinF, xMaxF, xBase;

    public bool isFirstBG;
    public static int yHigh = 30, yMid = 0, yLow = -30;

    private Transform background;
    private GameObject[] blocks = null; // index 2 and 5 is for bird

    private float xStart;
    private float[][] patterns = new float[][] { // index 2 and 5 is for bird
        new float[]{yHigh, yHigh, yMid, yMid, yMid, yHigh, yLow},
        new float[]{yMid, yHigh, yLow, yMid, yLow, yHigh, yMid},
        new float[]{yLow, yMid, yHigh, yLow, yMid, yMid, yHigh},
        new float[]{yLow, yMid, yMid, yHigh, yMid, yHigh, yLow}
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
                patterns[yp][yi]// + Random.Range(-10, 10)
            );
            PutPapers(block.transform.position);
            xStart = block.transform.position.x;
            yi = (yi+1)%blockNumber;
        }
	}

    void PutPapers(Vector3 center) {
        int round = Random.Range(1, 5);
        GameObject paper;

        for(int i = 0; i < round; i++) {
            center.x += Random.Range(xBase, xBase * xMinF);
            center.y += Random.Range(yLow, yHigh);
            paper = (GameObject)Instantiate(Resources.Load("paper sprite"));
            paper.transform.position = center;
        }
        
    }

    void Generate() {
        blocks = new GameObject[blockNumber];
        for(int i = 0; i < blocks.Length; i++) {
            if(i == 2 || i == 5) {
                blocks[i] = (GameObject)Instantiate(Resources.Load("bird sprite"));
            } else {
                blocks[i] = (GameObject)Instantiate(Resources.Load("Block"));
            }
        }
    }
}
