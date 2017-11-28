using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : Personajes {
	
	// Update is called once per frame
	protected void Update () {

		if (Input.GetKey ("a")) { // Movimiento hacia la Izquierda

			miRB.velocity = new Vector2 (-velocidadMovimiento, miRB.velocity.y);

			malla3D.localRotation = new Quaternion (0, 180, 0, 0);

		}
		if (Input.GetKey ("d")) { // Movimiento hacia la Derecha

			miRB.velocity = new Vector2 (velocidadMovimiento, miRB.velocity.y);

			malla3D.localRotation = new Quaternion (0, 0, 0, 0);	

		}
		if (Input.GetKeyDown ("space") && IsGrounded() && !Input.GetKey("s")) { //Salto
			miRB.AddForce(new Vector2 (0, fuerzaSalto),ForceMode2D.Impulse);
		}
		if (Input.GetKey("s") && Input.GetKeyDown ("space") && puedeAtravezar()) { //Atravezar plataformas
			StartCoroutine(AtravezarPlataforma());
		}
		
	}

	//Corrutina para desactivar y reactivar el collider del personaje para poder atravezar plataformas
	IEnumerator AtravezarPlataforma(){
		miCollider.enabled =false; // desactiva collider
		yield return new WaitForSeconds (1f);
		miCollider.enabled = true; // reactiva collider
	}
}
