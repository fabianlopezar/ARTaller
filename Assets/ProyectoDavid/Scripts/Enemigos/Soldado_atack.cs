using UnityEngine;
using System.Collections;
public class Soldado_atack : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;
    public LayerMask whatIsPlayer;
    public float distance;
    public float parrar;
    public float atacar;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    public bool isInChaseRange;
    public bool isInAttackRange;
    public BarraDeVida vidaSoldado;
    public bool estaMuerto = false;

    public Transform attackPos;
    public LayerMask whatIsPlayerTo;
    public float attackRange;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
        MoveAnim();
        if (Vector3.Distance(target.transform.position, transform.position) < atacar && estaMuerto == false)
         {
            shouldRotate = true;
            anim.SetBool("IsAtacking", true);
            anim.SetFloat("x", dir.x);
            anim.SetFloat("y", dir.y);

            Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayerTo);
        for (int i = 0; i < playerToDamage.Length; i++)
        {
            playerToDamage[i].GetComponent<Vida_Player>().takeDamage();
        } 
        }
        else
        {
            anim.SetBool("IsAtacking", false);
        }
        //moverse
        if ((Vector3.Distance(target.transform.position, transform.position) < distance) && Vector3.Distance(target.transform.position, transform.position) > parrar && vidaSoldado.vidaActual > 0)
        {
            MovementCharacter(movement); 
        }
        //MUERTE
        if (vidaSoldado.vidaActual <= 0)
        {
            Muerte();
        }
    }

    private void MovementCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
    void Muerte()
    {
        anim.SetBool("Muerto", true);
        Destroy(this.GetComponent<BoxCollider2D>());
        estaMuerto = true;
        StartCoroutine(Espera());
    }
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);
    }
    private void MoveAnim()
    {
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);
    }
}
