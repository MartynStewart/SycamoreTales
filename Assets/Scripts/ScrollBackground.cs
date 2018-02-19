using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class ScrollBackground : MonoBehaviour {

    public float speedAdj = 1.0f;

    private float speed; //Copy from scroller at some point
    private float startPos;
    private BottomScroller bottomScroller;

    // Use this for initialization
    void Start () {
        bottomScroller = GameObject.Find("Scroller").GetComponent<BottomScroller>();
        startPos = transform.localPosition.x;
        GameObject objectCopy = GameObject.Instantiate(gameObject);
        Destroy(objectCopy.GetComponent<ScrollBackground>());   //Stop it making more copies of itself
        objectCopy.transform.SetParent(transform);
        objectCopy.transform.localPosition = new Vector3(MyWidth(), 0, 0);
    }

    void FixedUpdate() {
        float width = MyWidth();
        speed = bottomScroller.scrollSpeed;     //Keeps the speed in line with the spawner

        transform.Translate(Vector3.left * speed * speedAdj * Time.deltaTime);

        if (startPos - transform.localPosition.x > width) {
            transform.Translate(new Vector3(width, 0, 0));
        }
    }

    float MyWidth() {
        return GetComponent<SpriteRenderer>().bounds.size.x;
    }
}
