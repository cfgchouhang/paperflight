using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Image[] digits;
    public int lifes;
    
    private int score;
    private Sprite[] digitSprites;

	// Use this for initialization
	void Start () {
        score = 0;
        digitSprites = new Sprite[10];
        for(int i = 0; i < 10; i++) {
            //digitSprites[i] = (Sprite)Instantiate(Resources.Load("Score/"+i.ToString()));
            digitSprites[i] = Resources.Load<Sprite>("Score/"+i.ToString());
            if(digitSprites[i] == null)
                print("null sprite");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddScore(int increment) {
        score += increment;
        for(int i = 0; i < digits.Length; i++) {
            digits[i].sprite = digitSprites[score / (int)(Mathf.Pow(10, i)) % 10];
        }
    }
}
