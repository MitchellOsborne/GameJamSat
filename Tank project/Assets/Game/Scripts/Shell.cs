using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

	[SerializeField]
	private int damage;

	[SerializeField]
	private float speed;

	[SerializeField]
	private GameObject explosion;

	private Rigidbody body;

	// Use this for initialization
	void Awake() {
		body.velocity = transform.forward * speed;	
	}

	void OnTriggerEnter(Collider other) {
		Instantiate (explosion, transform.position, Quaternion.identity);

		Health health = other.gameObject.GetComponent<Health> ();
		health.Modify (-damage);

		Destroy(this);
	}
}