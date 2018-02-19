using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dandelion : MonoBehaviour {

    private float floatSpeed = 0;
    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        Invoke("FloatUp", Random.Range(2, 7));
        myAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * (floatSpeed/5) * Time.deltaTime);
        if (transform.position.y > 7) Destroy(gameObject);
    }

    void FloatUp() {
        transform.parent = null;
        floatSpeed = Random.Range(0.5f, 1.5f);
        myAnimator.SetTrigger("StartFloat");
    }
}
