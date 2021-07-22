using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour {

    public float speed = 1f;
    public float waitAttack;
    public Transform attackZone;

    private Rigidbody rb;

    private Vector3 direction;
    private float distance;
    private float attackTimer;
    private bool attacking;
    private bool inRange;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        direction = Player.player.transform.position;
        direction.y = transform.position.y;
        transform.LookAt(direction);

        distance = Vector2.Distance(transform.position, Player.player.transform.position);

        if (distance <= 0.2 && !inRange) {
            inRange = true;
            attackTimer = Time.time + waitAttack;
        } else if (distance > 0.2) {
            inRange = false;
        }

        if (attackTimer <= Time.time && inRange) {
            attacking = true;
            attackTimer = Time.time + waitAttack;
        }

        if (inRange && attacking) {
            attackZone.gameObject.SetActive(false);
            attacking = false;
        } else if (inRange && !attacking) {
            attackZone.gameObject.SetActive(true);
        }
	}

    void FixedUpdate() {
        if (distance > 0.2) rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Arrow")) {
            Destroy(gameObject);
        }
    }
}
