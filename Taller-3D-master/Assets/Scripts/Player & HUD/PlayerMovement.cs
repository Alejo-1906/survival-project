using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public static PlayerMovement playerMovement;

    public GameObject[] hearts;
    public GameObject gameOverScreen;

    private Rigidbody rb;

    //Movement
    private string dirString;
    private bool moving;

	void Start () {
        playerMovement = this;
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (Player.player.IsDead() && Input.anyKeyDown) SceneManager.LoadScene(1);
	}

    void FixedUpdate() {
        if (moving && !Player.player.IsDead())
            rb.velocity = transform.forward * Player.player.speed;
        else
            rb.velocity = Vector3.zero;
    }

    public void Move (string dir) {
        if (dir != "00")
            moving = true;
        else
            moving = false;
        CheckBody(dir);
    }

    void CheckBody(string dir) {
        if (dir != dirString || dir == "00") {
            dirString = dir;
            FixRotation();
        }
    }

    void FixRotation () {
        switch (dirString) {
            case "11":
                transform.localEulerAngles = new Vector3(0, 45, 0);
                break;
            case "10":
                transform.localEulerAngles = new Vector3(0, 90, 0);
                break;
            case "1-1":
                transform.localEulerAngles = new Vector3(0, 135, 0);
                break;
            case "0-1":
                transform.localEulerAngles = new Vector3(0, 180, 0);
                break;
            case "-1-1":
                transform.localEulerAngles = new Vector3(0, -135, 0);
                break;
            case "-10":
                transform.localEulerAngles = new Vector3(0, -90, 0);
                break;
            case "-11":
                transform.localEulerAngles = new Vector3(0, -45, 0);
                break;
            case "01":
                transform.localEulerAngles = new Vector3(0, 0, 0);
                break;
        }
    }

    public void Shot (GameObject arrow, Vector3 cannonPoint) {
        Instantiate(arrow, cannonPoint, transform.rotation);
    }

    public void Death () {
        gameOverScreen.SetActive(true);
    }

    public void UpdateHUD (int lives) {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
                hearts[i].SetActive(true);
            else
                hearts[i].SetActive(false);
        }
    }
}
