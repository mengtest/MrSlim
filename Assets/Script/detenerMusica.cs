using UnityEngine;
using System.Collections;

public class detenerMusica : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (GameObject.Find ("Music"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
