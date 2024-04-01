using UnityEngine;
public class CharacterMove : MonoBehaviour
{
    // codigo de referencia https://www.youtube.com/watch?v=whzomFgjT50&t=306s
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    //public Joystick joystick;
    [Header("Menu Debug")]
    public bool esPc;

    private void Update()
    {
        if (esPc)
        {
            MovePlayerPc();
        }
        else
        {
            MovePlayer();
        }
       
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
    private void MovePlayer()
    {    
       /* movement.y = joystick.Vertical;
        movement.x = joystick.Horizontal;
        */
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }
    void MovePlayerPc()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

}
