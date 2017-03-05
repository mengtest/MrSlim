using UnityEngine;
using System.Collections;

public class enlacePagina : MonoBehaviour {

	string pagina="http://chickenwinghunter.com/";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Application.OpenURL (pagina);
	}
}
