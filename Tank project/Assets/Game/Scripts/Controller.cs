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

	private Player player;

	[System.NonSerialized]
	private bool initialized;

	private void Initialize() {
		player = ReInput.players.GetPlayer(playerId);
		initialized = true;
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
		//OnAxis("MoveHorizontal", player.GetAxis("MoveHorizontal"));
		//OnAxis("MoveVertical", player.GetAxis("MoveVertical"));
		//OnAction("Shoot", player.GetButtonDown("Shoot"));
		//OnAction("Boost", player.GetButtonDown("Boost"));
	}
}
