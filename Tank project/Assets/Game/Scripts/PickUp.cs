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

        transform.position = new Vector3(Random.Range(-10, 10), 1, Random.Range(-9, 9));
		//Destroy(gameObject);
	}
}
