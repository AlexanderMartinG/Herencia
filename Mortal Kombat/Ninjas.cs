using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninjas : Luchador {

	public Color myColor;

	// Use this for initialization
	new void Start () {
		base.Start ();

		//Asigna color al material de los ninjas
		gameObject.GetComponent<Renderer> ().material.color = myColor;

	}

	// Update is called once per frame
	void Update () {

	}
}
