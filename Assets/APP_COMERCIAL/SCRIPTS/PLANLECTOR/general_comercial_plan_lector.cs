using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

[System.Serializable]
public class TEXTO_PLAN_LECTORP
{
    public string nombre;
    public Sprite imagen;
    public string descripcion;
    public string precio;
}

[System.Serializable]
public class EDADESP
{
    public string nombre;
    public TEXTO_PLAN_LECTORP[] Textos;
}

[System.Serializable]
public class GRADOSP
{
    public string nombre;
    public EDADESP[] Edades;
}

public class general_comercial_plan_lector : MonoBehaviour {

    public GRADOSP[] Datos;

    public Transform Padre_grados;
    public GameObject Hijo_grados;

    public Transform Padre_edades;
    public GameObject Hijo_edades;

    public Transform Padre_texto;
    public GameObject Hijo_texto;

    public string grados_estado;
    public string edades_estado;
    public TEXTO_VISTA Vista;
    public GameObject Edades;
    public GameObject Grados;
    public GameObject[] cache;
    bool engrado;

    public void Abrir_por_grados()
    {
        Desactivar();
        Edades.SetActive(false);
        Grados.SetActive(true);
        for (int i = 0; i < Datos.Length; i++)
        {
           cache = new GameObject[Datos.Length];
           var NewPagina = Instantiate(Hijo_grados) as GameObject;
           cache[i] = NewPagina;
           NewPagina.transform.SetParent(Padre_grados, false);
           NewPagina.SetActive(true);
           NewPagina.GetComponent<GRADOS>().nombre = Datos[i].nombre;
        }
    }

    public void Abrir_por_edades()
    {
        Desactivar();
        Edades.SetActive(true);
        Grados.SetActive(false);
        cache = new GameObject[Datos[0].Edades.Length];
        for (int i = 0; i < Datos[0].Edades.Length; i++)
        {
            var NewPagina = Instantiate(Hijo_edades) as GameObject;
            cache[i] = NewPagina;
            NewPagina.transform.SetParent(Padre_edades, false);
            NewPagina.SetActive(true);
            NewPagina.GetComponent<EDADES>().nombre = Datos[0].Edades[i].nombre;
        }
    }

    public void Abrir_por_textos_grados(string Tipo)
    {
        Desactivar();
        engrado = true;
        for (int i = 0; i < Datos.Length; i++)
        {
            if (Datos[i].nombre == Tipo)
            {
                for (int e = 0;e < Datos[i].Edades.Length;e++)
                {
                    cache = new GameObject[Datos[0].Edades.Length];
                    for (int a = 0; a < Datos[i].Edades[e].Textos.Length;a++)
                    {
                        var NewPagina = Instantiate(Hijo_texto) as GameObject;
                        cache[i] = NewPagina;
                        NewPagina.transform.SetParent(Padre_texto, false);
                        NewPagina.SetActive(true);
                        NewPagina.GetComponent<TEXTO_PLAN_LECTOR>().nombre = Datos[i].Edades[e].Textos[a].nombre;
                        NewPagina.GetComponent<TEXTO_PLAN_LECTOR>().imagen = Datos[i].Edades[e].Textos[a].imagen;
                        NewPagina.GetComponent<TEXTO_PLAN_LECTOR>().descripcion = Datos[i].Edades[e].Textos[a].descripcion;
                        NewPagina.GetComponent<TEXTO_PLAN_LECTOR>().precio = Datos[i].Edades[e].Textos[a].precio;
                    }
                }
            }
        }
    }

    public void Abrir_por_textos_edades(string Tipo)
    {
        Desactivar();
        engrado = false;
        for (int i = 0; i < Datos.Length; i++)
        {
           for (int e = 0; e < Datos[i].Edades.Length; e++)
           {
             if (Datos[i].Edades[e].nombre == Tipo)
             {
                    cache = new GameObject[Datos[i].Edades[e].Textos.Length];
                    for (int a = 0; a < Datos[i].Edades[e].Textos.Length; a++)
                    {
                        var NewPagina = Instantiate(Hijo_texto) as GameObject;
                        cache[i] = NewPagina;
                        NewPagina.transform.SetParent(Padre_texto, false);
                        NewPagina.SetActive(true);
                        NewPagina.GetComponent<TEXTO_PLAN_LECTOR>().nombre = Datos[i].Edades[e].Textos[a].nombre;
                        NewPagina.GetComponent<TEXTO_PLAN_LECTOR>().imagen = Datos[i].Edades[e].Textos[a].imagen;
                        NewPagina.GetComponent<TEXTO_PLAN_LECTOR>().descripcion = Datos[i].Edades[e].Textos[a].descripcion;
                        NewPagina.GetComponent<TEXTO_PLAN_LECTOR>().precio = Datos[i].Edades[e].Textos[a].precio;
                    }
                }
           }
        }
    }

    public void VistaZoom(Sprite imagenv,string nombrev,string descripcionv,string precio )
    {
        Vista.nombre = nombrev;
        Vista.imagen = imagenv;
        Vista.descripcion = descripcionv;
        Vista.precio = precio;
    }

    public void Regresar()
    {
        if (engrado)
        {
            Abrir_por_grados();
        }
        else
        {
            Abrir_por_edades();
        }
    }

    public void Nohay()
    {
       Desactivar();
    }

    public void Restaurar_Grados()
    {
        Abrir_por_grados();
    }

    public void Restaurar_Edades()
    {
        
    }

    public void Desactivar()
    {
        for (int i = 0; i < cache.Length; i++)
        {
            if (cache[i] != null) 
            {
                Destroy(cache[i].gameObject);
            }
        }
    }
}
