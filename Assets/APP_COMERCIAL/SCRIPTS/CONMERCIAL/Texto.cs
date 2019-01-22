using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Texto : MonoBehaviour {
    public string nombre;
    public string grupo;
    public Color color;
    public Sprite Imagen;
    public string Descripcion;
    public Text nombre_;
    public Image color_;
    public Text nombre_v;
    public Image color_v;
    public Image imagen_v;
    public Text descripcion_v;
    public GameObject Zoom;
    public general_comercial general;
    public bool NN = false;
    public bool relacionado = false;

    // Use this for initialization

    void Start () {
        nombre_.text = nombre;
        color_.color = color;
    }
	
	// Update is called once per frame

	void Update () {
	
	}

    public void Abrir()
    {
        general.Abrir_Textos(nombre);
    }

    public void Zoome()
    {
        if (relacionado) {
            general.Desactivar();
            Zoom.SetActive(true);
            Zoom.GetComponent<Detalles>().relacionado = true;
            Zoom.GetComponent<Detalles>().nombre = nombre;
            Zoom.GetComponent<Detalles>().grupo = grupo;
            nombre_v.text = nombre;
            color_v.color = color;
            imagen_v.sprite = Imagen;
            descripcion_v.text = Descripcion;
        }
        else
        {
            general.Desactivar();
            Zoom.SetActive(true);
            Zoom.GetComponent<Detalles>().relacionado = false;
            Zoom.GetComponent<Detalles>().nombre = nombre;
            Zoom.GetComponent<Detalles>().grupo = grupo;
            nombre_v.text = nombre;
            color_v.color = color;
            imagen_v.sprite = Imagen;
            descripcion_v.text = Descripcion;
        }
        
    }
}
