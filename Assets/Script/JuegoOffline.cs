using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class JuegoOffline : MonoBehaviour {

	string offlinePlay = "true";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		this.GetComponent<AudioSource>().Play ();
		PlayerPrefs.SetString("Juego_Offline", offlinePlay);
		//Hay que desabilitar el sonido que este de fondo al hacer click cuando este hecho el clip
		Invoke("offline", 0.5f);
	}

	void offline(){
		SceneManager.LoadScene ("GameScene");
	}
}
