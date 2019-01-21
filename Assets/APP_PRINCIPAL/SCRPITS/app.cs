using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class app : MonoBehaviour {
    public Image Imagen;
    public Text Nombre;
    [HideInInspector]
    public string Name;
    [HideInInspector]
    public Sprite Imagen_app;
    [HideInInspector]
    public string PAQUETE;
    public general General;
    public GameObject Instalado;
    public GameObject Instalar;
    public GameObject Produccion;
    public firebase Controlador;
    public bool Enproduccion = false;
    bool Estado;
	// Use this for initialization
	void Start () {
        Instalado.SetActive(false);
        Instalar.SetActive(false);
        for (int i = 0; i < General.ArrayApp.Length; i++)
        {
            if (Enproduccion)
            {
                Instalado.SetActive(false);
                Instalar.SetActive(false);
                Produccion.SetActive(true);
                Estado = false;
                break;
            }
            else
            {
                if (General.ArrayApp[i] == PAQUETE)
                {
                    Instalado.SetActive(true);
                    Instalar.SetActive(false);
                    Produccion.SetActive(false);
                    Estado = true;
                    break;
                }
                else
                {
                    Instalado.SetActive(false);
                    Instalar.SetActive(true);
                    Produccion.SetActive(false);
                    Estado = false;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        Imagen.sprite = Imagen_app;
        Nombre.text = Name;
    }

    public void OpenApp()
    {
        
#if UNITY_ANDROID

        if (Estado)
        {
            OSHookBridge.ShowAppID(PAQUETE);
            OSHookBridge.ShowMensage("Abriendo APP");
        }
        else
        {
            OSHookBridge.ShowAppStore(PAQUETE);
            OSHookBridge.ShowMensage("Abriendo en la PLAY STORE");
        }

#endif
        Controlador.AppVista(PlayerPrefs.GetString("Id"), PAQUETE);
    }
}
