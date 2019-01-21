using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculadora_comercial : MonoBehaviour {
    public int Precio;
    public InputField Descuentot,Cantidadt;
    public float Descuento, Cantidad;
    public Text Total,PrecioN;
	// Use this for initialization
	void Start () {
        Restaurar();
    }
	
	// Update is called once per frame
	void Update () {
        Calcular();
    }


    //Restaurar variables
    public void Restaurar()
    {
        PrecioN.text = Convertir("" + Precio);
        Descuentot.text = 0 + "";
        Cantidadt.text = 1 + "";
    }

    public void Calcular()
    {
        Descuento = float.Parse(Descuentot.text);
        Cantidad = float.Parse(Cantidadt.text);
        Total.text = Convertir((Precio * ((100 - Descuento) / 100)) * Cantidad + "");
    }


    public string Convertir(string precio)
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
                if (comodin == 2)
                {
                    nuevo_precio = nuevo_precio + ".";
                }

                if (comodin == 5)
                {
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

        return "$ " + nuevo_precio;
    }
}
