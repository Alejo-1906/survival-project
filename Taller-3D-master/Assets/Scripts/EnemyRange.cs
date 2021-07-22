using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour {

    public float waitAttack;
    public Transform cannonPoint;
    public ArrowBehaviour arrow;

    private Vector3 direction;
    private float attackTimer;

    void Start () {
		
	}
	
	void Update () {
        direction = Player.player.transform.position;
        direction.y = transform.position.y;
        transform.LookAt(direction);

        if (attackTimer <= Time.time) Shot();
    }

    void Shot () {
        Instantiate(arrow, cannonPoint.position, transform.rotation);
        attackTimer = Time.time + waitAttack;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Arrow")) {
            Destroy(gameObject);
        }
    }
}
