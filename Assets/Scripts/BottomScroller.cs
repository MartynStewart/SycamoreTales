using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomScroller : MonoBehaviour {

    public float scrollSpeed;
    public float maxChildren = 4;
    public GameObject[] pbjectSpawns;
    public float meanSpawnDelay;
    public float minSpawnDelay;
    public float scrollIncrement;
    public Text ScoreText; 

    private Vector3 SpawnPos;
    private float nextSpawn=1;
    private int spawnCount = 0;
    private int incrementRate = 5;
    private GameObjectSpawner.SpawnType lastSpawn;
    private float scoreDistance = 0;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void LateUpdate () {

        foreach (GameObject thisHelper in pbjectSpawns) {
            if (thisHelper.GetComponent<GameObjectSpawner>().myType == lastSpawn) continue; //Don't spawn the same object twice
            if (IsTimeToSpawn()) Spawn(thisHelper);
        }
        MoveChildren();
        scoreDistance += (scrollSpeed*Time.deltaTime);
        ScoreText.text = Mathf.FloorToInt(scoreDistance).ToString();
    }

    void MoveChildren() {
        foreach(Transform child in transform) {
            child.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
            if (child.transform.position.x < -12) Destroy(child.gameObject);
        }
    }

    bool IsTimeToSpawn() {

        if (Time.timeSinceLevelLoad < nextSpawn) return false;
        if (transform.childCount >= maxChildren) return false;

        float spawnsPerSecond = 1 / meanSpawnDelay;
        float threshold = spawnsPerSecond * Time.deltaTime;

        if (Time.deltaTime > meanSpawnDelay) Debug.LogWarning("Capped by Framerate");
        return (Random.value < threshold);
    }

    void Spawn(GameObject myGameObject) {

        GameObjectSpawner spawnerCode = myGameObject.GetComponent<GameObjectSpawner>();

        nextSpawn = Time.timeSinceLevelLoad + minSpawnDelay;

        SpawnPos = spawnerCode.GetSpawnPos();
        GameObject newHelp = Instantiate(myGameObject, SpawnPos, Quaternion.identity) as GameObject;
        newHelp.transform.parent = this.transform;

        lastSpawn = spawnerCode.myType;
        spawnCount++;
        if (spawnCount % incrementRate == 0) scrollSpeed += scrollIncrement;
    }

    public void StopEverything() {
        nextSpawn = 6000f;
        scrollSpeed = 0f;
        
    }
}