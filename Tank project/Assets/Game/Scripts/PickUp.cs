using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	[SerializeField]
	private GameObject turret;

	[SerializeField]
	private GameObject effect;

	void OnTriggerEnter(Collider other) {
        Debug.Log("Collided with stuff");
		Instantiate (effect, transform.position, Quaternion.identity);

		TankController tc = other.gameObject.GetComponent<TankController>();

        if (tc != null)
        {
            tc.PickUp(turret);
        }

		Destroy(this);
	}
}
