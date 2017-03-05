using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Text.RegularExpressions;

public class registro : MonoBehaviour {

	public InputField user;
	public InputField mail;
	public InputField pass;
	public InputField repass;
	string boton;
	public string server="http://chickenwinghunter.com/registro.php";

	// Use this for initialization
	void Start () {
		GameObject.Find("Success").GetComponent<Renderer>().enabled=false;
		GameObject.Find ("ErrorPass").GetComponent<Renderer> ().enabled = false;
		GameObject.Find ("EmptyField").GetComponent<Renderer> ().enabled = false;
		GameObject.Find ("UsuarioExistente").GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void signup(){
		StartCoroutine (registrar());
	}

	IEnumerator registrar(){
		if (pass.GetComponent<InputField> ().text == repass.GetComponent<InputField> ().text) {
			if ((user.GetComponent<InputField> ().text != "") && (pass.GetComponent<InputField> ().text != "") && (mail.GetComponent<InputField> ().text != "") && (repass.GetComponent<InputField> ().text != "")) {
				WWWForm formulario = new WWWForm ();
				formulario.AddField ("user", user.GetComponent<InputField> ().text);
				formulario.AddField ("pass", pass.GetComponent<InputField> ().text);
				formulario.AddField ("mail", mail.GetComponent<InputField> ().text);
				formulario.AddField ("repass", repass.GetComponent<InputField> ().text);

				WWW w = new WWW (server, formulario);
				yield return w;
				if (!string.IsNullOrEmpty (w.error)) {
					//Debug.Log (w.text);
					if (w.text == "UsuarioExistente") {
						GameObject.Find("UsuarioExistente").GetComponent<Renderer>().enabled=true;
					}
				} else {
					GameObject.Find ("Success").GetComponent<Renderer> ().enabled = true;
					GameObject.Find ("ErrorPass").GetComponent<Renderer> ().enabled = false;
					GameObject.Find ("EmptyField").GetComponent<Renderer> ().enabled = false;
				}
			} else {
				GameObject.Find ("EmptyField").GetComponent<Renderer> ().enabled = true;
				GameObject.Find ("Success").GetComponent<Renderer> ().enabled = false;
				GameObject.Find ("ErrorPass").GetComponent<Renderer> ().enabled = false;
			}
		} else {
			GameObject.Find ("ErrorPass").GetComponent<Renderer> ().enabled = true;
			GameObject.Find ("Success").GetComponent<Renderer> ().enabled = false;
			GameObject.Find ("EmptyField").GetComponent<Renderer> ().enabled = false;
		}
	}

	void OnMouseDown(){
		boton = this.gameObject.name;
		if (boton == "Registrar") {
			this.GetComponent<AudioSource> ().Play ();
			Invoke ("signup", 0.5f);
		} else {
			this.GetComponent<AudioSource> ().Play();
			Invoke ("home", 0.5f);
		}
	}

	void home(){
		SceneManager.LoadScene ("Home");
	}
}
