using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
    [SerializeField]
    float rateOfFire;
    float fireTime;
    [SerializeField]
    int ammoCount;
    [SerializeField]
    GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}

    public void Fire()
    {
        if(fireTime >= rateOfFire)
        {
            fireTime = 0;
            Instantiate(projectile, transform.position, transform.rotation);
            --ammoCount;
        }
    }

	
	// Update is called once per frame
	void Update () {
        if(ammoCount == 0)
        {
            //Reset Cannon to default cannon
            Destroy(this);
        }
        fireTime += Time.deltaTime;
	}
}
