using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private int h;
    private int v;
    private Player Vidas;


    void Start () {
        Vidas = GetComponent<Player>();
	}

	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
            v = 1;
        else if (Input.GetKey(KeyCode.DownArrow))
            v = -1;
        else
            v = 0;

        if (Input.GetKey(KeyCode.RightArrow))
            h = 1;
        else if (Input.GetKey(KeyCode.LeftArrow))
            h = -1;
        else
            h = 0;

        Player.player.Move(v, h);

        if (Input.GetKeyDown(KeyCode.Space))
            Player.player.Shot();

    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("EnemyAttack")) {
            Player.player.TakeDamage(1);
        } else if (other.CompareTag("KeyZone")) {
            other.GetComponent<OpenDoor>().Open();
        } else if (other.CompareTag("Room")) {
            other.GetComponent<RoomManager>().StartRoom();
        } else if (other.CompareTag("Heal")) {
            if (Vidas.lives>=5)
            {
               
                Debug.Log("no se destruye");
            }
            else
            {
                Player.player.Heal(1);
                Destroy(other.gameObject);
            }
          
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("EnemyAttack")) {
            Player.player.TakeDamage(1);
        }
    }
}
