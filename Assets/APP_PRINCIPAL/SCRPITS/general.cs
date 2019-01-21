using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;
using System;

[System.Serializable]
public class series_app
{
    public string Serie_nombre;
    public Sprite Serie_icono;
    public appicacion[] Apps;
}

[System.Serializable]
public class appicacion
{
    public string Nombre;
    public Sprite Imagen_miapp;
    public string Link_ANDROID;
    public string Link_IOS;
    public bool Enproduccion;
}

public class general : MonoBehaviour {
    private string TextoArrayApps = "";
    public string[] ArrayApp;
    public series_app[] series;
    public Transform Padre_series;
    public GameObject Hijo_series;
    public Transform Padre_app;
    public GameObject Hijo_app;
    public Text Titulo_serie;
    public Text Descripcion_serie;

    [HideInInspector]
    public GameObject[] cache;

	void Start () {
#if UNITY_ANDROID
        TextoArrayApps = "" + OSHookBridge.ReturnList();
        ArrayApp = TextoArrayApps.Split(new string[] { "," }, StringSplitOptions.None);
#endif
        for (int i = 0; i < series.Length; i++)
        {
            var NewPagina = Instantiate(Hijo_series) as GameObject;
            NewPagina.transform.SetParent(Padre_series, false);
            NewPagina.SetActive(true);
            NewPagina.GetComponent<serie>().Name = series[i].Serie_nombre;
            NewPagina.GetComponent<serie>().Imagen = series[i].Serie_icono;
            NewPagina.GetComponent<serie>().Cantidad = "" + series[i].Apps.Length;
        }
    }
	
	void Update () {

    }

    public void ActivarApps(string name)
    {
        for (int i = 0; i < series.Length; i++)
        {
            if(series[i].Serie_nombre == name)
            {
                cache = new GameObject[series[i].Apps.Length];
                for (int e = 0; e < series[i].Apps.Length; e++)
                {
                    var NewPagina = Instantiate(Hijo_app) as GameObject;
                    NewPagina.transform.SetParent(Padre_app, false);
                    cache[e] = NewPagina;
                    NewPagina.SetActive(true);
                    NewPagina.GetComponent<app>().Name = series[i].Apps[e].Nombre;
                    if (series[i].Apps[e].Enproduccion)
                    {
                        NewPagina.GetComponent<app>().Enproduccion = true;
                    }
#if UNITY_IOS
                    
#endif

#if UNITY_ANDROID
                    NewPagina.GetComponent<app>().PAQUETE = series[i].Apps[e].Link_ANDROID;
#endif

                    NewPagina.GetComponent<app>().Imagen_app = series[i].Apps[e].Imagen_miapp;
                }
            }
        }
    }

    public void Desactivar()
    {
        for (int i = 0; i < cache.Length; i++)
        {
            Destroy(cache[i].gameObject);
        }
    }
}
