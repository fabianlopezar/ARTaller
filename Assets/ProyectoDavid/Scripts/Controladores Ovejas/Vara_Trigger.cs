using UnityEngine;
public class Vara_Trigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Oveja"))
        {
            // collision.GetComponent<Ovejas>().tieneLaVara = true;
            collision.GetComponent<Sheeps>().tieneLaVara = true;
        }
    }   
}

