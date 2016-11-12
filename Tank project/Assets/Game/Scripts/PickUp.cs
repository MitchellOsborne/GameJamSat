using UnityEngine;
using System.Collections.Generic;

public class PickUp : MonoBehaviour {

	[SerializeField]
	private List<GameObject> turrets;

	[SerializeField]
	private GameObject effect;

	void OnTriggerEnter(Collider other) {
		//Instantiate (effect, transform.position, Quaternion.identity);

		TankController tc = other.gameObject.GetComponent<TankController>();

        if (tc != null)
        {
            tc.PickUp(turrets[Random.Range(0, turrets.Count)]);
        }

		Destroy(gameObject);
	}
}
