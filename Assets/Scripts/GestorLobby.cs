using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GestorLobby : MonoBehaviour
{
    [SerializeField] private GameObject circuito1;
    [SerializeField] private GameObject circuito2;
    [SerializeField] private GameObject kart1;
    [SerializeField] private GameObject kart2;
    [SerializeField] Text titulo;
    public RoomOptions opciones = new RoomOptions();
    private int circuitoactivo = 1;
    private int karactivo = 1;
    // Start is called before the first frame update
    public void cambiarcircuito()
    {
        if (circuitoactivo==1)
        {
            circuito1.SetActive(false);
            circuito2.SetActive(true);
            circuitoactivo = 2;
        }
        else
        {
            circuito1.SetActive(true);
            circuito2.SetActive(false);
            circuitoactivo = 1;
        }
    }
    public void cambiarkart()
    {
        if (karactivo == 1)
        {
            kart1.SetActive(false);
            kart2.SetActive(true);
            karactivo = 2;
        }
        else
        {
            kart1.SetActive(true);
            kart2.SetActive(false);
            karactivo = 1;
        }
    }
    public void Conectarcircuito()
    {
        opciones.MaxPlayers = 2;
        if (circuitoactivo == 1)
        { 
            PhotonNetwork.JoinOrCreateRoom("Circuito1", opciones, TypedLobby.Default);
        }
    }
    private void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            int jugadoresC = PhotonNetwork.CurrentRoom.PlayerCount;
            titulo.text = "Esperando jugadores..." + jugadoresC + "/2";

            if (PhotonNetwork.IsMasterClient && jugadoresC == 2)
            {
                string salaNombre = PhotonNetwork.CurrentRoom.Name;

                if (salaNombre == "Circuito1")
                {
                    PhotonNetwork.LoadLevel("Circuito1");
                }
                else if (salaNombre == "sala2")
                {
                    PhotonNetwork.LoadLevel("sala2");
                }
                 Destroy(this);
            }
        }
    }
}
