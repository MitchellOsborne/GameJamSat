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

    TankController tC;

	private Player player;

	[System.NonSerialized]
	private bool initialized;

	private void Initialize() {
		player = ReInput.players.GetPlayer(playerId);
		initialized = true;
	}

    void Start()
    {
        tC = GetComponent<TankController>();
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
		tC.OnAxis("MoveHorizontal", player.GetAxis("MoveHorizontal"));
        tC.OnAxis("MoveVertical", player.GetAxis("MoveVertical"));
        tC.OnAxis("AimHorizontal", player.GetAxis("AimHorizontal"));
        tC.OnAxis("AimVertical", player.GetAxis("AimVertical"));
        tC.OnAction("Shoot", player.GetButtonDown("Shoot"));
        tC.OnAction("Boost", player.GetButtonDown("Boost"));
	}
}
