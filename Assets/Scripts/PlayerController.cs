using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public Animator anim;
	public float maxSpeed;
	public float rot;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		rot += Input.GetAxis ("Horizontal") * Time.deltaTime * 10f;
		if(rot < 0)
			rot += Time.deltaTime*5f;
		if(rot > 0)
			rot -= Time.deltaTime*5f;
		if (rot < -5) {
			rot = -5;
		} else if (rot > 5) {
			rot = 5;
		}
		transform.RotateAround (transform.position, Vector3.up, rot);
		anim.SetFloat("speed", rb.velocity.magnitude);
		if (rb.velocity.magnitude <= maxSpeed) {
			rb.AddForce (transform.forward * Time.deltaTime * 1000f * Input.GetAxis ("Vertical"));
		}
	}
}
