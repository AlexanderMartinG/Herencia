using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : Humanoides {

	[HideInInspector]
	public bool enRango;

	public float distanciaDeRango;
	public Transform comprobantePiso;

	[HideInInspector]
	public Transform heroe;

	private bool puedeSaltar = true;
	public float toleranciaCaida;

	// Use this for initialization
	new protected void Start () {
		base.Start ();
		heroe = GameObject.Find ("Marco").transform;
	}
	
	// Update is called once per frame
	protected void Update () {
		
		if (puedeMoverse) {
			if (Mathf.Abs (heroe.position.x - transform.position.x) > distanciaDeRango) {
				enRango = false;
			} else {
				enRango = true;
			}

			if (!enRango) {
				if (heroe.position.x > transform.position.x) { //Detecta si el heroe esta a la derecha
					MoverDerecha();
				}
				if (heroe.position.x < transform.position.x) { //Detecta si el heroe esta a la Izquierda
					MoverIzquierda();
				}
			}
			if (!PisoAdelante () && Grounded () && puedeSaltar) {
				Jump ();
				puedeSaltar = false;
			}

			if (miRB.velocity.y <= 0) {
				puedeSaltar = true;
			}
		}
	}

	bool PisoAdelante(){
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (comprobantePiso.position.x, comprobantePiso.position.y), Vector2.down, toleranciaCaida);
		if (hit) {
			return true;
		} else {
			return false;
		}
	}
}
