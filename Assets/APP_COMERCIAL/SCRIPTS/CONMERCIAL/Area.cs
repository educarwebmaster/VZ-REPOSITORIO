using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Area : MonoBehaviour {
    public string nombre;
    public Color color;
    public Text nombre_;
    public Image color_;
    public general_comercial general;
    public bool NN = false;
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
        if (NN)
        {
            general.Nohay();
        }
        else
        {
            //general.Abrir_Textos_relacionados();
            general.Abrir_Textos(nombre);
        }
        
    }
}
