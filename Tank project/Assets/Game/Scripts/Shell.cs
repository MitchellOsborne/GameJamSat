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
        body = GetComponent<Rigidbody>();
		body.velocity = transform.forward * speed;	
	}

	void OnTriggerEnter(Collider other) {
        if (other.tag == tag)
            return;
		if(explosion != null)
			Instantiate (explosion, transform.position, Quaternion.identity);

		Health health = other.gameObject.GetComponent<Health> ();

		if (health != null) {
			health.Modify (-damage);
		}

		CameraShake.ShakeAll ();
		Controller.Vibrate ();
		Destroy (gameObject);
	}
}