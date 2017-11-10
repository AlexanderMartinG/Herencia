using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : Personajes {
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("a")) { // Movimiento hacia la Izquierda

			miRB.velocity = new Vector3 (-velocidadMovimiento, miRB.velocity.y, miRB.velocity.z);

			malla3D.localRotation = new Quaternion (0, 180, 0, 0);

		}
		if (Input.GetKey ("d")) { // Movimiento hacia la Derecha

			miRB.velocity = new Vector3 (velocidadMovimiento, miRB.velocity.y, miRB.velocity.z);

			malla3D.localRotation = new Quaternion (0, 0, 0, 0);	

		}
		if (Input.GetKeyDown ("space") && IsGrounded()) { //Salto
			miRB.AddForce(new Vector3 (0, fuerzaSalto,0),ForceMode.Impulse);
		}
		
	}
}
