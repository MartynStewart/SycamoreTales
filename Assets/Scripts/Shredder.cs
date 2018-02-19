using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

    public float width, height;
    public GameObject gameOverPanel;

    private BottomScroller btmScroller;
    private PlayerControl player;
    private Transition SceneSwitch;

    public void OnDrawGizmos() { Gizmos.DrawWireCube(transform.position,new Vector3(width, height, 0)); }

    // Use this for initialization
    void Start () {
        btmScroller = GameObject.FindObjectOfType<BottomScroller>();
        player = GameObject.FindObjectOfType<PlayerControl>();
        SceneSwitch = GameObject.FindObjectOfType<Transition>();
    }
	
    void OnTriggerEnter2D(Collider2D collider) {
        GameObject colObj = collider.gameObject;
        if (colObj.GetComponent<PlayerControl>()) {
            GameOver();
        } else Destroy(colObj);
    }

    void GameOver() {
        btmScroller.StopEverything();
        player.FreezePlayer();
        gameOverPanel.SetActive(true);
        SceneSwitch.GameOverScreen();
    }
}