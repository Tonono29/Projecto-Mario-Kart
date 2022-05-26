using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Coches : MonoBehaviour
{
    [SerializeField]private int velocidad;
    [SerializeField] private int giro;
    private Rigidbody cuerpoRigido;
    private float rotacion;
    private PhotonView PV;
    void Start()
    {
        PV = GetComponent<PhotonView>();
        cuerpoRigido = GetComponent<Rigidbody>();
        if(PV.IsMine)
        {
            Camera cam;
            cam = GetComponent<Camera>();
            cam.enabled = true;
        }
        else
        {
            Camera cam;
            cam = GetComponent<Camera>();
            cam.enabled = false;
        }

    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (PV.IsMine)
        {
            Debug.Log("Vertical " + Input.GetAxis("Vertical") + " Horizontal " + Input.GetAxis("Horizontal"));
            rotacion = Input.GetAxis("Horizontal") * giro * Time.deltaTime;
            transform.Rotate(0f, rotacion, 0f, Space.Self);
            cuerpoRigido.AddForce(transform.forward * velocidad * Input.GetAxis("Vertical") * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
