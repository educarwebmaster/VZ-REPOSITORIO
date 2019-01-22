using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANIMACION : MonoBehaviour {
	public Animator anim;
	public string[] animaciones;
    public Color Blanco, Azul;
    public Image[] botones;

	public void Animaciones(int a){
        for (int i = 0;i<botones.Length;i++)
        {
            botones[i].color = Azul;
            botones[i].transform.GetChild(0).gameObject.GetComponent<Text>().color = Blanco;
        }
        botones[a].color = Blanco;
        botones[a].transform.GetChild(0).gameObject.GetComponent<Text>().color = Azul;
        anim.Play(animaciones[a]);
	}
}
