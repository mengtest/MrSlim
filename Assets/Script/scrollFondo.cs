using UnityEngine;
using System.Collections;

public class scrollFondo : MonoBehaviour {

	Renderer render;
	public bool iniciarEnMovimiento=false;
	public float velocidad=0f;
	bool enMovimiento=false;
	float tiempoInicio=0f;

	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer>();
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeMuerto");
		if (iniciarEnMovimiento) {
			PersonajeEmpiezaACorrer ();
		}
	}

	void PersonajeMuerto(){
		enMovimiento = false;	
	}

	void PersonajeEmpiezaACorrer(){
		enMovimiento = true;
		tiempoInicio = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (enMovimiento) {
			render.material.mainTextureOffset = new Vector2 (((Time.time-tiempoInicio) * velocidad)%1, 0);
		}
	}

}
