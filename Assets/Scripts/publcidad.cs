using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class publcidad : MonoBehaviour
{
    private UnityWebRequest www;
    private Texture2D publi;
    public Texture2D disponible;
    [SerializeField] private string[] anuncios;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("cargarPublicidad");
    }

    IEnumerator cargarPublicidad()
    {
        int contador = 0;

        while(true)
        {
            www = UnityWebRequestTexture.GetTexture(anuncios[contador]);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.ConnectionError)
            {
                publi = DownloadHandlerTexture.GetContent(www);
                GetComponent<MeshRenderer>().material.mainTexture = publi;
                yield return new WaitForSeconds(5);
            }
            else
            {
                GetComponent<MeshRenderer>().material.mainTexture = disponible;
                yield return new WaitForSeconds(5);
            }
            contador++;
            if(contador>2)
            {
                contador = 0;
            }
        }        
    }
}
