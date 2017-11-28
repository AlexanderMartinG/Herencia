using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoides : MonoBehaviour {

	[Header ("Caractersiticas")]
	[Tooltip ("Nombre del personaje")]
	public string nombre;
	[Tooltip ("Puntos de salud del personaje")]
	public int salud;
	[Tooltip ("Cantidad de veces que un personaje puede usar habilidad especial")]
	public int special;
	[Tooltip ("Nivel de poder del personaje")]
	public int nivel;

	[Header ("Movimiento")]
	[Tooltip ("El personaje puede moverse o es estatico")]
	public bool puedeMoverse;
	[Tooltip ("Velocidad de Movimiento en eje X")]
	public float velocidadMovimiento;
	[Tooltip ("Cantidad de impulso vertical que gana el personaje al saltar")]
	public float distanciaSalto;

	[HideInInspector]
	public Collider2D miColisionador; //referencia a colisionador del gameObject
	[HideInInspector]
	public Vector3 posicion; //referencia a posicion del gameObject}
	[HideInInspector]
	public Rigidbody2D miRB; //referencia al Rigidbody del gameObject

	public Transform limiteAterrizado; //posicion de los pies del personaje
	[Tooltip ("Tolerancia de distancia entre los pies del personaje y el suelo")]
	public float toleranciaPiso; // Tolerancia de distancia entre los pies del personaje y el suelo

	[Header ("Graficos y Animaciones")]
	[Tooltip ("Referencia a la malla tridimensional del personaje")]
	public Transform malla3D;


	// Use this for initialization
	protected void Start () {
		miRB = gameObject.GetComponent<Rigidbody2D> (); //abreviacion de Rigidbody
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Funcion de Salto
	protected void Jump(){
		miRB.AddForce ((Vector2.up * distanciaSalto),ForceMode2D.Impulse);
	}

	//Funcion Grounded 3D
	/*protected bool Grounded(Transform limitePies, float tolerancia){
		RaycastHit hit;
		if(Physics.Raycast(limitePies.position,-Vector3.up,out hit) && hit.distance < tolerancia){
			return true;
		}else{
			return false;
		}
	}*/

	//Funcion Grounded 2D
	protected bool Grounded(){
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (limiteAterrizado.position.x,limiteAterrizado.position.y), -Vector2.up, toleranciaPiso);
		if (hit.transform.gameObject.layer == 8) {
			return true;
		} else {
			return false;
		}
	}

	//Funcion Recibir Daño
	void RecibirDano(int cantidadDano){

		salud = salud - cantidadDano;

		if (salud <= 0) {
			Morir ();
		}
	}

	//Funcion de muerte del personaje
	void Morir (){
		Destroy (gameObject);
	}
}
