using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

	int collision = 0;
	double start_time = 0.0;
	double end_time = 0.0;
	double difference = 0.0;
	double timer1 = 0.0;
	double timer2 = 0.0;

	// Use this for initialization
	void Start () {
		print ("Started");
	}

	IEnumerator AudioDelay()
	{
		print(Time.time);
		yield return new WaitForSecondsRealtime(1);
		print(Time.time);
	}
	
	// Update is called once per frame
	void Update () {
		AudioSource audio = GetComponent<AudioSource> ();
		if (collision == 0) {
			transform.position += Vector3.left * Time.deltaTime;
		} else if (collision == 1) {
			transform.position += Vector3.back * Time.deltaTime;
		} else if (collision == 2) {
			transform.position += Vector3.left * Time.deltaTime;
			timer1 = Time.time;
			if (timer1 >= end_time + 3.0) {
				collision = 3;
				timer2 = timer1;
			}
		} else if (collision == 3) {
			transform.position += Vector3.forward * Time.deltaTime; 
			timer2 += Time.deltaTime;
			if (timer2 >= timer1 + difference) {
				collision = 0;
			}
		} else if (collision == 4) {
			transform.position += Vector3.forward * Time.deltaTime;
		} else if (collision == 5) {
			transform.position += Vector3.left * Time.deltaTime;
			timer1 = Time.time;
			if (timer1 >= end_time + 3.0) {
				collision = 6;
				timer2 = timer1;
			}
		} else if (collision == 6) {
			transform.position += Vector3.back * Time.deltaTime; 
			timer2 += Time.deltaTime;
			if (timer2 >= timer1 + difference) {
				collision = 0;
			}
		} else if (collision == 7) {
			transform.position += Vector3.zero * Time.deltaTime;
			collision = 1;
		} else if (collision == 8) {
			transform.position += Vector3.zero * Time.deltaTime;
			collision = 4;
		} else if (collision == 9) {
			audio.Play ();
			transform.position += Vector3.zero * Time.deltaTime;
			collision = 2;
		} else if (collision == 10) {
			audio.Play ();
			transform.position += Vector3.zero * Time.deltaTime;
			collision = 5;
		}
	}

	void OnCollisionEnter(Collision col) {
		print ("collision");
		if (col.gameObject.name == "Cube") {
			start_time = Time.time;
			//Destroy (col.gameObject);
			collision = 7;
		} else if (col.gameObject.name == "Cube1") {
			start_time = Time.time;
			collision = 8;
		}
	}

	void OnCollisionExit(Collision col) {
		end_time = Time.time;
		print ("leaving");
		difference = end_time - start_time;
		print ("difference " + difference);
		if (col.gameObject.name == "Cube") {
			col.gameObject.name = "CubePassed";
			collision = 9;
		} else if (col.gameObject.name == "Cube1") {
			col.gameObject.name = "CubePassed1";
			collision = 10;}
	}
}