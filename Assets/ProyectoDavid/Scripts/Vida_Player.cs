using System.Collections;
using UnityEngine;
public class Vida_Player : MonoBehaviour
{
    public BarraDeVida vida_player;
    [Header("Daño Recibido")]
    public float daño; //recibe daño el player

    public bool invencible = false;
    public float tiempo_invencible = 1f;
    public float magnitudSacudida=5f;
    public Transform camera;
   
    public SpriteRenderer spriteRenderer;
    public Material normarlMaterial;
    public Material flashMaterial;

    public GameObject panelMuerte;

    public GameObject spriteMaskInvisible;
    public Animator animator;
        private void OnCollisionStay2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("Enemy"))
        {         
            if (!invencible && vida_player.vidaActual > 0)
            {
                takeDamage();
                SacudirCamara(.5f);
            }          
        }
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            spriteMaskInvisible.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteMaskInvisible.SetActive(false);
    }
    public void takeDamage()
    {
        if (!invencible && vida_player.vidaActual > 0)
        {
            vida_player.vidaActual = vida_player.vidaActual - daño;
            StartCoroutine(Invunerable());
            StartCoroutine(FlashRoutine());
        }
    }
    IEnumerator Invunerable()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempo_invencible);
        invencible = false;     
    }
    IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.material = normarlMaterial;
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(5f);
        panelMuerte.SetActive(true);
    }
    public void SacudirCamara(float maximo)
    {
        magnitudSacudida = maximo;
    }
    private void FixedUpdate()
    {
        if (magnitudSacudida > .01f)
        {
            camera.rotation = Quaternion.Euler(
                Random.Range(-magnitudSacudida, magnitudSacudida),
                Random.Range(-magnitudSacudida, magnitudSacudida),
                Random.Range(-magnitudSacudida, magnitudSacudida)
                );
            magnitudSacudida *= .9f;
        }
        if (vida_player.vidaActual <= 0)
        {         
            animator.SetBool("muerto", true);
            StartCoroutine(Esperar());
        
        }
    }


}
