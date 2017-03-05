using UnityEngine;
using System.Collections;

public class puntosBloque : MonoBehaviour {

	bool colision=false;
	int puntosSuelo=1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (!colision && col.gameObject.tag=="Player") {
			colision = true;
			GameObject parte = col.contacts [0].collider.gameObject;
			if (parte.name == "pierna_derecha_2" || parte.name == "pierna_izquierda_2" || parte.name == "pie_derecho" || parte.name == "pie_izquierdo") {
				NotificationCenter.DefaultCenter ().PostNotification (this, "IncrementarPuntos", puntosSuelo);
			}
		}
	}
}
