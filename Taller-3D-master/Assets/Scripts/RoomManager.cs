using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    public bool isFirstRoom;
    public bool isLastRoom;

    public Transform enemies;
    public GameObject key;
    public GameObject keyZone;

    private bool roomStarted;
    private bool keySpawned;

    void Start() {
        if (isFirstRoom) roomStarted = true;
    }

    void Update() {
        if (!isLastRoom && roomStarted && enemies.childCount <= 0 && !keySpawned)
            SpawnKey();
    }

    void SpawnKey () {
        key.SetActive(true);
        keySpawned = true;
        keyZone.SetActive(true);
    }

    public void StartRoom () {
        enemies.gameObject.SetActive(true);
        roomStarted = true;
    }
}
