using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class login : MonoBehaviour {

	public InputField user;
	public InputField pass;
	public int id_user;
	public string name_user;
	public string server="http://chickenwinghunter.com/registro.php";
	string boton;
	string offline="false";

	// Use this for initialization
	void Start () {
		GameObject.Find("Error").GetComponent<Renderer>().enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void conectar(){
		StartCoroutine (loguear());
	}

	IEnumerator loguear(){
		if ((user.GetComponent<InputField> ().text != "") && (pass.GetComponent<InputField> ().text!="")) {
			WWWForm formulario = new WWWForm ();
			formulario.AddField ("user", user.GetComponent<InputField> ().text);
			formulario.AddField ("pass", pass.GetComponent<InputField> ().text);
			WWW w = new WWW (server, formulario);
			yield return w;
			if (!string.IsNullOrEmpty (w.error)) {
				Debug.Log (w.text);
				GameObject.Find("Error").GetComponent<Renderer>().enabled=true;
			} else {
				Debug.Log (w.text);
				var cadena = w.text;
				string[] splitCadena;
				splitCadena = cadena.Split (" "[0]);
				id_user=int.Parse(splitCadena[0]);
				name_user = splitCadena [1];
				PlayerPrefs.SetInt ("Id_Usuario", id_user);
				PlayerPrefs.SetString ("Name_Usuario", name_user);
				SceneManager.LoadScene ("GameScene");
				PlayerPrefs.SetString ("Juego_Offline", offline);
			}
		}
	}

	void OnMouseDown(){
		boton = this.gameObject.name;
		if (boton == "IniciarSesion") {
			this.GetComponent<AudioSource> ().Play ();
			if (user.GetComponent<InputField> ().text == "Solid Snake") {
				SceneManager.LoadScene ("easterEgg");
			} else {
				Invoke ("conectar", 0.5f);
			}
		} else {
			this.GetComponent<AudioSource> ().Play ();
			Invoke ("home", 0.5f);
		}
	}

	void home(){
		SceneManager.LoadScene ("Home");
	}
}
