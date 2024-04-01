using UnityEngine;
public class Patron : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool isWalking;
    public float walktime;
    public float walkCounter;
    public float waitTime;
    public float waitCounter;
    public Animator anim;
    private int walkDirection;
        private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
     
        walkCounter = walktime;
        ChooseDirection();
    }
    private void Update()
    {
      
       
    }
    public void ChooseDirection()
    {
        walkDirection = Random.Range(0,4);
        isWalking = true;
        walkCounter = walktime;
        anim.SetBool("idle", false);
     //   new Vector2 = walkDirection;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MovimientoPerro();
        }
    }
    
    public void MovimientoPerro()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    rb.velocity = new Vector2(0, speed);
                    anim.SetFloat("y", 1);
                    break;
                case 1:
                    rb.velocity = new Vector2(speed, 0);
                    anim.SetFloat("x", 1);
                    break;
                case 2:
                    rb.velocity = new Vector2(0, -speed);
                    anim.SetFloat("y", -1);
                    break;
                case 3:
                    rb.velocity = new Vector2(-speed, 0);
                    anim.SetFloat("x", -1);
                    break;
            }
            if (walkCounter < 0)
            {
                anim.SetBool("idle", true);
                isWalking = false;
                waitCounter = waitTime;
                anim.SetFloat("y", 0);
                anim.SetFloat("x", 0);
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }
}
