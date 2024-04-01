using UnityEngine;
using System.Collections;
public class Bala : MonoBehaviour
{
    public float vel=0.1f;
    //public BarraDeVida vidaLeon;
    public float daño;
    private void Start()
    {
       // vidaLeon = FindObjectOfType<BarraDeVida>();
        StartCoroutine(esperar());
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * vel * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.GetComponent < BarraDeVida >()== true)
            {
                collision.GetComponent<BarraDeVida>().vidaActual = collision.GetComponent<BarraDeVida>().vidaActual - daño;
            }
            if (collision.GetComponent<Enemigos>() == true)
            {
                collision.GetComponent<Enemigos>().vidaActual = collision.GetComponent<Enemigos>().vidaActual - daño;
            }
        }
    }
    IEnumerator esperar()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject );
    }
  
}
