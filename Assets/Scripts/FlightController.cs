using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightController : MonoBehaviour {
    private Vector3 mouseDownPosition, velocity, baseVelocity, inputVelocity;
    private float elapsedTime, startTime;
    private enum State {Normal, BirdCatched};
    private State state;

    public float speed, xfactor, yfactor, xmax, ymax;
    public Text text, text2;
    public Camera camera;

    private Rigidbody rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        baseVelocity = new Vector3(speed, 5.0f);
        inputVelocity = new Vector3(0f, 0f);

        rb.velocity = baseVelocity;

        elapsedTime = 0.0f;
        text.text = "velocity: " + rb.velocity.ToString();
        startTime = Time.time;

        state = State.Normal;
    }
    
    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.5f) {
            text.text = "velocity: " + rb.velocity.ToString();
            //text2.text = camera.WorldToViewportPoint(transform.position).ToString();
        }
    }

    void FixedUpdate() {

        if(state == State.BirdCatched)
            return;
        
        Vector3 p = camera.WorldToViewportPoint(transform.position);

        if (Input.GetMouseButtonDown (0)) {
            mouseDownPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y);

        } else if (Input.GetMouseButtonUp (0)) {
            inputVelocity = new Vector3 (Input.mousePosition.x - mouseDownPosition.x, Input.mousePosition.y - mouseDownPosition.y);
            inputVelocity = inputVelocity.normalized;
            inputVelocity.x *= xfactor;
            inputVelocity.y *= yfactor;
            if (rb.velocity.x + inputVelocity.x > xmax)
                inputVelocity.x = xmax - rb.velocity.x > 0 ? xmax -rb.velocity.x : 0;
            if(rb.velocity.y + inputVelocity.y > ymax)
                inputVelocity.y = ymax - rb.velocity.y > 0 ? ymax -rb.velocity.y : 0;

            rb.velocity += inputVelocity;
            startTime = Time.time;
        }

        rb.velocity = new Vector3(
            (rb.velocity.x+speed * Time.deltaTime) * Mathf.Exp(-0.3f * (Time.time - startTime) * Time.deltaTime),
            rb.velocity.y /* Mathf.Exp(-(Time.time - startTime) * Time.deltaTime)*/
        );

        if(transform.position.y > 30f) {
            transform.position = new Vector3(transform.position.x, 30f, transform.position.z);
        }
    }

    void SetCatched(bool beCatched) {
        gameObject.GetComponent<Rigidbody>().useGravity = !beCatched;
        state = beCatched ? State.BirdCatched : State.Normal;
    }
}
