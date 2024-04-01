using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sheeps : MonoBehaviour
{
    public float speed;
    public float distance;
    public float parrar=0.25f;
    public float moveSpeed;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    public bool tieneLaVara;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {

        if (tieneLaVara == true)
        {
            if (Vector3.Distance(target.transform.position, transform.position) > parrar)
            {
                MovementCharacter(movement); 
                moveSpeed = 1.5f;
            }
            if (Vector3.Distance(target.transform.position, transform.position) <= parrar)
            {
                moveSpeed = 0.5f;
             }
         }
        if (tieneLaVara == false)
        {
            anim.SetBool("isRunning", false);
        }
    }
    private void MovementCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));
        MoveAnim();
        anim.SetBool("isRunning",true);
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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Oveja")
        {//esta linea hace que las ovejas no acosen al jugador, le da un respiro un espacio.
         //postada:despues de mucho tienpo lo pude lograr :)
            if (transform.position.x < collision.transform.position.x)
            {
                moveSpeed = 0;
            }
        }
    }
}
