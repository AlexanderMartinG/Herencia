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

			if (Input.GetKey ("a")) { // movimiento hacia la izquierda
				miRB.velocity = new Vector2 (-velocidadMovimiento,miRB.velocity.y);
				malla3D.localRotation = Quaternion.Euler (0, 180, 0);
			}
			if (Input.GetKey ("d")) { // movimiento hacia la derecha
				miRB.velocity = new Vector2 (velocidadMovimiento,miRB.velocity.y);
				malla3D.localRotation = Quaternion.Euler (0, 0, 0);

			}

			if (Input.GetKeyDown ("space") && Grounded()) { // Ejecutar un salto con la funcion Jump.
				Jump();
			}

			if (Input.GetKey ("s") && Input.GetKeyDown ("space")) { //Atravezar plataforma
				StartCoroutine (AtravezarPlataforma ());
			}
		}	
	}

	IEnumerator AtravezarPlataforma(){ // Desactiva el colisionador por 0.5 segundos
		miColisionador.enabled = false;
		yield return new WaitForSeconds (0.5f);
		miColisionador.enabled = true;
	}

}
