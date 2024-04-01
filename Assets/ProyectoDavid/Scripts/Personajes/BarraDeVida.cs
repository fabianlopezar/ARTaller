using UnityEngine;
using UnityEngine.UI;
public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;
    void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }

}
