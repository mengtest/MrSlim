using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class inicio : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		this.GetComponent<AudioSource>().Play ();
		//Hay que desabilitar el sonido que este de fondo al hacer click cuando este hecho el clip
		Invoke("inicioPantalla", 0.5f);
	}

	void inicioPantalla(){
		SceneManager.LoadScene ("MainScene");
	}
}
