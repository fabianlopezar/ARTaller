using System.Collections;
using UnityEngine;
public class DosPatas : Enemigos
{
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;
    public LayerMask whatIsPlayer;
    public float distance;
    public float parrar;
    public float atacar;

    public Transform target;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    public bool isInChaseRange;
    public bool isInAttackRange;
    //public BarraDeVida vidaSoldado;
    public bool estaMuerto = false;

    public Transform attackPos;
    public LayerMask whatIsPlayerTo;
    public float attackRange;
    [Header("Misiones Settings")]
    public int _id;
    public static QuestManager _questManager;

    public string nombreTag;

    void Start()
    {
       // _questManager = GameObject.FindObjectOfType<QuestManager>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag($"{nombreTag}").transform;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag($"{nombreTag}") && estaMuerto==false)
        {
            MovementCharacter(movement);
            Move();
            shouldRotate = true;
            
            //if (Vector3.Distance(target.transform.position, transform.position) < atacar)
            if (Mathf.Abs(target.transform.position.x- transform.position.x) < atacar)
            {
                anim.SetBool("IsAtacking", true);
                anim.SetFloat("x", dir.x);
                anim.SetFloat("y", dir.y);
            }
            else
            {
                anim.SetBool("IsAtacking", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("IsAtacking", false);
    }
    private void FixedUpdate()
    {
        if (vidaActual <= 0)
        {
            Debug.Log("deberia funcionar");
            Muerte();
        }
    }

    private void MovementCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
    void Muerte()
    {
       this.gameObject.tag = "chuleta";
        anim.SetBool("Muerto", true);
        Destroy(this.GetComponent<BoxCollider2D>());
        estaMuerto = true;
        StartCoroutine(Espera());
    }
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(7f);
        _questManager.SumarTarea(_id);
        Destroy(this.gameObject);
    }
    private void Move()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);



        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
  

        movement = dir;

        if (shouldRotate)
        {
            anim.SetFloat("x", dir.x);
            anim.SetFloat("y", dir.y);
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }
    void OnDrawGizmos()
    {
        // Dibuja un círculo para representar el área de detección de ataque
        if (target != null)
        {
            // Dibuja una línea desde la posición del objeto actual hasta la posición del objeto de destino
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position);

            // Calcula y muestra la distancia entre los dos puntos
            float distance = Vector3.Distance(target.position, transform.position);
            Debug.Log("Distancia entre los dos puntos: " + distance.ToString("F2")); // Imprime la distancia en la consola de Unity
        }
        else
        {
//            Debug.LogWarning("No se ha asignado un objetivo para calcular la distancia."); // Advierte si no se ha asignado un objetivo
        }
    }

}
