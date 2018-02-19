using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour {

    public enum SpawnType {Mushroom, Acorn, Bramble, Dandelion }

    public float pointValue;
    public Vector3 spawnPos = new Vector3(0f, 0f, 0f);
    public SpawnType myType;

    private Vector3 randVector;
    private Vector3 posReturn;

    public float GetPointValue() {
        return pointValue;
    }

    public Vector3 GetSpawnPos() {

        posReturn = spawnPos;

        if (myType == SpawnType.Acorn) {     //Randomise the acorn x pos
            randVector = new Vector3(Random.Range(-6,0),0,0);
            posReturn = spawnPos + randVector;
        }
        return posReturn;
    }
}