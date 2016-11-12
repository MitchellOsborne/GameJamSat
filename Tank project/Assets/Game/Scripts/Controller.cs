using UnityEngine;
using System.Collections.Generic;
using Rewired;

[AddComponentMenu("")]
public class Controller : MonoBehaviour {

	[SerializeField]
	private int playerId = 0;

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
        tC.OnAction("Shoot", player.GetButton("Shoot"));
        tC.OnAction("Boost", player.GetButtonDown("Boost"));
	}

	public static void Vibrate(float lAmount = 1, float rAmount = 1, float lDuration = 0.5f, float rDuration = 0.5f){
		// Set vibration for a certain duration
		IList<Player> players = ReInput.players.GetPlayers();

		foreach (Player p in players) {
			foreach (Joystick j in p.controllers.Joysticks) {
				if (!j.supportsVibration)
					continue;
				if (j.vibrationMotorCount > 0)
					j.SetVibration (lAmount, rAmount, lDuration, rDuration);
			}
		}
	}
}
