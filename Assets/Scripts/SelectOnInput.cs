using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject gb;

    private bool isSelected;

	// Use this for initialization
	void Start () {
        isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxisRaw("Vertical") != 0 && !isSelected) {
            eventSystem.SetSelectedGameObject(gb);
            isSelected = true;
        }
	}

    private void OnDisable() {
        if(isSelected)
            gb = eventSystem.currentSelectedGameObject;
    }

    private void OnEnable() {
        if(isSelected)
            eventSystem.SetSelectedGameObject(gb);
    }
}
