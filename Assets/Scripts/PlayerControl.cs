using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float movSpeed = 2f;
    public float rotSpeed = 90f;

    private Rigidbody2D myRigidy;
    private float xmin, xmax, padding;

    // Use this for initialization
    void Start() {
        myRigidy = GetComponent<Rigidbody2D>();

        padding = 1f;  //Limit movement space based on screen size
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    // Update is called once per frame
    void Update() {
        CheckKeyPresses();
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime,Space.Self);
    }

    void CheckKeyPresses() {
        if (Input.GetKey("a") && transform.position.x > xmin) {
            transform.Translate(Vector3.left * movSpeed * Time.deltaTime,Space.World);
        }

        if (Input.GetKey("d") && transform.position.x < xmax) {
            transform.Translate(Vector3.right * movSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s")) {
            transform.Translate(Vector3.down * movSpeed * Time.deltaTime, Space.World);
        }
    }

    public void FreezePlayer() {
        myRigidy.simulated = false;
        rotSpeed = 0;
        movSpeed = 0;
    }
}
