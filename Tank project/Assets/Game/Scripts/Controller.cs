using UnityEngine;
using System.Collections;
using Rewired;

[AddComponentMenu("")]
public class Controller : MonoBehaviour {

	[SerializeField]
	private int playerId = 0;

	[SerializeField]
	private Vector2 movement, aiming;

	[SerializeField]
	private bool shoot, boost;

    TankMovement tM;

	private Player player;

	[System.NonSerialized]
	private bool initialized;

	private void Initialize() {
		player = ReInput.players.GetPlayer(playerId);
		initialized = true;
	}

    void Start()
    {
        tM = GetComponent<TankMovement>();
    }

	// Update is called once per frame
	void Update () {
		if (!ReInput.isReady)
			return;
		if (!initialized)
			Initialize ();

		ProcessInput ();
	}

	private void ProcessInput(){
		tM.OnAxis("MoveHorizontal", player.GetAxis("MoveHorizontal"));
        tM.OnAxis("MoveVertical", player.GetAxis("MoveVertical"));
        tM.OnAxis("AimHorizontal", player.GetAxis("AimHorizontal"));
        tM.OnAxis("AimVertical", player.GetAxis("AimVertical"));
        tM.OnAction("Shoot", player.GetButtonDown("Shoot"));
        tM.OnAction("Boost", player.GetButtonDown("Boost"));
	}
}
