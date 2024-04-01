using System.Collections;
using UnityEngine;
public class Abrir_valla : MonoBehaviour
{
    public Animator anim;
    public GameObject botonAbrir;
    public bool abrirValla=false;
    private void Start()
    {
        botonAbrir.SetActive(false);
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            botonAbrir.SetActive(true);            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        botonAbrir.SetActive(false);
    }
    public void BotonAbrir()
    {

        if (!abrirValla)
        {
           anim.SetBool("activado", true);
            StartCoroutine(Espera());
            abrirValla=!abrirValla;
        }
       else 
        {
            anim.SetBool("activado", false);
            StartCoroutine(Espera());
            abrirValla = !abrirValla;
        }
    }
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(1.5f);

    }
}
    

