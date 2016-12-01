using UnityEngine;
using System.Collections;

public class ControllerPlayer : MonoBehaviour {

    private Rigidbody rb;
    public Animator anim;

    public float maxSpeed;
    public float velRot;
    public float speed;

    public GameObject bacon;
    public GameObject spawnBacon;
    public float fireRatio;
    private float proximoTiro;

    void Start () {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > proximoTiro)
        {
            proximoTiro = Time.time + fireRatio;
            Instantiate(bacon, spawnBacon.transform.position, spawnBacon.transform.rotation);
        }
    }
	
	void FixedUpdate () {

        float rotacao = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");
        
        transform.RotateAround(transform.position, Vector3.up, rotacao * velRot);

        anim.SetFloat("speed", rb.velocity.magnitude);

        //transform.position += transform.forward * move * maxSpeed;
        
        if (rb.velocity.magnitude <= maxSpeed)
            rb.AddForce(transform.forward * move * speed);

    }
}
