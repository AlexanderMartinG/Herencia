using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : Personajes {
	
	// Update is called once per frame
	protected void Update () {
		PlayerInput (); //Detectar Inputs del usuario cada update
	}
		

	void PlayerInput(){
		if (Input.GetKey ("a"))
			MoverIzquierda ();

		if (Input.GetKey ("d"))
			MoverDerecha ();

		if (Input.GetKeyDown ("space") && !Input.GetKey ("s"))
			Saltar ();
		
		if (Input.GetKeyDown ("space") && Input.GetKey ("s"))
			Atravezar ();
	}
}
