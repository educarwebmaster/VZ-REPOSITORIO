using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

[System.Serializable]
public class Precios_texto
{
    public string nombre;
    public string precio;
}

[System.Serializable]
public class Texto_colegio
{
    public string nombre;
    public Color color_colegio;
    public Sprite imagen;
    public string descripcion;
    public Precios_texto[] textos_precios;
}

[System.Serializable]
public class Area_colegio
{
    public string nombre;
    public Color color_colegio;
    public bool NN;
    public Texto_colegio[] Textos;
}

[System.Serializable]
public class Nivel_colegio
{
    public string nombre;
    public Color color_colegio;
    public Area_colegio[] Areas;
}

[System.Serializable]
public class Color_colegio
{
    public string nombre;
    public Color color_colegio;
    public Nivel_colegio[] Niveles;
}

public class general_comercial : MonoBehaviour {

    public Color_colegio[] Datos;

    public Transform Padre_nivel;
    public GameObject Hijo_nivel;

    public Transform Padre_area;
    public GameObject Hijo_area;

    public Transform Padre_texto;
    public GameObject Hijo_texto;

    public Transform Padre_texto_relacionado;
    public GameObject Hijo_texto_relacionado;

    public Transform Padre_precios;
    public GameObject Hijo_precios;

    public Image Nivel_Color;
    public Text Nivel_Texto;

    public Image Area_Color;
    public Text Area_Texto;

    public Image Texto_Color;
    public Text Texto_Texto;

    public Text Texto_relacionado;

    public string Color_estado;
    public string Nivel_estado;
    public string Texto_estado;
    public string Precio_estado;
    public string nombre_colegio_relacionado;

    public GameObject[] cache;

    void Start()
    {
        
    }

    public GameObject Textos_normales;
    public GameObject Textos_relacionados;
    void Update()
    {
        
    }

    //clase bidimencional
    public void Abrir_Nivel(string Tipo)
    {
        for (int i = 0; i < Datos.Length; i++)
        {
            if (Datos[i].nombre == Tipo)
            {
                cache = new GameObject[Datos[i].Niveles.Length];
                for (int e = 0; e < Datos[i].Niveles.Length; e++)
                {
                    var NewPagina = Instantiate(Hijo_nivel) as GameObject;
                    cache[e] = NewPagina;
                    NewPagina.transform.SetParent(Padre_nivel, false);
                    NewPagina.SetActive(true);
                    NewPagina.GetComponent<Nivel>().nombre = Datos[i].Niveles[e].nombre;
                    NewPagina.GetComponent<Nivel>().color = Datos[i].color_colegio;
                    //Nivel_Color.color = Datos[i].color_colegio;
                }
                Color_estado = Tipo;
                Nivel_Texto.text = "/";
                break;
            }
        }
    }

    //classe tridimencional
    public void Abrir_Area(string Tipo)
    {
        Desactivar();
        for (int i = 0; i < Datos.Length; i++)
        {
            if (Datos[i].nombre == Color_estado)
            {
                for (int e = 0; e < Datos[i].Niveles.Length; e++)
                {
                    if (Datos[i].Niveles[e].nombre == Tipo)
                    {
                        cache = new GameObject[Datos[i].Niveles[e].Areas.Length];
                        for (int a = 0; a < Datos[i].Niveles[e].Areas.Length; a++)
                        {
                            var NewPagina = Instantiate(Hijo_area) as GameObject;
                            cache[a] = NewPagina;
                            NewPagina.transform.SetParent(Padre_area, false);
                            NewPagina.SetActive(true);
                            NewPagina.GetComponent<Area>().nombre = Datos[i].Niveles[e].Areas[a].nombre;
                            NewPagina.GetComponent<Area>().color = Datos[i].color_colegio;
                            NewPagina.GetComponent<Area>().NN = Datos[i].Niveles[e].Areas[a].NN;
                            //Area_Color.color = Datos[i].color_colegio;
                        }
                        Nivel_estado = Tipo;
                        Area_Texto.text = "/" + Nivel_estado;
                        break;
                    }
                }
            }
        }
    }

