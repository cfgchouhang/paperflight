using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    private Vector3 offset, newPosition;
    private float yBound, elapsedTime, z, x, yPrev;
    public GameObject player, background;
    public Text text;
    public float zMin, zMax;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
        yBound = background.GetComponent<Collider>().bounds.size.y / 2f;
        yPrev = 0f;
        x = 0f;

    }

    // Update is called once per frame
    void Update () {
        x = 0f;
        z = transform.position.z;
        float py = player.transform.position.y;

        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.25f) {
            text.text = (py / yBound).ToString()+" "+yBound+" "+py;
        }
       
        if(py > 10f && py > yPrev) {
            if(z > zMin) {
                z -= (zMax - zMin) * (1f+Mathf.Exp(-2f * py / yBound))  * 0.2f * Time.deltaTime;
                x = 8f * (1f + Mathf.Exp(-2f * py / yBound)) * Time.deltaTime;
            }
        } else if(py < 25f && py < yPrev) {
            if(z < zMax) {
                z += (zMax - zMin) * (1f + Mathf.Exp(-2f * py / yBound)) * 0.2f * Time.deltaTime;
                x = -8f * (1f + Mathf.Exp(-2f * py / yBound)) * Time.deltaTime;

            }
        }

        offset.x += x;

        transform.position = new Vector3(
            player.transform.position.x  + offset.x,
            transform.position.y,
            z
        );

        yPrev = py;

        print("co " + offset + " " + (transform.position));
    }
}
