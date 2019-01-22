using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Precio : MonoBehaviour {
    public string nombre;
    public string precio;
    public Text nombre_;
    public Text precio_;
    public Calculadora_comercial calculadora;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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

        precio_.text = "$ " + nuevo_precio;
        nombre_.text = nombre;
    }

    public void Calculadora()
    {
        calculadora.Precio = int.Parse(precio);
        calculadora.Restaurar();
    }
}
