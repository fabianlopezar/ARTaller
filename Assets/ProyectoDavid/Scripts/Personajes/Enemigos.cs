using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Enemigos : MonoBehaviour
{
    [Header("Caracteristicas")]
    public Rigidbody2D rb;

    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;
    public float speed;

    void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }
    void Start()
    {
     
        rb = this.GetComponent<Rigidbody2D>();
    }

}
