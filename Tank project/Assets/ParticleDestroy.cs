﻿using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {
	void Start () {
		Destroy(gameObject, GetComponent<ParticleSystem>().duration); 
	}
}