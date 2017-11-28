using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform personaje;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (personaje == null)
			personaje = GameObject.Find ("Paco").transform;
		else 
			transform.position = new Vector3 (personaje.position.x, personaje.position.y, -10);
	}
}
