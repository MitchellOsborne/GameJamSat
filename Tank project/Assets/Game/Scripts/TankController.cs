using UnityEngine;
using System.Collections;

public class TankController: MonoBehaviour {
    CharacterController cC;
    [SerializeField]
    GameObject tankCannon, tankBody;
    [SerializeField]
    float speed = 0;
    Vector3 aimDir;
    Vector3 moveVel;
    
    // Use this for initialization
    void Start () {
        aimDir = Vector2.zero;
        moveVel = Vector2.zero;
        cC = GetComponent<CharacterController>();
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
        switch (action)
        {
            case "Shoot":
                break;
            case "Boost":
                break;
            default:
                break;
        }
    }

    void FixedUpdate()
    {
        tankCannon.transform.LookAt(transform.position + aimDir);
        tankBody.transform.LookAt(transform.position + (moveVel));
        cC.SimpleMove(moveVel.normalized*speed);
    }

    public void PickUp(GameObject Turret)
    {
        //Add Turret to Cannon
    }

	// Update is called once per frame
	void Update () {
	}
}
