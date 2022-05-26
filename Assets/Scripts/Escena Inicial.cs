using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscenaInicial : MonoBehaviourPunCallbacks
{
    public InputField nickname;
    public Text textoBoton;
    public Button boton;
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void PulsarBoton()
    {
        boton.enabled = false;
        textoBoton.text = "Conectando...";
        if (nickname.text.Length >= 1)
        {
            PhotonNetwork.NickName = nickname.text;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
