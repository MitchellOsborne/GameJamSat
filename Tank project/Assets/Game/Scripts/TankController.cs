using UnityEngine;
using System.Collections;

public class TankController: MonoBehaviour {
    CharacterController cC;
    [SerializeField]
    private GameObject tankCannon, tankBody;
    [SerializeField]
    private Turret currentCannon;
    [SerializeField]
    float speed = 0;
    [SerializeField]
    GameObject thruster;

    Health hp;
    Vector3 aimDir;
    Vector3 moveVel;

    bool canFire = false;
    
    // Use this for initialization
    void Start () {
        hp = GetComponent<Health>();
        aimDir = Vector2.zero;
        moveVel = Vector2.zero;
        cC = GetComponent<CharacterController>();
        currentCannon = tankCannon.GetComponent<Turret>();
	}
	
    public void OnAxis(string axis, float value)
    {
        switch(axis)
        {
            case "MoveHorizontal":
                moveVel.Set(value,0,moveVel.z);
                break;
            case "MoveVertical":
                moveVel.Set(moveVel.x, 0, value);
                break;
            case "AimHorizontal":
                aimDir.Set(value,0, aimDir.z);
                break;
            case "AimVertical":
                aimDir.Set(aimDir.x,0, value);
                break;
            default:
                break;
        }
    }

    public void OnAction(string action, bool value)
    {
        if (value)
        {
            switch (action)
            {
                case "Shoot":
                    currentCannon.Fire();
                    break;
                case "Boost":
                    break;
                default:
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        currentCannon.transform.LookAt(transform.position + aimDir);
        tankBody.transform.LookAt(transform.position + (moveVel));
        if(moveVel.magnitude != 0)
        {
            thruster.SetActive(true);
        }else
        {
            thruster.SetActive(false);
        }
        cC.SimpleMove(moveVel.normalized*speed);
    }

    public void PickUp(GameObject Turret)
    {
        if (currentCannon.gameObject != tankCannon)
        {
            Destroy(currentCannon);
        }
        else
        {
            tankCannon.SetActive(false);
        }
        GameObject obj = (GameObject)Instantiate(Turret, transform.position, transform.rotation, transform);
        currentCannon = obj.GetComponent<Turret>();
    }

    public void RemoveCannon()
    {
        currentCannon = tankCannon.GetComponent<Turret>();
        tankCannon.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
        
	}
}
