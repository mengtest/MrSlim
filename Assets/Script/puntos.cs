using UnityEngine;
using System.Collections;

public class puntos : MonoBehaviour {

	int puntuacion=0;
	public TextMesh marcador;
	public int user;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver (this, "IncrementarPuntos");
		Marcador ();
	}

	void IncrementarPuntos(Notification notificacion){
		int puntosSumar = (int)notificacion.data;
		puntuacion += puntosSumar;
		Marcador ();
		user = PlayerPrefs.GetInt ("Id_Usuario");
	}

	void Marcador(){
		marcador.text = puntuacion.ToString ();
	}


	// Update is called once per frame
	void Update () {
	
	}
}
