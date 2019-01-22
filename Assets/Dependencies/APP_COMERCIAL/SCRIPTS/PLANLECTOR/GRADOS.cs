using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GRADOS : MonoBehaviour {
    public string nombre;
    public Text nombreText;
    public general_comercial_plan_lector general;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        nombreText.text = nombre;
	}

    public void Abrir()
    {
        general.Abrir_por_textos_grados(nombre);
    }
}
