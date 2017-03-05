using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class homeScene : MonoBehaviour {

	string boton;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown(){
		boton=this.gameObject.name;
		switch (boton) {
		case "Login":
			this.GetComponent<AudioSource> ().Play ();
			Invoke ("loginScene", 0.5f);
			break;
		case "SignUp":
			Invoke ("signUpScene", 0.5f);
			this.GetComponent<AudioSource> ().Play ();
			break;
		}
	}

	void loginScene(){
		SceneManager.LoadScene ("LoginScene");
	}

	void signUpScene(){
		SceneManager.LoadScene ("SignupScene");
	}
}
