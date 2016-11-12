using UnityEngine;
using System.Collections;

public class Ripple : MonoBehaviour {

	[SerializeField]
	private float radius = 0.01f, waveSpeed = 5, amp = 0.01f, size = 0.2f;

	// Use this for initialization
	void Start () {
		ShockWave.Get().StartIt(transform.position, radius, waveSpeed, amp, size);
	}
}
