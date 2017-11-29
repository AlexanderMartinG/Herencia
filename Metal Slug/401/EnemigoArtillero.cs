using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoArtillero : Enemigo {

	[Header ("Comportamiento de Disparo")]
	[Tooltip("prefab de bala a instanciar en cada disparo")]
	public GameObject bala; //prefab de bala a instanciar en cada disparo

	[Tooltip("posicion donde se instanciara la bala")]
	public Transform canonDePistola; // posicion donde se instanciara la bala

	[Tooltip("Pivote para apuntar la pistola")]
	public Transform hombro;

	public float alcance;

	// Use this for initialization
	new void Start () {
		base.Start ();
		
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();

		if (EnLaMira ()) {
			Disparar ();
		}
		
	}

	//Funcion que instancia un clon de una bala
	void Disparar(){
		Instantiate (bala, canonDePistola.position, hombro.rotation);
	}

	bool EnLaMira(){
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (canonDePistola.position.x, canonDePistola.position.y), transform.right, alcance);
		if (hit) {
			if (hit.transform.gameObject.layer == 10) {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}
}

