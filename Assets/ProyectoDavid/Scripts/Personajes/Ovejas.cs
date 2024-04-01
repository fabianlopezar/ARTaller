using UnityEngine;
using UnityEngine.UI;
public class Ovejas : MonoBehaviour
{
    public int cantiOvejas=0;
    public Text cantiOvejasText;
    private Rigidbody2D rb;
    public GameObject player;
    public float distance;
    private Vector2 movement;
    public float moveSpeed;
    public bool tieneLaVara;
    public float parrar=0.25f;
    public float noContarDenuevo=0;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }   
    void FixedUpdate()
    {
        //cantiOvejasText.text = "Ovejas Guardadas: " + cantiOvejas.ToString();
        if (tieneLaVara==true)
        {
            moveSheep();
        }
    }
    public  void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    public void moveSheep()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        
        if(Vector3.Distance(player.transform.position, transform.position) > parrar)
        {//esta linea hace que  la oveja se mueva
            moveCharacter(movement); 
            moveSpeed = 1.5f;
        }
        if(Vector3.Distance(player.transform.position, transform.position) <= parrar)
        {//esta linea hace detener a la oveja
            moveSpeed = 0.5f;          
        }
       
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
