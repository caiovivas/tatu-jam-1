using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public Animator anim;
	public float maxSpeed, maxSpeedH;
	public float rot;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		maxSpeed = 7;
		maxSpeedH = 2;
		rot += Input.GetAxisRaw ("Horizontal") * Time.deltaTime * 15f;
		if(rot < 0 && Input.GetAxisRaw ("Horizontal") >= -0.5 && Input.GetAxisRaw ("Horizontal") < 1)
			rot += Time.deltaTime*15f;
		if(rot > 0 && Input.GetAxisRaw ("Horizontal") <= 0.5 && Input.GetAxisRaw ("Horizontal") > -1)
			rot -= Time.deltaTime*15f;
		if (rot < -maxSpeedH) {
			rot = -maxSpeedH;
		} else if (rot > maxSpeedH) {
			rot = maxSpeedH;
		}
		transform.RotateAround (transform.position, Vector3.up, rot * maxSpeedH);
		anim.SetFloat("speed", rb.velocity.magnitude);
		if (rb.velocity.magnitude <= maxSpeed) {
			rb.AddForce (transform.forward * Time.deltaTime * 1000f * Input.GetAxis ("Vertical"));
		}
	}
}
