using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField]
	private GameObject hurtEffect;

	[SerializeField]
	private int maxHealth;

    [SerializeField]
    private GameObject effectOnDeath;

	[SerializeField]
	private int health;

	public void Modify(int amount){
		if (amount < 0 && hurtEffect != null) {
			hurtEffect.SetActive (true);
		}

		health += amount;
		health = Mathf.Clamp (health, 0, maxHealth);
	}

    void Update()
    {
        if(health <= 0)
        {
           if(effectOnDeath!= null)
                Instantiate(effectOnDeath, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}