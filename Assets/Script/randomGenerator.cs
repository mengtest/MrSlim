using UnityEngine;
using System.Collections;

public class randomGenerator : MonoBehaviour {

	public GameObject[] listaObjetos;
	public float tiempoMin=1.6f;
	public float tiempoMax=2.5f;
	bool fin=false;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeMuerto");
	}

	void PersonajeMuerto(){
		fin = true;
	}

	void PersonajeEmpiezaACorrer(Notification notificacion){
		generarNivel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void generarNivel(){
		if (!fin) {
			Instantiate (listaObjetos [Random.Range (0, listaObjetos.Length)], transform.position, Quaternion.identity);
			Invoke ("generarNivel", Random.Range (tiempoMin, tiempoMax));
		}
	}
}
