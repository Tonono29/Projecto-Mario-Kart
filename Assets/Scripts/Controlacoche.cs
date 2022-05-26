using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlacoche : MonoBehaviour
{
    [SerializeField] WheelCollider ruedaDelantizda;
    [SerializeField] WheelCollider ruedaDelantDcha;
    [SerializeField] WheelCollider ruedaAtrIzda;
    [SerializeField] WheelCollider ruedaAtrDcha;
    [SerializeField] float velocidadMaxima;
    [SerializeField] float maxSteeringAngle;
    [SerializeField] float fuerzafrenado;
    float steering;
    public float empujeMotor;
    public float giro;
    void Start()
    {
    }
    private void FixedUpdate()
    {
        giro = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Vertical")!=0)
        {
            empujeMotor = velocidadMaxima * Input.GetAxis("Vertical");
            ruedaAtrDcha.brakeTorque = 0;
            ruedaAtrIzda.brakeTorque = 0;
            ruedaDelantDcha.brakeTorque = 0;
            ruedaDelantizda.brakeTorque = 0;
            ruedaAtrDcha.motorTorque = empujeMotor;
            ruedaAtrIzda.motorTorque = empujeMotor;
            ruedaDelantDcha.motorTorque = empujeMotor;
            ruedaDelantizda.motorTorque = empujeMotor;
        }
        else
        {
            ruedaAtrDcha.brakeTorque = fuerzafrenado;
            ruedaAtrIzda.brakeTorque = fuerzafrenado;
            ruedaDelantDcha.brakeTorque = fuerzafrenado;
            ruedaDelantizda.brakeTorque = fuerzafrenado;

        }
        if (Input.GetAxis("Horizontal")!=0)
        {
            steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            ruedaDelantDcha.steerAngle = steering;
            ruedaDelantizda.steerAngle = steering;
        }
        else
        {
            ruedaDelantDcha.steerAngle = 0;
            ruedaDelantizda.steerAngle = 0;
        }
    }
}
