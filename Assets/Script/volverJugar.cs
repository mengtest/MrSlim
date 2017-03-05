using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class volverJugar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		this.GetComponent<AudioSource> ().Play ();
		Invoke ("reinicio", 0.5f);
	}

	void reinicio(){
		SceneManager.LoadScene ("GameScene");
	}
}
