using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TEXTO_PLAN_LECTOR : MonoBehaviour {
    public general_comercial_plan_lector general;
    public Text nombreTexto;
    public string nombre;
    public Sprite imagen;
    public string descripcion;
    public string precio;

    void Start () {
	
	}
	
	void Update () {
        nombreTexto.text = nombre;
    }

    public void Abrir()
    {
        general.VistaZoom(imagen,nombre,descripcion,precio);
    }
}
