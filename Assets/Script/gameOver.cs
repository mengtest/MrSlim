using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {
	string nombre;
	string puntuacion;
	string offline;

	// Use this for initialization
	void Start () {
		offline = PlayerPrefs.GetString ("Juego_Offline");
		nombre = PlayerPrefs.GetString ("Name_Usuario");
		puntuacion = PlayerPrefs.GetString ("Puntuacion");
		if(offline=="true"){
			GameObject.Find("Usuario").GetComponent<TextMesh>().text="Invitado";
		}else{
			GameObject.Find ("Usuario").GetComponent<TextMesh>().text = nombre;
		}
		GameObject.Find ("Points").GetComponent<TextMesh> ().text = puntuacion;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
