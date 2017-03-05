using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(GameObject.Find("Music"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
