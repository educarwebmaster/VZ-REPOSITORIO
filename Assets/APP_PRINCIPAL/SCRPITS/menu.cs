using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class menu : MonoBehaviour {
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
    public GameObject chekAudios;
    public GameObject chekAudion;
    public Text Maquina;
    public Text Sofware;
    private bool sonido;
    [Header("Elementos Tutorial")]
    public int slidertuto;
    public Text TituloText, ExplicacionText; 
    public GameObject Tutorial;
    public GameObject[] animaciones;
    public string[] Titulo, Explicacion;

    void Start () {
        if (PlayerPrefs.HasKey("Tutorial"))
        {
            Tutorial.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Tutorial",1);
            Tutorial.SetActive(true);
        }
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
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.CancelQuit();
            Mensaje.SetActive(true);
        }
    }

    public void tuto_siguiente()
    {
        if (slidertuto < animaciones.Length - 1)
        {
            for (int i = 0; i < animaciones.Length; i++)
            {
                animaciones[i].SetActive(false);
            }
            slidertuto += 1;
            animaciones[slidertuto].SetActive(true);
            TituloText.text = Titulo[slidertuto];
            ExplicacionText.text = Explicacion[slidertuto];
        }
        else
        {
            Tutorial.SetActive(false);
            slidertuto = 0;
            TituloText.text = Titulo[slidertuto];
            ExplicacionText.text = Explicacion[slidertuto];
        }
    }

    public void tuto_atras()
    {
        if (slidertuto > 0)
        {
            for (int i = 0; i < animaciones.Length; i++)
            {
                animaciones[i].SetActive(false);
            }
            slidertuto -= 1;
            animaciones[slidertuto].SetActive(true);
            TituloText.text = Titulo[slidertuto];
            ExplicacionText.text = Explicacion[slidertuto];
        }
    }

    public void Omitir()
    {
        for (int i = 0; i < animaciones.Length; i++)
        {
            animaciones[i].SetActive(false);
        }
        slidertuto = 0;
        animaciones[slidertuto].SetActive(true);
        Tutorial.SetActive(false);
        TituloText.text = Titulo[slidertuto];
        ExplicacionText.text = Explicacion[slidertuto];
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
        for (int i = 0;i < Septores.Length;i++)
        {
            Septores[i].SetActive(false);
        }
        Septores[Activado].SetActive(true);
    }

    public void Quitar()
    {
        OSHookBridge.ShowMensage("Saliendo de la App");
        Application.Quit();
    }

    public void Clip()
    {
        if (sonido) {
            audio.PlayOneShot(clip);
        }
    }

    public void Cambiar_sonido()
    {
        if (sonido)
        {
            sonido = false;
            chekAudios.SetActive(false);
            chekAudion.SetActive(true);
            OSHookBridge.ShowMensage("Sonido desactivado");
        }
        else
        {
            sonido = true;
            chekAudios.SetActive(true);
            chekAudion.SetActive(false);
            OSHookBridge.ShowMensage("Sonido activado");
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

    public void SelectRestore()
    {
        for (int e = 1; e < Slider.Length; e++)
        {
            Slider[e].Play("AtrasBack");
        }
        Slider[0].Play("AdelanteBack");
    }
}
