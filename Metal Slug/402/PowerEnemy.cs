using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEnemy : Enemigo {

	public GameObject bala;

	public Transform canonDePistola;

	public Transform hombro;

	public float rangoDeDisparo;

	public bool puedeDisparar = true;

	public float enfriamenteDisparar;

	// Use this for initialization
	new void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();

		if (EnLaMira () && puedeDisparar) {
			StartCoroutine (ComenzarDisparo ());
			StartCoroutine (EnfriarDisparo ());
		}
	}

	bool EnLaMira(){
		RaycastHit2D hit = (Physics2D.Raycast(new Vector2(canonDePistola.position.x,canonDePistola.position.y), canonDePistola.right,rangoDeDisparo));
		if (hit) {
			if (hit.transform.gameObject.tag == "Personajes") {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}

	void Disparar(){
		Instantiate (bala, canonDePistola.position,hombro.rotation);
	}

	IEnumerator ComenzarDisparo(){
		yield return new WaitForSeconds (0.3f);
		if (EnLaMira ()) {
			Disparar ();
		}
	}
	IEnumerator EnfriarDisparo(){
		puedeDisparar = false;
		yield return new WaitForSeconds (enfriamenteDisparar);
		puedeDisparar = true;
	}
}
