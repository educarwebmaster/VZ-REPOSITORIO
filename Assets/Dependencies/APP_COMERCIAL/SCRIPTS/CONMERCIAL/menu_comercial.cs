using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu_comercial : MonoBehaviour {
    [Header("Menu General")]
    public bool Abierto;
    public GameObject Mensaje;
    public Sprite Abierto_imagen;
    public Sprite Cerrado_imagen;
    public Image Menu_boton;
    public Animator anim;
    [Header("slider")]
    public Animator[] Slider;
    public int Pagina;
    public Image[] Sliders_int;
    public Color colorsobre;
    public Color Seleccionado;
    [Header("Elementos Menu")]
    public GameObject[] Septores;
    [Header("Elementos Opciones")]
    public AudioSource audio;
    public AudioClip clip;
    public GameObject chekAudio;
    public Text Maquina;
    public Text Sofware;
    private bool sonido;

    void Start()
    {
        Pagina = 0;
        Sofware.text = "" + SystemInfo.operatingSystem;
        Maquina.text = "" + SystemInfo.deviceModel;
        sonido = true;
        Abierto = true;
        for (int i = 0; i < Septores.Length; i++)
        {
            Septores[i].SetActive(false);
        }

        Septores[0].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.CancelQuit();
            Mensaje.SetActive(true);
        }

        for (int i = 0; i < Sliders_int.Length; i++)
        {
            Sliders_int[i].color = colorsobre;
        }
        Sliders_int[Pagina].color = Seleccionado;
    }

    public void Interaccion_menu()
    {
        if (Abierto)
        {
            Abierto = false;
            anim.Play("abrir_menu");
            Menu_boton.sprite = Cerrado_imagen;
        }
        else
        {
            Abierto = true;
            anim.Play("cerrar_menu");
            Menu_boton.sprite = Abierto_imagen;
        }
    }

    public void Desaparecer_septores(int Activado)
    {
        for (int i = 0; i < Septores.Length; i++)
        {
            Septores[i].SetActive(false);
        }

        Septores[Activado].SetActive(true);
    }

    public void Quitar()
    {
        Application.Quit();
    }

    public void Clip()
    {
        if (sonido)
        {
            audio.PlayOneShot(clip);
        }
    }

    public void Cambiar_sonido()
    {
        if (sonido)
        {
            sonido = false;
            chekAudio.SetActive(false);
        }
        else
        {
            sonido = true;
            chekAudio.SetActive(true);
        }
    }

    //siguiente slide
    public void Next()
    {
        if (Pagina < Slider.Length - 1)
        {
            Pagina++;
            Slider[Pagina - 1].Play("AtrasBack");
            Slider[Pagina].Play("AdelanteBack");
        }
        else
        {
            Pagina = 0;
            Select(Pagina);
        }
    }
    //anterior slide
    public void Back()
    {
        if (Pagina > 0)
        {
            Pagina--;
            Slider[Pagina + 1].Play("AdelanteFront");
            Slider[Pagina].Play("AtrasFront");
        }
        else
        {
            Pagina = Slider.Length - 1;
            Select(Pagina);
        }

    }

    //seleccionador slide
    public void Select(int i)
    {
        Pagina = i;
        for (int e = 0; e < Slider.Length; e++)
        {
            Slider[e].Rebind();
            Slider[e].Play("AtrasBack");
        }
        Slider[Pagina].Play("AdelanteBack");
    }
}
