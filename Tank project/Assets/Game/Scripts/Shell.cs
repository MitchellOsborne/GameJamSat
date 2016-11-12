using UnityEngine;
using System.Collections;
using Thinksquirrel.CShake;

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

		if (health == null)
			return;
		
		health.Modify (-damage);

		CameraShake.ShakeAll();

		Destroy(this);
	}
}