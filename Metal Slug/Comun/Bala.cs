using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	[Tooltip("Velocidad constante que tiene la bala")]
	public float velocidad;

	[Tooltip("Daño que inflige la bala al colisionar con un personaje")]
	public int dano;

	private Rigidbody2D miRB; //referencia a Rigidbody 2D

	// Use this for initialization
	void Start () {

		miRB = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		miRB.velocity = Vector2.right * velocidad; //mover constantemente la bala en eje X
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Personajes") {
			col.gameObject.SendMessage ("SufrirDaño", dano);
		}

	}

}
