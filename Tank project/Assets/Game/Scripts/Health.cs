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

        if (health <= 0)
        {
            if (effectOnDeath != null)
                Instantiate(effectOnDeath, transform.position, transform.rotation);
            transform.position = new Vector3(Random.Range(-10, 10), 0, (Random.Range(-9, 9)));
            try
            {
                GetComponent<TankController>().RemoveCannon();
            }
                catch(System.Exception e)
            {

            }
                health = maxHealth;
        }
    }

    void Update()
    {
        
    }
}