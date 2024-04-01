using UnityEngine;
public class Techo : MonoBehaviour
{
    SpriteRenderer rend;
    public int colorchange;
    public GameObject camera;
    public float cameraSize;
    public float size;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        cameraSize = camera.GetComponent<Camera>().orthographicSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color c = rend.material.color;
            c.a = 0.5f;
            rend.material.color = c;
            camera.GetComponent<Camera>().orthographicSize = size;
        }
   
     //   Debug.Log("" + camera.GetComponent<Camera>().orthographicSize);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Color c = rend.material.color;
        c.a = colorchange;
        rend.material.color = c;


        camera.GetComponent<Camera>().orthographicSize = cameraSize;
    }
}