    //clase cuatridimencional
    public void Abrir_Textos(string Tipo)
    {
        Desactivar();
        for (int i = 0; i < Datos.Length; i++)
        {
            if (Datos[i].nombre == Color_estado)
            {
                for (int e = 0; e < Datos[i].Niveles.Length; e++)
                {
                    if (Datos[i].Niveles[e].nombre == Nivel_estado)
                    {
                        for (int a = 0; a < Datos[i].Niveles[e].Areas.Length; a++)
                        {
                            if (Datos[i].Niveles[e].Areas[a].nombre == Tipo)
                            {
                                cache = new GameObject[Datos[i].Niveles[e].Areas[a].Textos.Length];
                                for (int o = 0; o < Datos[i].Niveles[e].Areas[a].Textos.Length; o++)
                                {
                                    var NewPagina = Instantiate(Hijo_texto) as GameObject;
                                    cache[o] = NewPagina;
                                    NewPagina.transform.SetParent(Padre_texto, false);
                                    NewPagina.SetActive(true);
                                    NewPagina.GetComponent<Texto>().nombre = Datos[i].Niveles[e].Areas[a].Textos[o].nombre;
                                    NewPagina.GetComponent<Texto>().color = Datos[i].color_colegio;
                                    NewPagina.GetComponent<Texto>().Descripcion = Datos[i].Niveles[e].Areas[a].Textos[o].descripcion;
                                    NewPagina.GetComponent<Texto>().Imagen = Datos[i].Niveles[e].Areas[a].Textos[o].imagen;
                                    //Texto_Color.color = Datos[i].color_colegio;
                                }
                                Texto_estado = Tipo;
                                Texto_Texto.text = "/" + Nivel_estado + "/" + Texto_estado;
                                Textos_normales.SetActive(false);
                                Textos_relacionados.SetActive(true);
                                Abrir_Textos_relacionados();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    public void Nohay()
    {
       Desactivar();
       Texto_Color.color = Color.white;
       Texto_Texto.text = "no hay textos";
    }

    //clase cuatridimencional
    public void Abrir_Precios(string Tipo)
    {
        Desactivar();
        for (int i = 0; i < Datos.Length; i++)
        {
            if (Datos[i].nombre == Color_estado)
            {
                for (int e = 0; e < Datos[i].Niveles.Length; e++)
                {
                    if (Datos[i].Niveles[e].nombre == Nivel_estado)
                    {
                        for (int a = 0; a < Datos[i].Niveles[e].Areas.Length; a++)
                        {
                            if (Datos[i].Niveles[e].Areas[a].nombre == Texto_estado)
                            {
                                
                                for (int o = 0; o < Datos[i].Niveles[e].Areas[a].Textos.Length; o++)
                                {
                                    if (Datos[i].Niveles[e].Areas[a].Textos[o].nombre == Tipo)
                                    {
                                        cache = new GameObject[Datos[i].Niveles[e].Areas[a].Textos[o].textos_precios.Length];
                                        for (int u = 0; u < Datos[i].Niveles[e].Areas[a].Textos[o].textos_precios.Length; u++)
                                        {
                                            var NewPagina = Instantiate(Hijo_precios) as GameObject;
                                            cache[u] = NewPagina;
                                            NewPagina.transform.SetParent(Padre_precios, false);
                                            NewPagina.SetActive(true);
                                            NewPagina.GetComponent<Precio>().nombre = Datos[i].Niveles[e].Areas[a].Textos[o].textos_precios[u].nombre;
                                            NewPagina.GetComponent<Precio>().precio = Datos[i].Niveles[e].Areas[a].Textos[o].textos_precios[u].precio ;
                                            
                                        }
                                        Precio_estado = Tipo;
                                        break;
                                    }
                                }     
                            }
                        }
                    }
                }
            }
        }
    }

    public void Abrir_Textos_relacionados()
    {
        Desactivar();
        Color color_colegio_new;
        
        cache = new GameObject[100];
        for (int i = 0; i < Datos.Length; i++)
        {
            color_colegio_new = Datos[i].color_colegio;
            nombre_colegio_relacionado = Datos[i].nombre;
                for (int e = 0; e < Datos[i].Niveles.Length; e++)
                {
                    if (Datos[i].Niveles[e].nombre == Nivel_estado)
                    {
                        for (int a = 0; a < Datos[i].Niveles[e].Areas.Length; a++)
                        {
                            if (Datos[i].Niveles[e].Areas[a].nombre == Texto_estado)
                            {
                                
                                for (int o = 0; o < Datos[i].Niveles[e].Areas[a].Textos.Length; o++)
                                {
                                    var NewPagina = Instantiate(Hijo_texto_relacionado) as GameObject;
                                    for (int comodin = 0;comodin < cache.Length;comodin++)
                                    {
                                        if (cache[comodin] == null)
                                        {
                                           cache[comodin] = NewPagina;
                                           break;
                                        }
                                    }
                                    NewPagina.transform.SetParent(Padre_texto_relacionado, false);
                                    NewPagina.SetActive(true);
                                    NewPagina.GetComponent<Texto>().nombre = Datos[i].Niveles[e].Areas[a].Textos[o].nombre;
                                    NewPagina.GetComponent<Texto>().color = color_colegio_new;
                                    NewPagina.GetComponent<Texto>().Descripcion = Datos[i].Niveles[e].Areas[a].Textos[o].descripcion;
                                    NewPagina.GetComponent<Texto>().Imagen = Datos[i].Niveles[e].Areas[a].Textos[o].imagen;
                                    NewPagina.GetComponent<Texto>().grupo = nombre_colegio_relacionado;
                                    if (nombre_colegio_relacionado != Color_estado) { NewPagina.GetComponent<Texto>().relacionado = true; }
                                    Texto_relacionado.text = "/" + Nivel_estado + "/" + Texto_estado;
                            }
                                break;
                            }
                        }
                    }
                }
        }
    }

    public void Abrir_Precios_relacionado(string Tipo)
    {
        Desactivar();
        for (int i = 0; i < Datos.Length; i++)
        {
            if (Datos[i].nombre == nombre_colegio_relacionado)
            {
                for (int e = 0; e < Datos[i].Niveles.Length; e++)
                {
                    if (Datos[i].Niveles[e].nombre == Nivel_estado)
                    {
                        for (int a = 0; a < Datos[i].Niveles[e].Areas.Length; a++)
                        {
                            if (Datos[i].Niveles[e].Areas[a].nombre == Texto_estado)
                            {

                                for (int o = 0; o < Datos[i].Niveles[e].Areas[a].Textos.Length; o++)
                                {
                                    if (Datos[i].Niveles[e].Areas[a].Textos[o].nombre == Tipo)
                                    {
                                        cache = new GameObject[Datos[i].Niveles[e].Areas[a].Textos[o].textos_precios.Length];
                                        for (int u = 0; u < Datos[i].Niveles[e].Areas[a].Textos[o].textos_precios.Length; u++)
                                        {
                                            var NewPagina = Instantiate(Hijo_precios) as GameObject;
                                            cache[u] = NewPagina;
                                            NewPagina.transform.SetParent(Padre_precios, false);
                                            NewPagina.SetActive(true);
                                            NewPagina.GetComponent<Precio>().nombre = Datos[i].Niveles[e].Areas[a].Textos[o].textos_precios[u].nombre;
                                            NewPagina.GetComponent<Precio>().precio = Datos[i].Niveles[e].Areas[a].Textos[o].textos_precios[u].precio;
                                        }
                                        Precio_estado = Tipo;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void Restaurar_Niveles()
    {
        Abrir_Nivel(Color_estado);
    }

    public void Restaurar_Areas()
    {
        Abrir_Area(Nivel_estado);
    }

    public void Restaurar_Textos()
    {
        Abrir_Textos(Texto_estado);
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
