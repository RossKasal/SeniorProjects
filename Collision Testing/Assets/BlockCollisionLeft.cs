using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollisionLeft : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
}