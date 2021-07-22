using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour {

    public float speed = 1f;

    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 0.75f);
	}
	
	void FixedUpdate () {
        rb.velocity = transform.forward * speed;
	}

    void OnCollisionEnter(Collision collision) {
        string t = collision.transform.tag;
        if (t != "EnemyAttack" && t != "Arrow") Destroy(gameObject);
    }
}
