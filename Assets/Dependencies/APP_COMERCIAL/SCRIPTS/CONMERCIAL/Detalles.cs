using UnityEngine;
using System.Collections;

public class Detalles : MonoBehaviour {
    public string nombre;
    public general_comercial general;
    public bool relacionado;
    public string grupo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Mostrar_precios()
    {
        if (relacionado)
        {
            general.nombre_colegio_relacionado = grupo;
            general.Abrir_Precios_relacionado(nombre);
        }
        else
        {
            general.Abrir_Precios(nombre);
        }
        
    }
}
