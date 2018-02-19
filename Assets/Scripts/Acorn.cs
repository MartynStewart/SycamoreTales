using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour {

    public float knockDown;
    public float knockLeft;
    public float fallSpeed;

    public void LateUpdate() {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {

        GameObject colObj = collision.gameObject;
        if (colObj.GetComponent<PlayerControl>()) {
            Rigidbody2D colRB = colObj.GetComponent<Rigidbody2D>();
            colRB.velocity = new Vector2(-knockDown,-knockLeft);
        }
    }
}