using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
    [SerializeField]
    float rateOfFire;
    float fireTime = 0;
    [SerializeField]
    int ammoCount;
    [SerializeField]
    int numberOfProjectiles = 1;
    [SerializeField]
    float deviation = 0;
    [SerializeField]
    GameObject projectile;

    TankController tC;

    [SerializeField]
    bool unlimitedAmmo = false;

	// Use this for initialization
	void Start () {
       tC = GetComponentInParent<TankController>();
	}

    public void Fire()
    {
    //    Debug.Log(fireTime);
        if(fireTime >= rateOfFire)
        {
      //      Debug.Log("I Am Firing");
            fireTime = 0;
            for (int x = 0; x < numberOfProjectiles; ++x)
            {
                Vector3 rot = transform.rotation.eulerAngles;
                rot.y += Random.Range(-deviation, deviation);
                GameObject obj = (GameObject)Instantiate(projectile, transform.position, Quaternion.Euler(rot));
                obj.tag = transform.parent.tag;
            }
            --ammoCount;
        }
    }

	
	// Update is called once per frame
	void Update () {
        if(ammoCount == 0 && !unlimitedAmmo)
        {
            tC.RemoveCannon();
            Destroy(gameObject);
        }
        fireTime += Time.deltaTime;
        fireTime = Mathf.Min(fireTime, rateOfFire);
	}
}
