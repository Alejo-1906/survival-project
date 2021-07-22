using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject[] door;
    public GameObject[] col;
    public GameObject key;

    public void Open () {
        for (int i = 0; i < door.Length; i++) {
            door[i].SetActive(false);
            col[i].SetActive(false);
        }
        key.SetActive(false);
    }
}
