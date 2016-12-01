using UnityEngine;
using System.Collections;

public class BaconController : MonoBehaviour
{

    private Rigidbody rb;
    public float tempoVida;
    public float forca;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * forca);
        tempoVida += Time.time;
    }

    void Update()
    {
        if (Time.time > tempoVida)
            Destroy(this.gameObject);
    }
}