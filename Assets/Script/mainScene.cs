using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class mainScene: MonoBehaviour {


	void Start(){

	}

	void OnMouseDown(){
		this.GetComponent<AudioSource>().Play ();
		//Hay que desabilitar el sonido que este de fondo al hacer click cuando este hecho el clip
		Invoke("cargarJuego", 0.5f);
	}

	void cargarJuego(){
		SceneManager.LoadScene ("Home");
	}


}
