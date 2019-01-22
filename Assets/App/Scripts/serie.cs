using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class serie : MonoBehaviour {

    public string Name;
    [HideInInspector]
    public Sprite Imagen;
    [HideInInspector]
    public string Descripcion;
    [HideInInspector]
    public string Cantidad;
    public Image Logo;
    public general Controlador;
	// Use this for initialization
	void Start () {
        Logo.sprite = Imagen;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Abrir_apps()
    {
        Controlador.ActivarApps(Name);
    }
}
