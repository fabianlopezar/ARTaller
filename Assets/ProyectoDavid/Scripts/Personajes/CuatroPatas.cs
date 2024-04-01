using UnityEngine;
public class CuatroPatas : Enemigos
{
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;
    public LayerMask whatIsPlayer;
    public float distance;
    public float parrar;

    private Transform target;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    public bool isInChaseRange;
    public bool isInAttackRange;

    public GameObject chuleta;
    
    bool muerto = false;
    [Header("Misiones Settings")]
    public int _id;
    public static QuestManager _questManager;
    void Start()
    {
        _questManager = GameObject.FindObjectOfType<QuestManager>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void OnTriggerStay2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            MovementCharacter(movement);
            Move();
        }
        if (vidaActual <= 0 && muerto==false)
        {
            muerto = true;
            Instantiate(chuleta, transform.position, transform.rotation);
            _questManager.SumarTarea(_id);
            Destroy(this.gameObject);        
        }
        
    }
    private void MovementCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
    public void Move()
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
    private void OnBecameInvisible()
    {
        // Pausar la animación cuando el objeto se vuelve invisible
        anim.enabled = false;
    }

    private void OnBecameVisible()
    {
        // Reanudar la animación cuando el objeto se vuelve visible nuevamente
        anim.enabled = true;
    }
}
