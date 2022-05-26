using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheSInPv : MonoBehaviour
{
    [SerializeField] private int velocidad;
    [SerializeField] private int giro;
    private Rigidbody cuerpoRigido;
    private float rotacion;
    void Start()
    {
        cuerpoRigido = GetComponent<Rigidbody>();
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rotacion = Input.GetAxis("Horizontal") * giro * Time.fixedDeltaTime;
        transform.Rotate(0f, rotacion, 0f, Space.Self);
        //cuerpoRigido.velocity=transform.forward * velocidad * Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        cuerpoRigido.AddForce(transform.forward * velocidad * Input.GetAxis("Vertical") * Time.fixedDeltaTime,ForceMode.Impulse);
    }
}
