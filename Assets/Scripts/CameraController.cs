using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    private Vector3 offset, newPosition;
    private float yBound, elapsedTime, x, z, yPrev;
    public GameObject player, background;
    public Text text;
    public float zMin, zMax;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
        yBound = background.GetComponent<Collider>().bounds.size.y / 2f;
        yPrev = 0f;
    }

    // Update is called once per frame
    void Update () {
        x = player.transform.position.x + offset.x;
        z = transform.position.z;
        float py = player.transform.position.y;

        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.25f) {
            text.text = (py / yBound).ToString();
        }
       
        if(py / yBound > 0.1f && py > yPrev) {
            if(z > zMin) {
                z -= (zMax - zMin) * (1f+Mathf.Exp(-2f * py / yBound))  * 0.2f * Time.deltaTime;
            }
        } else if(z < zMax) {
            z += (zMax - zMin) * (1f+Mathf.Exp(-2f * py / yBound)) * 0.2f * Time.deltaTime;
        }

        transform.position = new Vector3(
            player.transform.position.x + offset.x * z / offset.z,
            transform.position.y,
            z
        );

        yPrev = py;
    }
}
