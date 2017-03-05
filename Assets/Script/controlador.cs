using UnityEngine;
using System.Collections;

public class controlador : MonoBehaviour {

	public float fuerzaSalto=100f;
	Rigidbody2D rb;
	bool contactoSuelo=true;
	public Transform posicion;
	float radio=0.07f;
	public LayerMask suelo;
	bool saltoDoble=false;
	Animator animator;
	bool correr = false;
	public float velocidad = 1f;
	float cameraPosicion1=0f;
	float cameraPosicion2=0f;

	float reset=0.9f;
	float posicionX;

	void Awake(){
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate(){
		if (correr) {
			rb.velocity = new Vector2 (velocidad, rb.velocity.y);
			cameraPosicion1 = GameObject.Find ("Main Camera").transform.position.x;
			Invoke ("cameraPosition", 2f);
			if ((cameraPosicion2 - cameraPosicion1) >= 0.0001f) {
				posicionX=GameObject.Find ("player").transform.position.x;
				GameObject.Find ("player").transform.position=new Vector2(posicionX-reset, rb.position.y);
				//rb.AddForce(new Vector2(0, fuerzaY));
			}
			//Debug.Log (cameraPosicion1+"old");
		}
		animator.SetFloat ("velX", rb.velocity.x);
		contactoSuelo = Physics2D.OverlapCircle (posicion.position, radio, suelo);
		animator.SetBool ("suelo", contactoSuelo);
		if (contactoSuelo) {
			saltoDoble = false;
		}
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			if (correr) {
				if (contactoSuelo || !saltoDoble) {
					rb.velocity = new Vector2 (rb.velocity.x, fuerzaSalto);
					if (!saltoDoble && !contactoSuelo) {
						saltoDoble = true;
					}
				}
			}else{
				correr = true;
				NotificationCenter.DefaultCenter ().PostNotification (this, "PersonajeEmpiezaACorrer");
			}
		}
	}

	void cameraPosition(){
		cameraPosicion2 = GameObject.Find ("Main Camera").transform.position.x;
		//Debug.Log (cameraPosicion2);
	}
}