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
		rot += Input.GetAxisRaw ("Horizontal") * Time.deltaTime * 15f;
		if(rot < 0 && Input.GetAxisRaw ("Horizontal") >= -0.5 && Input.GetAxisRaw ("Horizontal") <= 0.5)
			rot += Time.deltaTime*15f;
		if(rot > 0 && Input.GetAxisRaw ("Horizontal") >= -0.5 && Input.GetAxisRaw ("Horizontal") <= 0.5)
			rot -= Time.deltaTime*15f;
		if (rot < -2) {
			rot = -2;
		} else if (rot > 2) {
			rot = 2;
		}
		transform.RotateAround (transform.position, Vector3.up, rot * 2);
		anim.SetFloat("speed", rb.velocity.magnitude);
		if (rb.velocity.magnitude <= maxSpeed) {
			rb.AddForce (transform.forward * Time.deltaTime * 1000f * Input.GetAxis ("Vertical"));
		}
	}
}
