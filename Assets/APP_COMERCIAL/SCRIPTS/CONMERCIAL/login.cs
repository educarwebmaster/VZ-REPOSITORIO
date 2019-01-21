using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class login : MonoBehaviour {

    public string contraseña;
    public InputField contra;
    public InputField nombre;
    public GameObject correcto;
    public GameObject incorrecto;
    public GameObject loogin;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("LOGIN"))
        {
            loogin.SetActive(false);
        }
        else
        {
            loogin.SetActive(true);
        }
	}


    public void Verificar()
    {
        if (contra.text == contraseña)
        {
            incorrecto.SetActive(false);
            correcto.SetActive(true);
            PlayerPrefs.SetString("LOGIN",nombre.text);
            StartCoroutine("enviar");
        }
        else
        {
            incorrecto.SetActive(true);
            correcto.SetActive(false);
        }
    }

    public IEnumerator enviar()
    {
            yield return new WaitForSeconds(1);
            loogin.SetActive(false);
    }
}
