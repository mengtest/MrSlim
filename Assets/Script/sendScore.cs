using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sendScore : MonoBehaviour {

	public string server="localhost:81/score.php";
	int usuario;
	int puntuacion;
	string offline;

	// Use this for initialization
	void Start () {
		usuario = PlayerPrefs.GetInt ("Id_Usuario");
		puntuacion = int.Parse(GameObject.Find ("Points").GetComponent<TextMesh> ().text);
		registrarPuntuacion ();
	}
		
	public void registrarPuntuacion(){
		offline = PlayerPrefs.GetString ("Juego_Offline");
		Debug.Log (offline);
		if (offline != "true") {
			StartCoroutine (mandarPuntos());
		}
	}

	IEnumerator mandarPuntos(){
		WWWForm formulario = new WWWForm ();
		formulario.AddField ("usuario", usuario);
		formulario.AddField ("puntuacion", puntuacion);

		WWW w = new WWW (server, formulario);
		yield return w;
		if (!string.IsNullOrEmpty (w.text)) {
			Debug.Log (w.text);
		}else{
			Debug.Log ("Exito");
		}
	} 
}
