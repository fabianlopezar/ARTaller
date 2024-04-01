using UnityEngine;
public class Panal : MonoBehaviour
{
    public int vida=200;
    public BarraDeVida vidaPanal;
    public int daño = 20;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Roca"))
        {
            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }
                vida = vida - daño;
            vidaPanal.vidaActual = vidaPanal.vidaActual - daño;
        }
    }

}
