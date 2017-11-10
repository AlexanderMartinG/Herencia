using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luchador : MonoBehaviour {

	public string nombre;

	// Use this for initialization
	protected void Start () {

		ImprimirNombre ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Imprime el nombre del personaje en la consola de Unity
	protected void ImprimirNombre(){
		print (nombre);
	}
}
