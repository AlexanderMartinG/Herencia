using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : Humanoides {

	[Tooltip ("Determina si el personaje actualmente esta siendo controlado")]
	public bool esControlado; // Determina si el personaje actualmente esta siendo controlado

	// Use this for initialization
	new protected void Start () {
		base.Start (); // Metodo Start de clase humanoides
	}
	
	// Update is called once per frame
	protected void Update () {
		// Verificar si el personaje esta siendo controlado
		if (esControlado) {

			PlayerInput ();

		}	
	}

	void PlayerInput(){
		
		if (Input.GetKey ("a")) { // movimiento hacia la izquierda
			MoverIzquierda();
		}

		if (Input.GetKey ("d")) { // movimiento hacia la derecha
			MoverDerecha();
		}

		if (Input.GetKeyDown ("space") && !Input.GetKey("s")) { // Ejecutar un salto con la funcion Jump.
			if(Grounded())
				Jump();
		}

		if (Input.GetKey ("s") && Input.GetKeyDown ("space")) { //Atravezar plataforma
			if (Grounded () && PuedeAtravezar())
				Atravezar();
		}
	}
}
