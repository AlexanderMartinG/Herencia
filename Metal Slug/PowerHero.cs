using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerHero : Heroe {
	[Tooltip("Prefab de bala que se disparará")]
	public GameObject bala;

	[Tooltip("Donde se generará la bala")]
	public Transform canonDePistola;

	
	// Update is called once per frame
	new void Update () {
		base.Update ();

		if (Input.GetMouseButtonDown (0)) {
			Disparar ();
		}

	}

	void Disparar(){
		Instantiate (bala, canonDePistola.position, Quaternion.identity);
	}
		
}
