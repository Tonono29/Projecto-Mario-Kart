using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ControladorEscena : MonoBehaviour
{
    [SerializeField] GameObject spawn1;
    [SerializeField] GameObject spawn2;
    void Start()
    {
        int numJugador = PhotonNetwork.LocalPlayer.ActorNumber;
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Kart1", spawn1.transform.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Kart2", spawn2.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
