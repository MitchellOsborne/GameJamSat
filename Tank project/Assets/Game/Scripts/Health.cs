using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField]
	private int maxHealth;

	[SerializeField]
	private int health;

	public void Modify(int amount){
		health += amount;
		health = Mathf.Clamp (health, 0, maxHealth);
	}
}