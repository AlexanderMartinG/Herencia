using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : Personajes {

	public bool enRango;
	public float distanciaDeRango;
	public Transform comprobantePiso;
	public Transform heroe;
	public bool puedeSaltar = false;
	public float toleranciaCaida;
	public float toleranciaAlturaHeroe;

	// Use this for initialization
	new protected void Start () {
		base.Start ();
		heroe = GameObject.Find ("Paco").transform;
	}
	
	// Update is called once per frame
	protected void Update () {

		if (puedeMoverse) {

			if (Mathf.Abs (heroe.position.x - transform.position.x) < distanciaDeRango) {
				enRango = true;
			} else {
				enRango = false;
			}
		}

		if (!enRango) {
			if (heroe.position.x > transform.position.x) { // heroe a la derecha del enemigo
				MoverDerecha ();
			}
			if (heroe.position.x < transform.position.x) { // heroe a la izquierda del enemigo
				MoverIzquierda ();
			}
		}

		if (!PisoAdelante () && IsGrounded() && puedeSaltar) {
			Saltar ();
			puedeSaltar = false;
		}

		if (miRB.velocity.y <= 0) {
			puedeSaltar = true;
		}
		
	}

	bool PisoAdelante(){
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (comprobantePiso.position.x,comprobantePiso.position.y), Vector2.down,toleranciaCaida);
		if (hit)
			return true;
		else
			return false;
	}
}
