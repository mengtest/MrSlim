using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class destructor : MonoBehaviour {

	public string puntuacion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			//Debug.Break ();
			NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeMuerto");
			GameObject personaje = GameObject.Find ("player");
			personaje.SetActive (false);
			puntuacion = GameObject.Find ("Marcador").GetComponent<TextMesh> ().text;
			PlayerPrefs.SetString ("Puntuacion", puntuacion);
			SceneManager.LoadScene ("GameOver");
		} else {
			Destroy (col.gameObject);
		}
	}
}
