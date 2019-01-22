using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class formulario : MonoBehaviour {

    public InputField nombre;
    public InputField email;
    public InputField asunto;
    public firebase Controlador;
    private char espacio = ' ';
    public GameObject mensage_si,mensage_no;



    public void Enviar()
    {
        if (nombre.text == "" || email.text == "" || asunto.text == "")
        {
            mensage_no.SetActive(true);
            OSHookBridge.ShowMensage("Mensage no Enviado");
        }
        else
        {
            //StartCoroutine("SaveName");
            Controlador.Contacto(nombre.text, nombre.text, email.text, asunto.text);
            nombre.text = "";
            email.text = "";
            asunto.text = "";
            mensage_si.SetActive(true);
            OSHookBridge.ShowMensage("Mensage Enviado");
        }
        
    }
   
    /*public IEnumerator SaveName()
    {
        /tring urlString = porstURL + "?name=" + nombre.text  + "&mail=" + email.text + "&dispositivo=" + maquina2 + "&asunto=" + asunto.text;
        Debug.Log("Sending : " + urlString);
        WWW postName = new WWW (urlString);
        yield return postName;
        Debug.Log(postName.text);
    }*/

    public void Link(string mi_link)
    {
        Application.OpenURL(mi_link);
    }

}
