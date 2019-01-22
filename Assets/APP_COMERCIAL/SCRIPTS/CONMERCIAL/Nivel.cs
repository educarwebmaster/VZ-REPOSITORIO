using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Nivel : MonoBehaviour {
    public string nombre;
    public Color color;
    public Text nombre_;
    public Image color_;
    public general_comercial general;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        nombre_.text = nombre;
        //color_.color = color;
    }

    public void Abrir()
    {
        general.Abrir_Area(nombre);
    }
}
