using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
    [SerializeField]
    float rateOfFire;
    float fireTime = 0;
    //[SerializeField]
    //int ammoCount;
    [SerializeField]
    GameObject projectile;

    //TankController tC;

	// Use this for initialization
	void Start () {
    //   tC = GetComponentInParent<TankController>();
	}

    public void Fire()
    {
    //    Debug.Log(fireTime);
        if(fireTime >= rateOfFire)
        {
      //      Debug.Log("I Am Firing");
            fireTime = 0;
            GameObject obj = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            obj.tag = transform.parent.tag;
            //--ammoCount;
        }
    }

	
	// Update is called once per frame
	void Update () {
        //if(ammoCount == 0)
        //{
            //Reset Cannon to default cannon
        //    Destroy(gameObject);
        //}
        fireTime += Time.deltaTime;
        fireTime = Mathf.Min(fireTime, rateOfFire);
	}
}
