using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	[SerializeField]
	private GameObject turret;

	[SerializeField]
	private GameObject effect;

	void OnTriggerEnter(Collider other) {
		Instantiate (effect, transform.position, Quaternion.identity);

		//TankController tc = other.gameObject.GetComponent<TankController>();

		//tc.PickUp(turret);

		Destroy(this);
	}
}
