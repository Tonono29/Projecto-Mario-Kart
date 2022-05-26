using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class Pruebawheel : MonoBehaviour
{
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public Transform wheelFL_Trans;
    public Transform wheelFR_Trans;
    public Transform wheelRL_Trans;
    public Transform wheelRR_Trans;



    public float fuerza;

    public float velocidad;

    public float velocidadactual;

    public float angulodireccion;
    public float giro;
    private Rigidbody rigidBody;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        velocidadactual = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;

        {
            wheelFL.motorTorque = fuerza * Input.GetAxis("Vertical");
            wheelFR.motorTorque = fuerza * Input.GetAxis("Vertical");
            wheelRL.motorTorque = fuerza * Input.GetAxis("Vertical");
            wheelRR.motorTorque = fuerza * Input.GetAxis("Vertical");

        }


        velocidad = GetComponent<Rigidbody>().velocity.magnitude * 15;


        giro = angulodireccion * Input.GetAxis("Horizontal");
        wheelFL.steerAngle = giro;
        wheelFR.steerAngle = giro;


    }

    void Update()
    {
        wheelFL_Trans.Rotate(0, 0, wheelFL.rpm / 60 * 360 * Time.deltaTime);
        wheelFR_Trans.Rotate(0, 0, wheelFR.rpm / 60 * 360 * Time.deltaTime);
        wheelRL_Trans.Rotate(0, 0, wheelRL.rpm / 60 * 360 * Time.deltaTime);
        wheelRR_Trans.Rotate(0, 0, wheelRR.rpm / 60 * 360 * Time.deltaTime);

        Vector3 RuedaDireccion = wheelFL_Trans.localEulerAngles;
        RuedaDireccion.y = giro + 90;
        wheelFL_Trans.localEulerAngles = RuedaDireccion;
        wheelFR_Trans.localEulerAngles = RuedaDireccion;





    }
}
