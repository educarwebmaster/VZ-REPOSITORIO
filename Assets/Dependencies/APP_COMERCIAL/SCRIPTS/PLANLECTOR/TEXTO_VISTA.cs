using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TEXTO_VISTA : MonoBehaviour {
    public Image Textura;
    public Text nombreTexto;
    public Text descripcionText;
    public Text precioText;
    public string nombre;
    public Sprite imagen;
    public string descripcion;
    public string precio;

    void Start () {
	
	}
	
	void Update () {
        nombreTexto.text = nombre;
        Textura.sprite = imagen;
        descripcionText.text = descripcion;
        Convertir();
    }

    public void Convertir()
    {
        string nuevo_string = precio.Trim(); ;
        char[] precio_mas = nuevo_string.ToCharArray();
        string nuevo_precio = "";
        int comodin = 0;
        for (int i = 0; i < precio.Length; i++)
        {
            comodin++;
            if (precio_mas.Length == 7)
            {
                if (comodin == 5)
                {
                    comodin = 0;
                    nuevo_precio = nuevo_precio + ".";
                }
            }
            if (precio_mas.Length == 6)
            {
                if (comodin == 4)
                {
                    comodin = 0;
                    nuevo_precio = nuevo_precio + ".";
                }
            }
            if (precio_mas.Length == 5)
            {
                if (comodin == 3)
                {
                    comodin = 0;
                    nuevo_precio = nuevo_precio + ".";
                }
            }
            if (precio_mas.Length == 4)
            {
                if (comodin == 2)
                {
                    comodin = 0;
                    nuevo_precio = nuevo_precio + ".";
                }
            }
            if (precio_mas.Length == 3)
            {
                if (comodin == 1)
                {
                    comodin = 0;
                    nuevo_precio = nuevo_precio + ".";
                }
            }
            nuevo_precio = nuevo_precio + "" + precio_mas[i].ToString();
        }
        precioText.text = "$ " + nuevo_precio;
    }
}
