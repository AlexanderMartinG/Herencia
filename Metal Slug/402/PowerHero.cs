using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerHero : Heroe {
	[Tooltip("Prefab de bala que se disparará")]
	public GameObject bala;

	[Tooltip("Donde se generará la bala")]
	public Transform canonDePistola;

	[Tooltip("Pivote para apuntar el arma que representa el hombro")]
	public Transform hombro;

	
	// Update is called once per frame
	new void Update () {
		base.Update ();

		if (Input.GetMouseButtonDown (0)) {
			Disparar ();
		}

		if (Input.GetKey ("w")) { //apuntar hacia arriba
			hombro.localRotation = Quaternion.Euler (0, 0, 90);
		} 

		if (Input.GetKey ("s")) { //apuntar hacia abajo
			hombro.localRotation = Quaternion.Euler (0, 0, -90);
		} 

		if (!Input.GetKey("w") && !Input.GetKey("s")){ //apuntar hacia enfrente
			hombro.localRotation = Quaternion.Euler (0, 0, 0);
		}

		if (Input.GetKey ("x"))
			puedeMoverse = false;
		else
			puedeMoverse = true;

	}

	void Disparar(){
		Instantiate (bala, canonDePistola.position,hombro.rotation);
	}
		
}
