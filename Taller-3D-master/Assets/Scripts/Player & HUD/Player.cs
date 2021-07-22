using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player player;

    public Transform cannonPoint;
    public ArrowBehaviour arrow;

    public float speed;
    public float shotWaitTime;
    public int lives;

    private Vector3 dir;
    private float shotTimer;
    private bool dead;

    public void Start() {
        player = this;
        if (speed <= 0f) speed = 1f;
        if (lives > 5) lives = 5;
        dead = false;
    }

    public void TakeDamage (int dmg) {
        if (!dead) {
            lives--;
            PlayerMovement.playerMovement.UpdateHUD(lives);
            if (lives <= 0) {
                dead = true;
                PlayerMovement.playerMovement.Death();
            }
        }
    }

    public void Heal(int heal) {
        if (!dead && lives < 5) {
            lives++;
            PlayerMovement.playerMovement.UpdateHUD(lives);
        }
    }

    public bool IsDead () {
        return dead;
    }

    public void Move (float v, float h) {
        string dir = h.ToString() + v.ToString();
        PlayerMovement.playerMovement.Move(dir);
    }

    public void Shot () {
        if (!dead && shotTimer <= Time.time) {
            PlayerMovement.playerMovement.Shot(arrow.gameObject, cannonPoint.position);
            shotTimer = Time.time + shotWaitTime;
        }
    }
}
