using UnityEngine;
using System.Collections;

public class camara : MonoBehaviour {

	public Transform personaje;
	public float separacion=8.23f;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (personaje.position.x+separacion, transform.position.y, transform.position.z);
	}
}
