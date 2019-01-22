using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EDADES : MonoBehaviour {
    public string nombre;
    public Text nombreText;
    public general_comercial_plan_lector general;
    
    void Start () {
        
	}
	
	void Update () {
        nombreText.text = nombre;
    }

    public void Abrir()
    {
        general.Abrir_por_textos_edades(nombre);
    }
}
