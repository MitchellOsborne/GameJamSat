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

    [SerializeField]
    float muzzleDuration = 0;
    float timer = 0;

    [SerializeField]
    private GameObject muzzleFlash;

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
            muzzleFlash.SetActive(true);
            timer = 0;
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

        timer += Time.deltaTime;
        if(timer > muzzleDuration)
        {
            muzzleFlash.SetActive(false);
            timer = 0;
        }
	}
}
