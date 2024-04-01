using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=8Q9prb7PH9g&list=PLeWwtNsNObD2Pv7e7q8D0OZaz62PSR-va
    //https://www.youtube.com/watch?v=V9LV0Uaqgj4
    public static GameManager instance;


    public bool isPaused;
    public  int chuleta, zanahoria, tomate;
    public Text chuletaText, zanahoriaText, tomateText;
    // Primero, debes obtener una referencia al objeto que tiene el script con la variable que quieres acceder.
    public BarraDeVida vida_player;


   
    private void Awake()
    {
        //chuletaText, zanahoriaText, tomateText;

        ReutilizarText();
        ObtenerDatosGuardados();
        PlayerprebsTextGui();
        ValidacionInstancia();
     
    }
    public void guardarInt()
    {
        PlayerprebsTextGui();
        PlayerPrefs.SetInt("chuletapre",chuleta);
        PlayerPrefs.SetInt("zanahoriapre", zanahoria);
        PlayerPrefs.SetInt("tomatepre", tomate);
    }
   
    void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void PlayerprebsTextGui()
    {
        chuletaText.text = chuleta.ToString();
        zanahoriaText.text = zanahoria.ToString();
        tomateText.text = tomate.ToString();
    }
    public void ObtenerDatosGuardados()
    {
        chuleta = PlayerPrefs.GetInt("chuletapre");
        zanahoria = PlayerPrefs.GetInt("zanahoriapre");
        tomate = PlayerPrefs.GetInt("tomatepre");
    }
    public void ValidacionInstancia()
    {/*
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);*/
    }
    // Esta es tu función que aumenta la vida
    public void AumentarVida(int cantidad)
    {
       
        // Primero, verifica si la vida resultante es mayor a 100
        if (vida_player.vidaActual + cantidad > 100)
        {
            // Si es así, entonces resta la cantidad necesaria para que la vida quede en 100
            vida_player.vidaActual = 100;
        }
        else
        {
            // Si no, entonces aumenta la vida normalmente
            vida_player.vidaActual += cantidad;
        }
    }
    // Esta es tu función que modifica una variable entera dependiendo del valor de una cadena
    //chuleta, zanahoria, tomate;
    public void Comer(string alimento)
    {
        // Usamos un switch para evaluar diferentes casos
        switch (alimento)
        {
            case "chuleta":
                // Si la cadena es "valor1", entonces modificamos la variable de la siguiente manera
                if (chuleta > 0) {
                    chuleta -= 1;
                    guardarInt();
                    AumentarVida(50);
                }
                
                break;
            case "zanahoria":
                // Si la cadena es "valor2", entonces modificamos la variable de la siguiente manera
                if (zanahoria > 0)
                {
                    zanahoria -= 1;
                    guardarInt();
                    AumentarVida(10);
                }

                break;
            case "tomate":
                // Si la cadena es "valor3", entonces modificamos la variable de la siguiente manera
                if (tomate > 0)
                {
                    tomate -= 1;
                    guardarInt();
                    AumentarVida(10);
                }
                break;
                // Este es el caso por defecto que se ejecutará si ninguno de los anteriores es válido
            default:
                // En este caso, no modificamos la variable
                break;
        }
    }
    public void ReutilizarText()
    {
        //chuletaText, zanahoriaText, tomateText;
        GameObject ChuletaTexto = GameObject.Find("chuletaText");
        chuletaText = ChuletaTexto.GetComponent<Text>();

        GameObject zanahoriaTexto = GameObject.Find("zanahoriaText");
        zanahoriaText = zanahoriaTexto.GetComponent<Text>();

        GameObject tomateTexto = GameObject.Find("tomateText");
        tomateText = tomateTexto.GetComponent<Text>();
    }
 
}
