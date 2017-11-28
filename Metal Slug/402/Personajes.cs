using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personajes : MonoBehaviour {

	[Header ("Caracteristicas del personaje")]
	[Tooltip ("Nombre que se asigna al personaje")]
	public string nombre; //nombre del personaje
	[Tooltip ("Nivel de poder que se asigna al personaje")]
	public int nivel; //nivel de poder del personaje
	[Tooltip ("Cantidad de Puntos de Salud restantes del personaje")]
	public int puntosSalud = 100; //puntos de salud iniciales del personaje
	[Tooltip ("Cantidad de Puntos de Especial restantes del personaje")]
	public int Especial = 100; //puntos de habilidad especial iniciales del personaje

	[HideInInspector]
	public Collider2D miCollider; //Collider del personaje
	[HideInInspector]
	public Vector3 posicion; //Posicion del personaje del personaje
	[HideInInspector]
	public Rigidbody2D miRB; //Referencia al Rigidbody del gameObject
	[Tooltip ("Empty en los pies del personaje")]
	public Transform limiteSuelo; // Referencia a empty en los pies del personaje
	[Tooltip ("Tolerancia de distancia entre los pies del personaje y el suelo")]
	public float toleranciaSuelo; // Tolerancia de distancia entre los pies del personaje y el suelo

	[Header ("Movimiento y Controles")]
	[Tooltip ("Define si el personaje se puede mover o es estatico")]
	public bool puedeMoverse; //Define si el personaje se puede mover o es estatico
	[Tooltip ("Define cuantas  unidades se mueve el personaje en el eje X")]
	public float velocidadMovimiento; //velocidad de movimiento del personaje en eje X
	[Tooltip ("Define el Impulso que el personaje ganara en el eje Y al saltar")]
	public float fuerzaSalto; //Define el Impulso que el personaje ganara en el eje Y al saltar

	[Header ("Graficos y Animaciones")]
	[Tooltip ("Referencia la malla 3D o Sprite del Personaje")]
	public Transform malla3D; // Referencia a malla tridimensional o Sprite el personaje

	// Use this for initialization
	protected void Start () {
		
		miRB = gameObject.GetComponent<Rigidbody2D> (); //Referencia a Rigidbody del gameObject
		miCollider = gameObject.GetComponent<Collider2D> (); //Referencia a Collider2D del gameObject

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Funcion para sufrir Daño
	void SufrirDaño(int cantidadDaño){
		
		puntosSalud = puntosSalud - cantidadDaño; //resta cantidad de daño a puntos de salud

		if (puntosSalud <= 0){ // Si la Salud llega a 0
			Muerte (); //Mata al personaje
		}
	}

	//Muerte del personaje
	void Muerte(){
		Destroy (gameObject);
	}

	//Esta aterrizado
	protected bool IsGrounded(){
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (limiteSuelo.position.x, limiteSuelo.position.y), Vector2.down, toleranciaSuelo);
		if (hit.transform.gameObject.layer == 8 || hit.transform.gameObject.layer == 9 ) {
			return true;
		} else {
			return false;
		}
	}

	//Puede Atravezar plataformas
	protected bool puedeAtravezar(){
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (limiteSuelo.position.x, limiteSuelo.position.y), Vector2.down, toleranciaSuelo);
		if (hit.transform.gameObject.layer == 9) {
			return true;
		} else {
			return false;
		}
	}

	//Corrutina para desactivar y reactivar el collider del personaje para poder atravezar plataformas
	IEnumerator AtravezarPlataforma(){
		miCollider.enabled =false; // desactiva collider
		yield return new WaitForSeconds (1f);
		miCollider.enabled = true; // reactiva collider
	}

	///////////FUNCIONES MOVIMIENTO//////////////

	protected void MoverIzquierda(){ // Movimiento hacia la Izquierda
		miRB.velocity = new Vector2 (-velocidadMovimiento, miRB.velocity.y);
		malla3D.localRotation = new Quaternion (0, 180, 0, 0);
	}

	protected void MoverDerecha(){ // Movimiento hacia la derecha
		miRB.velocity = new Vector2 (velocidadMovimiento, miRB.velocity.y);
		malla3D.localRotation = new Quaternion (0, 0, 0, 0);	
	}

	protected void Saltar(){
		if(IsGrounded())
			miRB.AddForce(new Vector2 (0, fuerzaSalto),ForceMode2D.Impulse);
	}

	protected void Atravezar(){
		if (puedeAtravezar())
			StartCoroutine(AtravezarPlataforma());
	}
}
