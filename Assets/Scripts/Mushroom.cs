using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

    public float bounce;
    private float scrollSpeed;

    void Start() {
        scrollSpeed = 5f;
    }

    void Update() {
        transform.Translate(Vector3.left * scrollSpeed * Time.captureFramerate);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject colObj = collider.gameObject;

        if (colObj.GetComponent<PlayerControl>()) {
            Rigidbody2D colRB = colObj.GetComponent<Rigidbody2D>();
            colRB.velocity = Vector2.up * bounce;
        }
    }
}
