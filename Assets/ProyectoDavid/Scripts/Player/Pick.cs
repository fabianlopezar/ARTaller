using UnityEngine;
public class Pick : MonoBehaviour
{
    public GameObject manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {/*
        if (collision.gameObject.CompareTag("chuleta"))
        {  
            Destroy(collision.gameObject);
            GameManager.instance.chuleta++;
            GameManager.instance.guardarInt();
        }
        if (collision.gameObject.CompareTag("zanahoria"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.zanahoria++;
            GameManager.instance.guardarInt();
        }
        if (collision.gameObject.CompareTag("tomate"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.tomate++;
            GameManager.instance.guardarInt();
        }*/
        if (collision.CompareTag("chuleta"))
        {
            Destroy(collision.gameObject);
            manager.GetComponent<GameManager>().chuleta++;
            manager.GetComponent<GameManager>().guardarInt();
            
        }
        if (collision.gameObject.CompareTag("zanahoria"))
        {
            Destroy(collision.gameObject);
            manager.GetComponent<GameManager>().zanahoria++;
            manager.GetComponent<GameManager>().guardarInt();
        }
        if (collision.gameObject.CompareTag("tomate"))
        {
            Destroy(collision.gameObject);
            manager.GetComponent<GameManager>().tomate++;
            manager.GetComponent<GameManager>().guardarInt();
        }
    }
}

