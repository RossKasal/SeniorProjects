using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Time.deltaTime;
		//print (transform.position.x);
		//print (transform.position.y);
		//print (transform.position.z);
	}
}