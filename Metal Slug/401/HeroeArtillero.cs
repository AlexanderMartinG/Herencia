using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroeArtillero : Heroe {

	[Tooltip("prefab de bala a instanciar en cada disparo")]
	public GameObject bala; //prefab de bala a instanciar en cada disparo

	[Tooltip("posicion donde se instanciara la bala")]
	public Transform canonDePistola; // posicion donde se instanciara la bala

	[Tooltip("Pivote para apuntar la pistola")]
	public Transform hombro;

	// Use this for initialization
	new void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();

		if (Input.GetMouseButtonDown (0)) { // Disparar
			Disparar ();
		}

		if (Input.GetKey ("w")) { // Apuntar hacia Arriba
			hombro.localRotation = Quaternion.Euler (0, 0, 90);
		}

		if (Input.GetKey ("s")) { // Apuntar hacia Arriba
			hombro.localRotation = Quaternion.Euler (0, 0, -90);
		}

		if (!Input.GetKey ("w") && !Input.GetKey ("s")) { // Reiniciar angulo de hombro
			hombro.localRotation = Quaternion.Euler (0, 0, 0);
		}

	}

	//Funcion que instancia un clon de una bala
	void Disparar(){
		Instantiate (bala, canonDePistola.position, hombro.rotation);
	}
}
