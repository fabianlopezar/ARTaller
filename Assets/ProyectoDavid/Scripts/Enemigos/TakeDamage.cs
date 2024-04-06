using System.Collections;
using UnityEngine;

public class TakeDamage : DosPatas
{
    public float daño;
    public bool invencible = false;
    public float tiempo_invencible = 1f;
    public SpriteRenderer spriteRenderer;
    public Material normarlMaterial;
    public Material flashMaterial;
    public GameObject spriteMaskInvisible;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag($"{nombreTag}"))
        {
         //   if (!invencible && vidaActual > 0 && Vector3.Distance(target.transform.position, transform.position) < atacar)
            if (!invencible && vidaActual > 0 && Mathf.Abs(target.transform.position.x- transform.position.x) < atacar)
            {
              
                takeDamage();
             
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteMaskInvisible.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            spriteMaskInvisible.SetActive(true);
        }
    }
    public void takeDamage()
    {
        if (!invencible && vidaActual > 0)
        {
      
            vidaActual = vidaActual - daño;
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
   
}
